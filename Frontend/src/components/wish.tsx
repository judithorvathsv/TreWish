import { WishProps } from "../types";

const Wish = ({ id, name, description, price, webPageLink }: WishProps) => {
  return (
    <div>
      <p>
        Name: <b>{name}</b>
      </p>
      <p>Description: {description}</p>
      <p>Price: {price}</p>
      <p>WebPageLink: {webPageLink}</p>
      <p>
        id: <b>{id}</b>
      </p>
    </div>
  );
};

export default Wish;
