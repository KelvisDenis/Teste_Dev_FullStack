import { useEffect, useState } from 'react'
import { personService } from '../../services/personService'
import { Card } from '../UI/Card'
import { Input } from '../UI/Input'
import { Button } from '../UI/Button'
import type { Category } from '../../interfaces/category'
import type { Person } from '../../interfaces/person'
import type { TransactionType } from '../../interfaces/transection'
import { Select } from '../UI/Select'
import { categoryService } from '../../services/categoryService'
import { transactionService } from '../../services/transactionService'
import type { AxiosError } from 'axios'

interface Props {
  onSuccess: () => void
}

export function TransactionForm({ onSuccess }: Props) {
  const [description, setDescription] = useState('')
  const [value, setValue] = useState<number | ''>('')
  const [type, setType] = useState<TransactionType>('expense')
  const [categoryId, setCategoryId] = useState('')
  const [personId, setPersonId] = useState('')

  const [categories, setCategories] = useState<Category[]>([])
  const [persons, setPersons] = useState<Person[]>([])

  useEffect(() => {
    async function loadData() {
      const [categoriesRes, personsRes] = await Promise.all([
        categoryService.getAll(),
        personService.getAll()
      ])

      setCategories(categoriesRes.data)
      setPersons(personsRes.data)
    }

    loadData()
  }, [])

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault()

    if (!description || value === '' || !categoryId || !personId) {
      return alert('Preencha todos os campos')
    }
    try {
      await transactionService.create({
        description,
        value: Number(value),
        type,
        categoryId,
        personId
      })

    } catch(error) {
      const err = error as AxiosError<{ message: string }>

      alert(err.response?.data?.message ?? 'Erro ao criar transação')
    }



    setDescription('')
    setValue('')
    setType('expense')
    setCategoryId('')
    setPersonId('')

    onSuccess()
  }

  return (
    <Card>
      <h2>Cadastrar Transação</h2>

      <form onSubmit={handleSubmit}>
        <Input
          label="Descrição"
          value={description}
          onChange={e => setDescription(e.target.value)}
        />

        <Input
          label="Valor"
          type="number"
          value={value}
          onChange={e => setValue(Number(e.target.value))}
        />

        <div className="input-group">
          <Select
            label="Tipo"
            value={type}
            onChange={e => setType(e.target.value as TransactionType)}
            options={[
              { value: 'expense', label: 'Despesa' },
              { value: 'income', label: 'Receita' }
            ]}
          />
        </div>

        <div className="input-group">
          <Select
            label="Categoria"
            value={categoryId}
            onChange={e => setCategoryId(e.target.value)}
            options={[
              { value: '', label: 'Selecione' },
              ...categories.map(cat => ({
                value: cat.id,
                label: cat.description
              }))
            ]}
          />
        </div>

        <div className="input-group">
          <Select
            label="Pessoa"
            value={personId}
            onChange={e => setPersonId(e.target.value)}
            options={[
              { value: '', label: 'Selecione' },
              ...persons.map(person => ({
                value: person.id,
                label: person.name
              }))
            ]}
          />
        </div>

        <Button type="submit">Salvar</Button>
      </form>
    </Card>
  )
}
