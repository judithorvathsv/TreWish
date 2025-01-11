import { useNavigate } from "@tanstack/react-router";
import { WishProps } from "../types";
import { deleteWish } from "../utils/wishFetch";
import { useContext, useState } from "react";
import { WishContext } from "../context/wishContext";

const Wish = ({ id, name, description, price, webPageLink, onDelete }: WishProps & { onDelete: (id: number) => void }) => {
  const [isConfirming, setIsConfirming] = useState(false); 
  const [error, setError] = useState<string | unknown>("");
  const navigate = useNavigate();
  const { setWish } = useContext(WishContext);

  const handleDeleteClick = () => {
    setIsConfirming(true); 
  };

  const handleDelete = async () => {
    try {
      await deleteWish(id);
      onDelete(id);
    } catch (error) {
    setError(error);
      console.error("Error deleting wish:", error);
    }
    setIsConfirming(false); 
  };

  const handleCancel = () => {
    setIsConfirming(false); 
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
        <p>id: <b>{id}</b></p>
      </section>

      {isConfirming ? (
        <section>
          <p>Do you really want to delete it?</p>
          <button onClick={handleDelete}>Yes</button>
          <button onClick={handleCancel}>Cancel</button>
        </section>
      ) : (
        <section>
          <button onClick={handleDeleteClick}>Delete</button>     
          <button onClick={handleUpdate}>Update</button>  
        </section>
      )}
    </div>
  );
};

export default Wish;

