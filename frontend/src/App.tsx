import { Link, Route, Routes } from 'react-router'
import './App.css'
import ItemList from './components/ItemList'
import NotFound from './components/NotFound'
import Login from './components/Login'

function App() {
  return (
    <>
      <nav>
        <Link to="/">Home</Link>
        <Link to="/Login">Login</Link>
      </nav>

      <Routes>
        <Route path="/" element={<ItemList />} />
        <Route path="/Login" element={<Login />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
    </>
  )
}

export default App
