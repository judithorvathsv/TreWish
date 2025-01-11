import { Link, useLocation } from "@tanstack/react-router";

const NavBar = () => {
  const location = useLocation();

  if (location.pathname === "/") {
    return null;
  }

  return (
    <>
      <div>
        <Link to="/wishList">Home</Link>
      </div>
      <div>
        <Link to="/statistics">Statistics</Link>
      </div>
      <div>
        <Link to="/purchasedWishList">Purchased Wishes List</Link>
      </div>
    </>
  );
};

export default NavBar;
