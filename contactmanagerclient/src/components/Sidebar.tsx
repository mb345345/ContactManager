import { Link } from 'react-router-dom'
import './Sidebar.css'

const Sidebar = () => {
  return (
    <div className="sidebar">
      <h2>Contacts App</h2>
      <nav>
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/companies">Manage Companies</Link></li>
          <li><Link to="/contacts">Manage Contacts</Link></li>
        </ul>
      </nav>
    </div>
  )
}

export default Sidebar
