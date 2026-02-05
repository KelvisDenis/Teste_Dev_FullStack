import { useMemo } from 'react'

interface UsePaginationProps<T> {
  data: T[]
  currentPage: number
  itemsPerPage: number
}

export function usePagination<T>({
  data,
  currentPage,
  itemsPerPage
}: UsePaginationProps<T>) {
  const totalItems = data.length

  const totalPages = Math.ceil(totalItems / itemsPerPage)

  const paginatedData = useMemo(() => {
    const start = (currentPage - 1) * itemsPerPage
    const end = start + itemsPerPage
    return data.slice(start, end)
  }, [data, currentPage, itemsPerPage])

  return {
    paginatedData,
    totalPages,
    totalItems
  }
}
