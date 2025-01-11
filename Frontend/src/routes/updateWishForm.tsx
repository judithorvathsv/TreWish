import { createFileRoute } from '@tanstack/react-router'
import UpdateWishForm from '../components/updateWishForm'

export const Route = createFileRoute('/updateWishForm')({
  component: UpdateWishForm,
})
