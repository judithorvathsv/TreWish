import { useEffect, useState } from "react";
import { allWishes } from "../utils/wishFetch";
import { WishProps } from "../types";
import Wish from "./wish";
import { Link } from "@tanstack/react-router";

const WishList = () => {
  const [wishes, setWishes] = useState<WishProps[]>([]);
  const [error, setError] = useState<string | unknown>("");
  const [stateForRefresh, setStateForRefresh] = useState(false)



 
    const fetchWishes = async () => {
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

  useEffect(() => {
    fetchWishes();
  }, [stateForRefresh]);


  const handleDelete = (id: number) => {
    setWishes(wishes.filter(wish => wish.id !== id)); 
  };

  const handleRefreshAfterPurchase = () => {
    setStateForRefresh(prev => !prev);
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
     <h2>All Wishes</h2>
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
              onPurchase={handleRefreshAfterPurchase}
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
