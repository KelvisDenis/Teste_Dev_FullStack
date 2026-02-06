import type { ReactNode } from "react"

interface Props {
  children: ReactNode
}

export function Card({ children }: Props) {
  return <div className="card">{children}</div>
}
