import { Card } from '../UI/Card'
import type { Transaction } from '../../interfaces/transection'
import { Table } from '../UI/Table'

interface Props {
  transactions: Transaction[]
}

export function TransactionsTable({ transactions }: Props) {
  return (
    <Card>
      <h2>Transações</h2>

      <Table>

          <thead>
            <tr>
              <th>Descrição</th>
              <th>Valor</th>
              <th>Tipo</th>
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
              </tr>
            ))}
          </tbody>
      </Table>
    </Card>
  )
}
