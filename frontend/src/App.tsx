import { Route, Routes } from 'react-router'
import './App.css'
import ItemList from './components/ItemList'

function App() {
  return (
    <Routes>
      <Route path="/" element={<ItemList />} />
    </Routes>
  )
}

export default App
