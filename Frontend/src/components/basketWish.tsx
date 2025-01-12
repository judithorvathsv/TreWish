import { BasketWishProps } from '../types';

    const BasketWish = ({
      name,
      price,
      wisherName
    }: BasketWishProps) => {
      return (
        <>
          <p>Name: {name}</p>         
          <p>Price: {price}</p>  
          <p>Wisher Name:{wisherName}
          </p>          
        </>
      );
    };
export default BasketWish
