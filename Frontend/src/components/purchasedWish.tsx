import { WishProps } from "../types";

const PurchasedWish = ({
  name,
  description,
  price,
  webPageLink,
}: WishProps) => {
  return (
    <>
      <h2>Your purchased Wishes</h2>
      <div>
        <p>
          Name: <b>{name}</b>
        </p>
        <p>Description: {description}</p>
        <p>Price: {price}</p>
        <p>WebPageLink: {webPageLink}</p>
      </div>
    </>
  );
};

export default PurchasedWish;
