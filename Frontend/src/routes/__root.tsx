import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import "../index.css";
import NavBar from "../components/NavBar";

export const Route = createRootRoute({
  component: () => (
    <>
      <div>
        <NavBar />
      </div>
      <Outlet />
      <TanStackRouterDevtools />
    </>
  ),
});
