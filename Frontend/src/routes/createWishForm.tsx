import { createFileRoute } from '@tanstack/react-router'
import CreateWishForm from '../components/createWishForm'

export const Route = createFileRoute('/createWishForm')({
  component: CreateWishForm,
})
