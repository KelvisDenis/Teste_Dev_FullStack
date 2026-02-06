import type { Person, PersonTotals } from '../interfaces/person'
import { api } from './api'

export const personService = {
    getAll: () => api.get<Person[]>('persons/'),

    create: (data: Omit<Person, 'id'>) =>
        api.post<Person>('persons/', data),

    delete: (id: string) =>
        api.delete(`persons/${id}`),

    getTotals: () =>
        api.get<PersonTotals[]>('/persons/totals'),
}
