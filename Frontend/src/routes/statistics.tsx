import { createFileRoute } from "@tanstack/react-router";
import Statistics from "../components/statistics";

export const Route = createFileRoute("/statistics")({
  component: Statistics,
});