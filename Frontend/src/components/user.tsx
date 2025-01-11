import { StatisticsUserResponseProps } from "../types"

const User = ({name, wishedWishes, purchasedWishes}: StatisticsUserResponseProps) => {
  return (
    <div>
      <p>Name: <b>{name}</b></p> 
      <p>Number of wished item: {wishedWishes}</p>
      <p>Number of purchased items: {purchasedWishes}</p>
    </div>
  )
}

export default User
