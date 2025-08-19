import { useState } from 'react'
import './App.css'
import ListItem from './ListItem'

function App() {

  const [listItems, setListItems] = useState(["Milk", "Oats", "Onions"])

  const addItem = () => {
      setListItems([...listItems, newItem]);
      setNewItem("");
  }

  const removeItem = (removedItem: string) => {
      setListItems((items => items.filter(item => item !== removedItem)));
  }

  const list = listItems.map(item => <ListItem name={item} deleteItem={() => removeItem(item)}/>)

  const [newItem, setNewItem] = useState("")

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
