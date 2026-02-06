import { useEffect, useState } from 'react'
import { personService } from '../../services/personService'
import type { PersonTotals } from '../../interfaces/person'

import { PersonsTotalsTable } from '../../components/Tables/PersonsTotalsTable'


export function PersonsTotals() {
  const [totals, setTotals] = useState<PersonTotals[]>([])

  useEffect(() => {
    async function load() {
      const { data } = await personService.getTotals()
      setTotals(data)
    }

    load()
  }, [])

  return (
    <div className="container">
      <h1>Pessoas</h1>
      <PersonsTotalsTable
        persons={totals}
      />
    </div>
  )
}
