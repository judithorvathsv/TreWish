import { Link } from '@tanstack/react-router'

const NavBar = () => {
  return (
    <>
      <div>             
        <Link to="/statistics">Statistics</Link>
      </div>
      <div>             
        <Link to="/purchasedWishList">Purchased Wishes List</Link>
      </div>
    </>
  )
}

export default NavBar
