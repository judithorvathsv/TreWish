import createClient from "openapi-fetch";
import type { paths } from "../lib/api/v1";

const client = createClient<paths>({ baseUrl: "http://localhost:5035/" });

export const allWishes = () => client.GET("/api/Wishes", {});

export const saveNewWish = (name: string, description: string, price: string, webPageLink: string) => {
    const wishRequest = {
      name,
      description,
      price: parseFloat(price), 
      webPageLink,
    };  

    return client.POST("/api/Wishes", {
      body: wishRequest, 
    });
  };

export const deleteWish = (id: number) => client.DELETE("/api/Wishes/{id}", {
    params: {
      path: { id: id },
      query: undefined,
    },
  });


  export const updateWish = (id: number, name: string, description: string, price: string, webPageLink: string) => {
    const wishRequest = {
        id,
        name,
        description,
        price: parseFloat(price), 
        webPageLink,
    };  

    return client.PUT("/api/Wishes/{id}", {
        params: {
            path: { id: id.toString() }},  
        body: wishRequest, 
    });
};

export const purchaseWish = (id: number) => { 
  return client.PUT("/api/Wishes/purchase/{id}", {
      params: {
          path: { id }},  
  });
};

export const purchasedWishList = () => client.GET("/api/Wishes/purchased", {});





  
  
