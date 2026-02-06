import { useEffect, useState } from 'react'
import { TransactionForm } from '../../components/Forms/TransactionForm'
import { TransactionsTable } from '../../components/Tables/TransactionsTable'
import type { Transaction } from '../../interfaces/transection'
import { usePagination } from '../../hooks/usePagination'
import { Pagination } from '../../components/UI/Pagination'
import { transactionService } from '../../services/transactionService'

export function TransactionsPage() {
    const [transactions, setTransactions] = useState<Transaction[]>([])
    const [page, setPage] = useState(1)

    async function loadTransactions() {
        const { data } = await transactionService.getAll()
        setTransactions(data)
    }

    useEffect(() => {
        loadTransactions()
    }, [])

    async function onDeleteTransaction(id: string) {
        try {
            await transactionService.delete(id)
            await loadTransactions()
        } catch (error) {
            console.error('Erro ao deletar transação:', error)
            alert('Não foi possível excluir a transação.')
        }
    }

    const { paginatedData, totalPages } = usePagination({
        data: transactions,
        currentPage: page,
        itemsPerPage: 5
    })

    return (
        <div className="container">
            <h1>Transações</h1>

            <TransactionForm onSuccess={loadTransactions} />

            <TransactionsTable
                transactions={paginatedData}
                onDelete={onDeleteTransaction}
            />

            <Pagination
                currentPage={page}
                totalPages={totalPages}
                onPageChange={setPage}
            />
        </div>
    )
}
