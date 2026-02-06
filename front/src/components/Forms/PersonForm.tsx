import { useState } from 'react'
import { personService } from '../../services/personService'
import { Card } from '../UI/Card'
import { Input } from '../UI/Input'
import { Button } from '../UI/Button'

interface Props {
  onSuccess: () => void
}

export function PersonForm({ onSuccess }: Props) {
  const [name, setName] = useState('')
  const [age, setAge] = useState<number | ''>('')

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault()

    if (!name || age === '') return alert('Preencha todos os campos')
    if (age <= 0) return alert('Idade inválida')

    await personService.create({ name, age: Number(age) })

    setName('')
    setAge('')
    onSuccess()
  }

  return (
    <Card>
      <h2>Cadastrar Pessoa</h2>

      <form onSubmit={handleSubmit}>
        <Input
          label="Nome"
          value={name}
          onChange={e => setName(e.target.value)}
        />

        <Input
          label="Idade"
          type="number"
          value={age}
          onChange={e => setAge(Number(e.target.value))}
        />

        <Button type="submit">Salvar</Button>
      </form>
    </Card>
  )
}
