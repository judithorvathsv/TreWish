import { components } from "./lib/api/v1";

export type StatisticsUserResponseProps ={
  name: string,
  wishedWishes?: number,
  purchasedWishes?: number,
}

export type WishesProps = components["schemas"]["User"][];

export type WishProps = {
    id:number,
    name:string,
    description?:string,
    price:number,
    webPageLink?:string
}