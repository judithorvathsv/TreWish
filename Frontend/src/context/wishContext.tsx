import { ReactElement, createContext, useState } from "react";
import { WishProps } from "../types";

interface IWishContext {
  wish: WishProps | null;
  setWish: React.Dispatch<React.SetStateAction<WishProps | null>>;
}

const defaultContextValue: IWishContext = {
  wish: null,
  setWish: () => {},
};

export const WishContext = createContext<IWishContext>(defaultContextValue);

interface IWishContextProvider {
  children: ReactElement;
}

export function WishContextProvider({ children }: IWishContextProvider): ReactElement {
  const [wish, setWish] = useState<WishProps | null>(null);

  const values: IWishContext = {
    wish,
    setWish,
  };

  console.log(wish, 'wish from CONTEXT')

  return <WishContext.Provider value={values}>{children}</WishContext.Provider>;
}


