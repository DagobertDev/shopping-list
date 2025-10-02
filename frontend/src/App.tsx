import { Route, Routes } from 'react-router'
import './App.css'
import ItemList from './components/ItemList'
import NotFound from './components/NotFound'

function App() {
  return (
    <Routes>
      <Route path="/" element={<ItemList />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  )
}

export default App
