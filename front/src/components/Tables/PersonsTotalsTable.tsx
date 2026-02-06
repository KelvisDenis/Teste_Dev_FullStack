import type { PersonTotals } from '../../interfaces/person'
import { Table } from '../../components/UI/Table'
import { Card } from '../UI/Card'

interface Props {
    persons: PersonTotals[]
}

export function PersonsTotalsTable({ persons }: Props) {

    return (
        <Card>

            <Table>
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Receitas</th>
                        <th>Despesas</th>
                        <th>Saldo</th>
                    </tr>
                </thead>

                <tbody>
                    {persons.map(p => (
                        <tr key={p.name}>
                            <td>{p.name}</td>
                            <td>{p.totalIncome}</td>
                            <td>{p.totalExpense}</td>
                            <td>{p.totalBalance}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Card>

    )
}
