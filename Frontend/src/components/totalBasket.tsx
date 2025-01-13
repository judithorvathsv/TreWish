import { useContext, useEffect, useState } from "react";
import { basket, pay } from "../utils/wishFetch";
import { BasketWishProps } from "../types";
import BasketWish from "./basketWish";
import { useNavigate } from "@tanstack/react-router";
import { WishContext } from "../context/wishContext";

const TotalBasket = () => {
  const [wishes, setWishes] = useState<BasketWishProps[]>([]);
  const [totalPrice, setTotalPrice] = useState<number>(0);
  const [error, setError] = useState<string | unknown>("");
   const navigate = useNavigate();
     const { refreshWishList } = useContext(WishContext);

  const fetchWishes = async () => {
    try {
      const response = await basket();
      if (response?.data) {
        const { basketWishes, totalPrice } = response.data;
        if (basketWishes) {
          setWishes(basketWishes as BasketWishProps[]);
        }
        if (totalPrice !== undefined) {
          setTotalPrice(totalPrice);
        }
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
  }, []);

  const handlePay = async() => {
    await pay();
    refreshWishList();
    navigate({ to: "/wishList" });
  }

  const cancelHandlePay = async() => {
    alert('not ready, it should change the purchaseid to null')
  }
  

  if (error)
    return (
      <div>
        Error:
        {typeof error === "string" ? error : "An error occurred"}
      </div>
    );

  return (
    <>
      <h2>Your Backet</h2>
      <div style={{ marginBottom: "3rem" }}>
        {wishes.length > 0 ? (
          wishes.map((wishObject) => (
            <BasketWish
              key={wishObject.name}
              name={wishObject.name}
              price={wishObject.price}
              wisherName={wishObject.wisherName}
            />
          ))
        ) : (
          <div>No wishes available</div>
        )}

        <p>
          <b>Total Price: {totalPrice}</b>
          <button onClick={handlePay}>Pay</button>
          <button onClick={cancelHandlePay}>Pay</button>
        </p>
      </div>
    </>
  );
};

export default TotalBasket;
