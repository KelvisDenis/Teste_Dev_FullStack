import { useEffect, useState } from 'react'
import { personService } from '../../services/personService'
import { PersonForm } from '../../components/Forms/PersonForm'
import { PersonsTable } from '../../components/Tables/PersonsTable'
import type { Person } from '../../interfaces/person'
import { PersonsTotals } from './PersonsTotals'

export function PersonsPage() {
  const [persons, setPersons] = useState<Person[]>([])

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
        persons={persons}
        onDelete={onDeletePerson}
      />

      <PersonsTotals />
    </div>
  )
}
