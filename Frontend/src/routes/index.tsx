import { createFileRoute } from "@tanstack/react-router";
import Login from "../components/login";
import Register from "../components/Register";


export const Route = createFileRoute("/")({
  component: Home,
});

function Home() {
 

  return (
    <div>
      <h2>Register or Login</h2>
     <Login/>
     <Register/>
        </div>
  );
}
