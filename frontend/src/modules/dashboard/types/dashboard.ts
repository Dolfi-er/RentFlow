export type TDashboard = {
  objects: {
    currentMonth: number
    lastMonth: number
  }
  rentedObjects: {
    currentMonth: number
    lastMonth: number
  }
  revenue: {
    currentMonth: number
    lastMonth: number
  }
  revenuePerMonth: TMonthRevenue[]
  objectsByStatus: TObjectByStatus[]
  lastTransactions: TTransaction[]
  requests: TRequest[]
}

export type TMonthRevenue = {
  month: number
  revenue: number
}

export type TObjectByStatus = {
  status: string
  count: number
}

export type TTransaction = {
  id: string
  imageUrl: string
  address: string
  datetime: string
  price: number
}

export type TRequest = {
  id: string
  category: string
  address: string
  name: string
  status: string
}
