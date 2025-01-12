import { ReactElement, createContext, useState } from "react";
import { WishProps } from "../types";

interface IWishContext {
  wish: WishProps | null;
  setWish: React.Dispatch<React.SetStateAction<WishProps | null>>;
  refreshWishList: () => void;
}

const defaultContextValue: IWishContext = {
  wish: null,
  setWish: () => {},
  refreshWishList: () => {},
};

export const WishContext = createContext<IWishContext>(defaultContextValue);

interface IWishContextProvider {
  children: ReactElement;
}

export function WishContextProvider({ children }: IWishContextProvider): ReactElement {
  const [wish, setWish] = useState<WishProps | null>(null);
  const [stateForRefresh, setStateForRefresh] = useState(false);

  console.log(stateForRefresh);

  const refreshWishList = () => {
    setStateForRefresh(prev => !prev);  
  };

  const values: IWishContext = {
    wish,
    setWish,
    refreshWishList, 
  };

  return <WishContext.Provider value={values}>{children}</WishContext.Provider>;
}


