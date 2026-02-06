import type { ButtonHTMLAttributes } from "react"

interface Props extends ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: 'primary' | 'danger'
}

export function Button({
  variant = 'primary',
  children,
  ...props
}: Props) {
  return (
    <button className={`btn ${variant}`} {...props}>
      {children}
    </button>
  )
}
