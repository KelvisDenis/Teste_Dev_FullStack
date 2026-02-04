export type TransactionType = 'expense' | 'income'

export interface Transaction {
  id: string
  description: string
  value: number
  type: TransactionType
  categoryId: string
  personId: string
}
