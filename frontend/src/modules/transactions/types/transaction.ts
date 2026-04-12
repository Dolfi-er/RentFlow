export type TTransaction = {
  id: string
  name: string
  date: string
  price: number
  status: string
}

export type TTransactionForm = {
  name?: string
  date?: string
  price?: number
}
