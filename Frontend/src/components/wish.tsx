import { WishProps } from "../types";
import { deleteWish } from "../utils/wishFetch";

const Wish = ({ id, name, description, price, webPageLink,onDelete  }: WishProps & { onDelete: (id: number) => void }) => {

    const handleDelete = async() => {
        try {
            await deleteWish(id); 
            onDelete(id);
          } catch (error) {
            console.error("Error deleting wish:", error);
          }
    }
  return (
    <div>
      <section>
        <p>        
          Name: <b>{name}</b>
        </p>
        <p>Description: {description}</p>
        <p>Price: {price}</p>
        <p>WebPageLink: {webPageLink}</p>
        <p>      
          id: <b>{id}</b>
        </p>
      </section>
      <section>
        <button onClick={() => handleDelete()}>Delete</button>
      </section>
    </div>
  );
};

export default Wish;
