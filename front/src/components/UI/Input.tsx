import type { InputHTMLAttributes } from "react"

interface Props extends InputHTMLAttributes<HTMLInputElement> {
  label: string
}

export function Input({ label, ...props }: Props) {
  return (
    <div className="input-group">
      <label>{label}</label>
      <input {...props} />
    </div>
  )
}
