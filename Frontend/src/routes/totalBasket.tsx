import { createFileRoute } from '@tanstack/react-router'
import TotalBasket from '../components/totalBasket'

export const Route = createFileRoute('/totalBasket')({
  component: TotalBasket,
})