import { useState } from 'react'
import { Card } from '../UI/Card'
import { Input } from '../UI/Input'
import { Button } from '../UI/Button'
import type { CategoryPurpose } from '../../interfaces/category'
import { Select } from '../UI/Select'
import { categoryService } from '../../services/categoryService'

interface Props {
  onSuccess: () => void
}

export function CategoryForm({ onSuccess }: Props) {
  const [description, setDescription] = useState('')
  const [purpose, setPurpose] = useState<CategoryPurpose>('expense')

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault()

    if (!description) return alert('Informe a descrição')

    await categoryService.create({
      description,
      purpose
    })

    setDescription('')
    setPurpose('expense')
    onSuccess()
  }

  return (
    <Card>
      <h2>Cadastrar Categoria</h2>

      <form onSubmit={handleSubmit}>
        <Input
          label="Descrição"
          value={description}
          onChange={e => setDescription(e.target.value)}
        />

        <div className="input-group">
          <Select
            label="Finalidade"
            value={purpose}
            onChange={e => setPurpose(e.target.value as CategoryPurpose)}
            options={[
              { value: 'expense', label: 'Despesa' },
              { value: 'income', label: 'Receita' },
              { value: 'both', label: 'Ambos' }
            ]}
          />

        </div>

        <Button type="submit">Salvar</Button>
      </form>
    </Card>
  )
}
