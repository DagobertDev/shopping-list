import { useState } from 'react'
import './App.css'

function App() {

  const [listItems, setListItems] = useState(["Milk", "Oats", "Onions"])

  const list = listItems.map(item => <li>{item}</li>)

  return (
    <>
      <h1>ShopList</h1>
      <ul>
        {list}
      </ul>
    </>
  )
}

export default App
