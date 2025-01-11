import { useNavigate } from "@tanstack/react-router";
import { WishProps } from "../types";
import { deleteWish, purchaseWish } from "../utils/wishFetch";
import { useContext, useState } from "react";
import { WishContext } from "../context/wishContext";

const Wish = ({ id, name, description, price, webPageLink, onDelete, onPurchase  }: WishProps & { onDelete: (id: number) => void; onPurchase: () => void }) => {
  const [isConfirmingDelete, setIsConfirmingDelete] = useState(false);
  const [isConfirmingPurchase, setIsConfirmingPurchase] = useState(false);
  const [error, setError] = useState<string | unknown>("");
  const navigate = useNavigate();
  const { setWish } = useContext(WishContext);

  const handleDeleteClick = () => {
    setIsConfirmingDelete(true);
  };

  const handleDelete = async () => {
    try {
      await deleteWish(id);
      onDelete(id);
      alert("Wish deleted successfully!");
    } catch (error) {
      setError(error);
      console.error("Error deleting wish:", error);
    }
    setIsConfirmingDelete(false);
  };

  const handleCancelDelete = () => {
    setIsConfirmingDelete(false);
  };

  const handleUpdate = () => { 
    setWish({
      id,
      name,
      description,
      price,
      webPageLink
    });
   
    navigate({
      to: "/updateWishForm",
    });
  };

  const handlePurchaseClick = () => {
    setIsConfirmingPurchase(true); 
  };

  const handlePurchase = async () => {
    try {
      await purchaseWish(id);
      alert("Wish purchased successfully!");
      onPurchase();
    } catch (error) {
      setError(error); 
      console.error("Error purchasing wish:", error);
    }
    setIsConfirmingPurchase(false);
  };

  const handleCancelPurchase = () => {
    setIsConfirmingPurchase(false); 
  };

  if (error)
    return (
      <div>
        Error loading users:
        {typeof error === "string" ? error : "An error occurred. Try again"}
      </div>
    );

  return (
    <div>
      <section>
        <p>Name: <b>{name}</b></p>
        <p>Description: {description}</p>
        <p>Price: {price}</p>
        <p>WebPageLink: {webPageLink}</p>    
      </section>

      {/* Delete Confirmation */}
      {isConfirmingDelete ? (
        <section>
          <p>Do you really want to delete it?</p>
          <button onClick={handleDelete}>Yes</button>
          <button onClick={handleCancelDelete}>Cancel</button>
        </section>
      ) : isConfirmingPurchase ? (
        // Purchase Confirmation
        <section>
          <p>Do you really want to purchase this wish?</p>
          <button onClick={handlePurchase}>Yes</button>
          <button onClick={handleCancelPurchase}>Cancel</button>
        </section>
      ) : (
        // Main Action Buttons
        <section>
          <button onClick={handleDeleteClick}>Delete</button>     
          <button onClick={handleUpdate}>Update</button>  
          <button onClick={handlePurchaseClick}>Purchase</button>  
        </section>
      )}
    </div>
  );
};

export default Wish;
