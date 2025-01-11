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
  
