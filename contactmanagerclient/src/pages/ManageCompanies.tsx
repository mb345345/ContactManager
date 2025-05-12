import { useEffect, useState } from 'react';
import axios from 'axios';

interface Company {
    companyId: number;
    companyName: string;
}

function ManageCompanies () {
    const [companies, setCompanies] = useState<Company[]>([]);

    useEffect(() => {
        axios.get<Company[]>('https://localhost:7183/readcompanies')
          .then(response => setCompanies(response.data))
          .catch(error => console.error('Error fetching companies:', error));
      }, []);

      return (
        <div>
            <h2>Manage Companies</h2>
            <div className="results-table-container">
                <table className="results-table">
                    <thead>
                    <tr>
                        <th colSpan={2}>
                        <a href="#" className="add-link">Add Company</a>
                        </th>
                    </tr>
                    </thead>
                    <tbody>
                    {companies.map((company, index) => (
                        <tr key={index}>
                            <td className="content">{company.companyName}</td>
                            <td className="link-column">[&nbsp;<a href="#" className="edit-link">Edit</a>&nbsp;]</td>
                        </tr>
                    ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default ManageCompanies