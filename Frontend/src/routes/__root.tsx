import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import "../index.css";

export const Route = createRootRoute({
  component: () => (
    <>
      <div className="">
        {/* <Link
          to="/"
          activeProps={{
            className: "font-bold",
          }}
          activeOptions={{ exact: true }}
        >
          Home
        </Link>        
        <Link to="/statistics">Statistics</Link> */}
      </div>
      <Outlet />
      <TanStackRouterDevtools />
    </>
  ),
});

