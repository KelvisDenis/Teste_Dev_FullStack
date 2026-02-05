import type { Category } from '../../interfaces/category'
import { Button } from '../UI/Button'
import { Card } from '../UI/Card'
import { Table } from '../UI/Table'

interface Props {
  categories: Category[]
  onDelete: (id: string) => void
}

export function CategoriesTable({ categories, onDelete }: Props) {
  return (
    <Card>
      <h2>Categorias</h2>
      <Table>


        <table className="table">
          <thead>
            <tr>
              <th>Descrição</th>
              <th>Finalidade</th>
              <th>Ações</th>
            </tr>
          </thead>

          <tbody>
            {categories.map(category => (
              <tr key={category.id}>
                <td>{category.description}</td>
                <td className={category.purpose}>
                  {category.purpose === 'expense' && 'Despesa'}
                  {category.purpose === 'income' && 'Receita'}
                  {category.purpose === 'both' && 'Ambos'}
                </td>
                <td>
                  <Button
                    variant="danger"
                    onClick={() => onDelete(category.id)}
                  >
                    Excluir
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </Table>

    </Card>
  )
}
