import { api } from './api'
import type { Category } from '../interfaces/category'
import { mapDtoToCategoryPurpose, mapCategoryPurposeToDto } from '../utils/mappers'

export const categoryService = {
  getAll() {
    return api.get<Category[]>('/categories')
      .then(res => {
        const mapped = res.data.map(cat => ({
          ...cat,
          purpose: mapDtoToCategoryPurpose(cat.purpose as unknown as number)
        }))
        return { ...res, data: mapped }
      })
  },

  create(data: Omit<Category, 'id'>) {
    const payload = {
      ...data,
      purpose: mapCategoryPurposeToDto(data.purpose)
    }
    return api.post('/categories', payload)
  },

  delete(id: string) {
    return api.delete(`/categories/${id}`)
  }
}
