export function formatPrice(price: number): string {
  return price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.')
}

export function formatThousands(num?: number): string {
  if (!num) {
    return `₽0`
  }

  if (num >= 1000) {
    const thousands = Math.floor(num / 1000)
    return `₽${thousands}т.`
  }
  return num.toString()
}
