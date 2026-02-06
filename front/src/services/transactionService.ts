import type { Transaction } from '../interfaces/transection'
import { mapDtoToTransactionType, mapTransactionTypeToDto } from '../utils/mappers'
import { api } from './api'

export const transactionService = {
  getAll() {
    return api.get<Transaction[]>('/transections').then(res => {
      const mapped = res.data.map(cat => ({
        ...cat,
        type: mapDtoToTransactionType(cat.type as unknown as number)
      }))
      return { ...res, data: mapped }
    })
  },

  create(data: Omit<Transaction, 'id'>) {
    const payload = {
      ...data,
      type: mapTransactionTypeToDto(data.type)
    }
    console.log("datya", payload)
    return api.post('/transections', payload)
  },

  delete(id: string) {

    return api.delete(`/transections/${id}`)
  }
}
