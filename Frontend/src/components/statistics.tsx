import { useEffect, useState } from "react";
import { allUserWitPurchasedAndWantedhWishes } from "../utils/userFetch";
import User from "./user";
import { StatisticsUserResponseProps } from "../types";

const Statistics = () => {
  const [users, setUsers] = useState<StatisticsUserResponseProps[]>([]);
  const [userListCount, setUserListCount] = useState(0);
  const [error, setError] = useState<string | unknown>("");

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await allUserWitPurchasedAndWantedhWishes();
        setUsers(response.data as StatisticsUserResponseProps[]);
        setUserListCount(response.data == undefined ? 0 : response.data.length);
      } catch (err) {
        setError(err);
        console.error("Error fetching users:", err);
      }
    };

    fetchUsers();
  }, []);

  if (error)
    return (
      <div>
        Error loading users:
        {typeof error === "string" ? error : "An error occurred"}
      </div>
    );

  return (
    <div>
      <h2>Statistics</h2>
      {users.map((userObject) => (
        <User
          key={userObject.name}
          name={userObject.name}
          wishedWishes={userObject.wishedWishes}
          purchasedWishes={userObject.purchasedWishes}
        />
      ))}

      {
        <p>
          <b>Number of Users: {userListCount}</b>
        </p>
      }
    </div>
  );
};

export default Statistics;
