using FacilityService.Models;
using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityService.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly Context _context;

    public CategoryRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<CategoryEntity>> GetAllAsync()
    {
        return await _context.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Guid> CreateAsync(CategoryEntity categoryEntity)
    {
        await _context.Categories.AddAsync(categoryEntity);
        await _context.SaveChangesAsync();
        return categoryEntity.Id;
    }

    public async Task RemoveAsync(Guid categoryId)
    {
        CategoryEntity? categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        if (categoryEntity is null) return;

        _context.Categories.Remove(categoryEntity);
        await _context.SaveChangesAsync();
    }
}