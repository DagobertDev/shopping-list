import { useState } from 'react'
import './App.css'

function App() {

  const [listItems, setListItems] = useState(["Milk", "Oats", "Onions"])

  const list = listItems.map(item => <li>{item}</li>)

  const [newItem, setNewItem] = useState("")

  const addItem = () => {
      setListItems([...listItems, newItem]);
      setNewItem("");
  }

  return (
    <>
      <h1>ShopList</h1>
      <ul>
        {list}
      </ul>
      <input type='text' value={newItem} onChange={e => setNewItem(e.target.value)}/>
      <button onClick={addItem}>Add</button>
    </>
  )
}

export default App
