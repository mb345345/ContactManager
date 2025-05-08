import { Routes, Route } from 'react-router-dom'
import Sidebar from './components/Sidebar'
import Home from './pages/Home'
import ManageCompanies from './pages/ManageCompanies'
import ManageContacts from './pages/ManageContacts'
import './App.css'

function App() {
  return (
    <div className="app-container">
      <Sidebar />
      <div className="main-content">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/companies" element={<ManageCompanies />} />
          <Route path="/contacts" element={<ManageContacts />} />
        </Routes>
      </div>
    </div>
  )
}

export default App
