import type { Transaction } from '../interfaces/transection'
import { mapTransactionTypeToDto } from '../utils/mappers'
import { api } from './api'

export const transactionService = {
  getAll() {
    return api.get<Transaction[]>('/transections')
  },

  create(data: Omit<Transaction, 'id'>) {
    const payload = {
      ...data,
      type: mapTransactionTypeToDto(data.type)
    }
    console.log("payload", payload)
    return api.post('/transections', payload)
  },

  delete(id: string) {
    return api.delete(`/transections/${id}`)
  }
}
