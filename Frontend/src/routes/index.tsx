import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
    component: RouteComponent,
  });
  
  function RouteComponent() { 
  
    return (
      <div>
    <p>yeppeee</p>
      </div>
    );
  }