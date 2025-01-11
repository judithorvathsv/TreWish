import { useEffect, useState } from "react";
import { allWishes } from "../utils/wishFetch";
import { WishProps } from "../types";
import Wish from "./wish";

const WishList = () => {
  const [wishes, setWishes] = useState<WishProps[]>([]);
  const [error, setError] = useState<string | unknown>("");

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await allWishes();
        setWishes(response.data as WishProps[]);
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
      {wishes.map((wishObject) => (
        <Wish
          key={wishObject.id}
          id={wishObject.id}
          name={wishObject.name}
          description={wishObject.description}
          price={wishObject.price}
          webPageLink={wishObject.webPageLink}
        />
      ))}
    </div>
  );
};

export default WishList;
