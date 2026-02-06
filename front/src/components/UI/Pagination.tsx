interface Props {
  currentPage: number
  totalPages: number
  onPageChange: (page: number) => void
}

export function Pagination({
  currentPage,
  totalPages,
  onPageChange
}: Props) {
  if (totalPages <= 1) return null

  return (
    <div className="pagination">
      <button
        className="btn"
        disabled={currentPage === 1}
        onClick={() => onPageChange(currentPage - 1)}
      >
        Anterior
      </button>

      <span className="pagination-info">
        Página {currentPage} de {totalPages}
      </span>

      <button
        className="btn"
        disabled={currentPage === totalPages}
        onClick={() => onPageChange(currentPage + 1)}
      >
        Próxima
      </button>
    </div>
  )
}
