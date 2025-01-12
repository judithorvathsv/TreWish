import { WishProps } from "../types";

const PurchasedWish = ({
  name,
  description,
  price,
  webPageLink,
}: WishProps) => {
  return (
    <>
      <p>
        Name: <b>{name}</b>
      </p>
      <p>Description: {description}</p>
      <p>Price: {price}</p>
      <p>WebPageLink: {webPageLink}</p>
    </>
  );
};

export default PurchasedWish;
