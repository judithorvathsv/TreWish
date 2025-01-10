import { components } from "./lib/api/v1";

export type StatisticsUserResponseProps =
  components["schemas"]["UserResponse"][];

export type StatisticsUserResponsePropsShort = {
  name: string;
  wishedWishes?: number;
  purchasedWishes?: number;
};
