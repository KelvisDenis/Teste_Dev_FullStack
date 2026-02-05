import { NavLink } from 'react-router-dom'

export function Header() {
  return (
    <header className="app-header">
      <nav>
        <NavLink to="/">Pessoas</NavLink>
        <NavLink to="/categories">Categorias</NavLink>
        <NavLink to="/transactions">Transações</NavLink>
        <NavLink to="/totals">Total por Pessoa</NavLink>
      </nav>
    </header>
  )
}
