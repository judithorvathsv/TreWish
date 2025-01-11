import { useEffect, useState } from 'react'
import { purchasedWishList } from '../utils/wishFetch';
import { WishProps } from '../types';
import PurchasedWish from './purchasedWish';

const PurchasedWishList = () => {
      const [wishes, setWishes] = useState<WishProps[]>([]);
      const [error, setError] = useState<string | unknown>("");

        const fetchWishes = async () => {
          try {
            const response = await purchasedWishList();
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
      }, []);


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
            {wishes.length > 0 ? (
              wishes.map((wishObject) => (
                <PurchasedWish
                  key={wishObject.id}   
                  id={wishObject.id}            
                  name={wishObject.name}
                  description={wishObject.description}
                  price={wishObject.price}
                  webPageLink={wishObject.webPageLink}             
                />
              ))
            ) : (
              <div>No wishes available</div>
            )}
          </div>
        </>
      );
    };

export default PurchasedWishList
