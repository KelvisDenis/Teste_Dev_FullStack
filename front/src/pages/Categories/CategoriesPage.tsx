import { useEffect, useState } from 'react'
import { CategoryForm } from '../../components/Forms/CategoryForm'
import type { Category } from '../../interfaces/category'
import { usePagination } from '../../hooks/usePagination'
import { Pagination } from '../../components/UI/Pagination'
import { categoryService } from '../../services/categoryService'
import { CategoriesTable } from '../../components/Tables/CategoriesTable'

export function CategoriesPage() {
  const [categories, setCategories] = useState<Category[]>([])
  const [page, setPage] = useState(1)


  async function loadCategories() {
    const { data } = await categoryService.getAll()
    setCategories(data)
  }

  useEffect(() => {
    loadCategories()
  }, [])

  async function onDeleteCategory(id: string) {
    try {
      await categoryService.delete(id)
      await loadCategories()
    } catch (error) {
      console.error('Erro ao deletar categoria:', error)
      alert('Não foi possível excluir a categoria.')
    }
  }

  const { paginatedData, totalPages } = usePagination({
    data: categories,
    currentPage: page,
    itemsPerPage: 5
  })


  return (
    <div className="container">
      <h1>Categorias</h1>

      <CategoryForm onSuccess={loadCategories} />

      <CategoriesTable
        categories={paginatedData}
        onDelete={onDeleteCategory}
      />

      <Pagination
        currentPage={page}
        totalPages={totalPages}
        onPageChange={setPage}
      />
    </div>
  )
}
