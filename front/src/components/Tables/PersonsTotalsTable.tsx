import type { PersonTotals } from '../../interfaces/person'
import { Button } from '../../components/UI/Button'
import { Table } from '../../components/UI/Table'
import { Card } from '../UI/Card'

interface Props {
    persons: PersonTotals[]
    onDelete: (id: string) => void
}

export function PersonsTotalsTable({ persons, onDelete }: Props) {

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
                            <td>{p.totalExpense}</td>
                            <td>
                                <Button
                                    variant="danger"
                                    onClick={() => onDelete(p.personId)}
                                >
                                    Excluir
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Card>

    )
}
