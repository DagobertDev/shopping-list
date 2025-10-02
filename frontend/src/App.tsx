import { NavLink, Route, Routes } from 'react-router'
import './App.css'
import ItemList from './components/ItemList'
import NotFound from './components/NotFound'
import Login from './components/Login'

function App() {
  return (
    <>
      <nav className="navbar">
        <NavLink to="/">Home</NavLink>
        <NavLink to="/login">Login</NavLink>
      </nav>

      <div className="content">
        <Routes>
          <Route path="/" element={<ItemList />} />
          <Route path="/login" element={<Login />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </div>
    </>
  )
}

export default App
