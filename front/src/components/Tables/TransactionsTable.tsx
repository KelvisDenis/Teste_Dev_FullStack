import { Card } from '../UI/Card'
import { Button } from '../UI/Button'
import type { Transaction } from '../../interfaces/transection'
import { Table } from '../UI/Table'

interface Props {
  transactions: Transaction[]
  onDelete: (id: string) => void
}

export function TransactionsTable({ transactions, onDelete }: Props) {
  return (
    <Card>
      <h2>Transações</h2>

      <Table>

        <table className="table">
          <thead>
            <tr>
              <th>Descrição</th>
              <th>Valor</th>
              <th>Tipo</th>
              <th>Ações</th>
            </tr>
          </thead>

          <tbody>
            {transactions.map(transaction => (
              <tr key={transaction.id}>
                <td>{transaction.description}</td>
                <td className={transaction.type}>
                  R$ {transaction.value.toFixed(2)}
                </td>
                <td className={transaction.type}>
                  {transaction.type === 'expense' ? 'Despesa' : 'Receita'}
                </td>
                <td>
                  <Button
                    className="danger"
                    onClick={() => onDelete(transaction.id)}
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
