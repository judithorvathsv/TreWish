import { createFileRoute } from "@tanstack/react-router";
import Login from "../components/login";

export const Route = createFileRoute("/login")({
  component: Login,
});