import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { lazy, Suspense } from 'react'
import { Header } from '../components/Layout/Header'
import '../styles/global.css'
import { Loader } from '../components/UI/Loader'
import { PersonsTotals } from '../pages/Persons/PersonsTotals'

const PersonsPage = lazy(() =>
  import('../pages/Persons/PersonsPage').then(m => ({ default: m.PersonsPage }))
)

const CategoriesPage = lazy(() =>
  import('../pages/Categories/CategoriesPage').then(m => ({ default: m.CategoriesPage }))
)

const TransactionsPage = lazy(() =>
  import('../pages/Transactions/TransactionsPage').then(m => ({ default: m.TransactionsPage }))
)

export function Router() {
  return (
    <BrowserRouter>
      <Header />

      <Suspense fallback={<Loader />}>
        <Routes>
          <Route path="/" element={<PersonsPage />} />
          <Route path="/categories" element={<CategoriesPage />} />
          <Route path="/transactions" element={<TransactionsPage />} />
          <Route path="/totals" element={<PersonsTotals />} />
        </Routes>
      </Suspense>
    </BrowserRouter>
  )
}
