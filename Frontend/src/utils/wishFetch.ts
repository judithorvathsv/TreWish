import createClient from "openapi-fetch";
import type { paths } from "../lib/api/v1";

const client = createClient<paths>({ baseUrl: "http://localhost:5035/" });

export const allWishes = () => client.GET("/api/Wishes", {});
