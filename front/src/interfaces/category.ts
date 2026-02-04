export type CategoryPurpose = 'expense' | 'income' | 'both'

export interface Category {
  id: string
  description: string
  purpose: CategoryPurpose
}
