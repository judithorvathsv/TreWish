import { createFileRoute } from '@tanstack/react-router'
import PurchasedWishList from '../components/purchasedWishList'

export const Route = createFileRoute('/purchasedWishList')({
  component: PurchasedWishList,
})
