import type { SelectHTMLAttributes } from 'react'

interface Option {
  value: string
  label: string
}

interface Props extends SelectHTMLAttributes<HTMLSelectElement> {
  label: string
  options: Option[]
}

export function Select({ label, options, ...rest }: Props) {
  return (
    <div className="input-group">
      <label>{label}</label>

      <select className="select" {...rest}>
        {options.map(option => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </select>
    </div>
  )
}
