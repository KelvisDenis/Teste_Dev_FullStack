import type { CategoryPurpose } from "../interfaces/category"
import type { TransactionType } from "../interfaces/transection"

// FRONT → DTO 
export function mapCategoryPurposeToDto(purpose: CategoryPurpose): number {
  switch (purpose) {
    case 'income': return 1 
    case 'expense': return 2 
    case 'both': return 3 
  }
}

export function mapTransactionTypeToDto(type: TransactionType): number {
  switch (type) {
    case 'income': return 1
    case 'expense': return 2
  }
}

// DTO → FRONT 
export function mapDtoToCategoryPurpose(value: number): CategoryPurpose {
  switch (value) {
    case 1: return 'income'   
    case 2: return 'expense'  
    case 3: return 'both'
    default: return 'expense' 
  }
}

export function mapDtoToTransactionType(value: number): TransactionType {
  switch (value) {
    case 1: return 'income'
    case 2: return 'expense'
    default: return 'expense'
  }
}
