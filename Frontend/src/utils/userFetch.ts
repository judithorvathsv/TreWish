import createClient from "openapi-fetch";
import type { paths } from "../lib/api/v1";

const client = createClient<paths>({ baseUrl: "http://localhost:5035/" });

export const userWithAdressFetch = (id: number) =>
  client.GET("/api/Users/{id}", {
    params: {
      path: { id: id },
      query: undefined,
    },
  });

export const allUserWitPurchasedAndWantedhWishes = () =>
  client.GET("/api/Users", {});
