import { createFileRoute } from "@tanstack/react-router";
import WishList from "../components/wishList";

export const Route = createFileRoute("/wishList")({
  component: WishList,
});
