import { useEffect, useState } from 'react'
import { personService } from '../../services/personService'
import { PersonForm } from '../../components/Forms/PersonForm'
import { PersonsTable } from '../../components/Tables/PersonsTable'
import type { Person } from '../../interfaces/person'
import { usePagination } from '../../hooks/usePagination'
import { Pagination } from '../../components/UI/Pagination'

export function PersonsPage() {
  const [persons, setPersons] = useState<Person[]>([])
  const [page, setPage] = useState(1)

  const { paginatedData, totalPages } = usePagination({
    data: persons,
    currentPage: page,
    itemsPerPage: 5
  })


  async function loadPersons() {
    const { data } = await personService.getAll()
    setPersons(data)
  }

  useEffect(() => {
    loadPersons()
  }, [])

  async function onDeletePerson(id: string) {
    try {
      await personService.delete(id);
      await loadPersons();
    } catch (error) {
      console.error("Erro ao deletar pessoa:", error);
      alert("Não foi possível excluir a pessoa.");
    }
  }

  return (
    <div className="container">
      <h1>Pessoas</h1>

      <PersonForm onSuccess={loadPersons} />

      <PersonsTable 
        persons={paginatedData}
        onDelete={onDeletePerson}
      />

      <Pagination
        currentPage={page}
        totalPages={totalPages}
        onPageChange={setPage}
      />

    </div>
  )
}
