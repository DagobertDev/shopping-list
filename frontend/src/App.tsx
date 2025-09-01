import { useEffect, useState } from 'react'
import './App.css'
import ListItem from './ListItem'

function App() {

  const itemsURL = "http://localhost:5157/shoppingitem"

  const [listItems, setListItems] = useState<string[]>([])  
  const [newItem, setNewItem] = useState("")

  const loadItems = () => {
    fetch(itemsURL)
      .then(result => result.json())
      .then(items => setListItems(items.map(item => item.name)))
      .catch(error => console.error("Failed to fetch items", error))
  }

  useEffect(loadItems, [])

  const addItem = () => {
    fetch(itemsURL, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({name: newItem}),
    })
      .then(() => {
        loadItems()
        setNewItem("")
      })
      .catch(error => console.error("Failed to add item", error))
  }

  const removeItem = (removedItem: string) => {
    setListItems((items => items.filter(item => item !== removedItem)));
  }

  const list = listItems.map(item => <ListItem name={item} deleteItem={() => removeItem(item)}/>)

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
