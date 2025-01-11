/**
 * This file was auto-generated by openapi-typescript.
 * Do not make direct changes to the file.
 */

export interface paths {
    "/api/Users/{id}": {
        parameters: {
            query?: never;
            header?: never;
            path?: never;
            cookie?: never;
        };
        get: {
            parameters: {
                query?: never;
                header?: never;
                path: {
                    id: number;
                };
                cookie?: never;
            };
            requestBody?: never;
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content: {
                        "text/plain": components["schemas"]["User"];
                        "application/json": components["schemas"]["User"];
                        "text/json": components["schemas"]["User"];
                    };
                };
            };
        };
        put?: never;
        post?: never;
        delete?: never;
        options?: never;
        head?: never;
        patch?: never;
        trace?: never;
    };
    "/api/Users": {
        parameters: {
            query?: never;
            header?: never;
            path?: never;
            cookie?: never;
        };
        get: {
            parameters: {
                query?: never;
                header?: never;
                path?: never;
                cookie?: never;
            };
            requestBody?: never;
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content: {
                        "text/plain": components["schemas"]["UserResponse"][];
                        "application/json": components["schemas"]["UserResponse"][];
                        "text/json": components["schemas"]["UserResponse"][];
                    };
                };
            };
        };
        put?: never;
        post: {
            parameters: {
                query?: never;
                header?: never;
                path?: never;
                cookie?: never;
            };
            requestBody?: {
                content: {
                    "application/json": components["schemas"]["UserRequest"];
                    "text/json": components["schemas"]["UserRequest"];
                    "application/*+json": components["schemas"]["UserRequest"];
                };
            };
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content?: never;
                };
            };
        };
        delete?: never;
        options?: never;
        head?: never;
        patch?: never;
        trace?: never;
    };
    "/api/Users/login/sendUserEmail": {
        parameters: {
            query?: never;
            header?: never;
            path?: never;
            cookie?: never;
        };
        get?: never;
        put?: never;
        post: {
            parameters: {
                query?: never;
                header?: never;
                path?: never;
                cookie?: never;
            };
            requestBody?: {
                content: {
                    "application/json": components["schemas"]["UserRequest"];
                    "text/json": components["schemas"]["UserRequest"];
                    "application/*+json": components["schemas"]["UserRequest"];
                };
            };
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content?: never;
                };
            };
        };
        delete?: never;
        options?: never;
        head?: never;
        patch?: never;
        trace?: never;
    };
    "/api/Users/register/sendUserEmail": {
        parameters: {
            query?: never;
            header?: never;
            path?: never;
            cookie?: never;
        };
        get?: never;
        put?: never;
        post: {
            parameters: {
                query?: never;
                header?: never;
                path?: never;
                cookie?: never;
            };
            requestBody?: {
                content: {
                    "application/json": components["schemas"]["UserRequest"];
                    "text/json": components["schemas"]["UserRequest"];
                    "application/*+json": components["schemas"]["UserRequest"];
                };
            };
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content?: never;
                };
            };
        };
        delete?: never;
        options?: never;
        head?: never;
        patch?: never;
        trace?: never;
    };
    "/api/Wishes/{id}": {
        parameters: {
            query?: never;
            header?: never;
            path?: never;
            cookie?: never;
        };
        get: {
            parameters: {
                query?: never;
                header?: never;
                path: {
                    id: number;
                };
                cookie?: never;
            };
            requestBody?: never;
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content: {
                        "text/plain": components["schemas"]["Wish"];
                        "application/json": components["schemas"]["Wish"];
                        "text/json": components["schemas"]["Wish"];
                    };
                };
            };
        };
        put: {
            parameters: {
                query?: never;
                header?: never;
                path: {
                    id: string;
                };
                cookie?: never;
            };
            requestBody?: {
                content: {
                    "application/json": components["schemas"]["WishResponseList"];
                    "text/json": components["schemas"]["WishResponseList"];
                    "application/*+json": components["schemas"]["WishResponseList"];
                };
            };
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content: {
                        "text/plain": components["schemas"]["WishResponseList"];
                        "application/json": components["schemas"]["WishResponseList"];
                        "text/json": components["schemas"]["WishResponseList"];
                    };
                };
            };
        };
        post?: never;
        delete: {
            parameters: {
                query?: never;
                header?: never;
                path: {
                    id: number;
                };
                cookie?: never;
            };
            requestBody?: never;
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content?: never;
                };
            };
        };
        options?: never;
        head?: never;
        patch?: never;
        trace?: never;
    };
    "/api/Wishes": {
        parameters: {
            query?: never;
            header?: never;
            path?: never;
            cookie?: never;
        };
        get: {
            parameters: {
                query?: never;
                header?: never;
                path?: never;
                cookie?: never;
            };
            requestBody?: never;
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content: {
                        "text/plain": components["schemas"]["WishResponseList"];
                        "application/json": components["schemas"]["WishResponseList"];
                        "text/json": components["schemas"]["WishResponseList"];
                    };
                };
            };
        };
        put?: never;
        post: {
            parameters: {
                query?: never;
                header?: never;
                path?: never;
                cookie?: never;
            };
            requestBody?: {
                content: {
                    "application/json": components["schemas"]["WishRequest"];
                    "text/json": components["schemas"]["WishRequest"];
                    "application/*+json": components["schemas"]["WishRequest"];
                };
            };
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content?: never;
                };
            };
        };
        delete?: never;
        options?: never;
        head?: never;
        patch?: never;
        trace?: never;
    };
    "/api/Wishes/purchase/{id}": {
        parameters: {
            query?: never;
            header?: never;
            path?: never;
            cookie?: never;
        };
        get?: never;
        put: {
            parameters: {
                query?: never;
                header?: never;
                path: {
                    id: number;
                };
                cookie?: never;
            };
            requestBody?: never;
            responses: {
                /** @description OK */
                200: {
                    headers: {
                        [name: string]: unknown;
                    };
                    content: {
                        "text/plain": components["schemas"]["WishResponseList"];
                        "application/json": components["schemas"]["WishResponseList"];
                        "text/json": components["schemas"]["WishResponseList"];
                    };
                };
            };
        };
        post?: never;
        delete?: never;
        options?: never;
        head?: never;
        patch?: never;
        trace?: never;
    };
}
export type webhooks = Record<string, never>;
export interface components {
    schemas: {
        User: {
            /** Format: int32 */
            id?: number;
            name: string | null;
            wishedWishes?: components["schemas"]["Wish"][] | null;
            purchasedWishes?: components["schemas"]["Wish"][] | null;
        };
        UserRequest: {
            name: string | null;
        };
        UserResponse: {
            name?: string | null;
            wishedWishes?: components["schemas"]["WishResponse"][] | null;
            purchasedWishes?: components["schemas"]["WishResponse"][] | null;
        };
        Wish: {
            /** Format: int32 */
            id?: number;
            name: string | null;
            description?: string | null;
            /** Format: double */
            price: number;
            webPageLink?: string | null;
            /** Format: int32 */
            wisherId: number;
            /** Format: int32 */
            purchaserId?: number | null;
            wisher?: components["schemas"]["User"];
            purchaser?: components["schemas"]["User"];
        };
        WishRequest: {
            name: string | null;
            description?: string | null;
            /** Format: double */
            price: number;
            webPageLink?: string | null;
            /** Format: int32 */
            wisherId?: number | null;
            /** Format: int32 */
            purchaserId?: number | null;
        };
        WishResponse: {
            name?: string | null;
            description?: string | null;
            /** Format: double */
            price?: number;
            webPageLink?: string | null;
        };
        WishResponseList: {
            /** Format: int32 */
            id?: number;
            name: string | null;
            description?: string | null;
            /** Format: double */
            price: number;
            webPageLink?: string | null;
            /** Format: int32 */
            purchaserId?: number | null;
        };
    };
    responses: never;
    parameters: never;
    requestBodies: never;
    headers: never;
    pathItems: never;
}
export type $defs = Record<string, never>;
export type operations = Record<string, never>;
