import React, { useState } from "react";
import { useNavigate } from "@tanstack/react-router";

const Register = () => {
      const [email, setEmail] = useState("");
        const [password, setPassword] = useState("");
        const navigate = useNavigate();
        const [error, setError] = useState<string>("");
      
        const handleLogin = async (e: React.FormEvent) => {
          e.preventDefault();
      
          const data = { Name: email };
          try {
            const response = await fetch(
              "http://localhost:5035/api/users/register/sendUserEmail",
              {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(data),
              }
            );
      
            if (!response.ok) {
              setError("Network response was not ok");
            }
      
            navigate({ to: "/wishList" });
          } catch (error) {
            setError("Register error");
            console.error("Error sending data:", error);
            return;
          }
        };
      
        if (error)
          return (
            <div>
              Error loading users:
              {typeof error === "string" ? error : "An error occurred"}
            </div>
          );
  return (
    <div>
    <h2>Register</h2>
    <form onSubmit={handleLogin}>
      <input
        type="email"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />
      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button type="submit">Register</button>
    </form>
  </div>
  )
}

export default Register
