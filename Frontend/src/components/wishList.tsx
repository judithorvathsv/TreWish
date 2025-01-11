import { useEffect, useState } from "react";
import { allWishes } from "../utils/wishFetch";
import { WishProps } from "../types";
import Wish from "./wish";
import { Link } from "@tanstack/react-router";

const WishList = () => {
  const [wishes, setWishes] = useState<WishProps[]>([]);
  const [error, setError] = useState<string | unknown>("");

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await allWishes();
        if (response?.data && Array.isArray(response.data)) {
          setWishes(response.data);
        } else {
          setWishes([]);
        }
      } catch (err) {
        setError(err);
        console.error("Error fetching users:", err);
      }
    };

    fetchUsers();
  }, []);


  const handleDelete = (id: number) => {
    setWishes(wishes.filter(wish => wish.id !== id)); 
  };


  if (error)
    return (
      <div>
        Error loading users:
        {typeof error === "string" ? error : "An error occurred"}
      </div>
    );

  return (
    <>
      <div>
        <Link to="/createWishForm">Create New Wish</Link>
      </div>
      <div>
        {wishes.length > 0 ? (
          wishes.map((wishObject) => (
            <Wish
              key={wishObject.id}
              id={wishObject.id}
              name={wishObject.name}
              description={wishObject.description}
              price={wishObject.price}
              webPageLink={wishObject.webPageLink}
              onDelete={handleDelete} 
            />
          ))
        ) : (
          <div>No wishes available</div>
        )}
      </div>
    </>
  );
};

export default WishList;
