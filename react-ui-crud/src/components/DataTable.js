import React, { Component } from 'react';
import { Table, Button } from 'reactstrap';
import { API_URL } from '../constants';

class DataTable extends Component {

  deleteItem = id => {
    let confirmDeletion = window.confirm('Do you really wish to delete it?');
    if (confirmDeletion) {
      fetch(`${API_URL}/${id}`, {
        method: 'delete',
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(res => {
          this.props.deleteItemFromState(id);
        })
        .catch(err => console.log(err));
    }
  }

  render() {
    const items = this.props.items;
    return <Table striped>
      <thead className="thead-dark">
        <tr>
          <th>AGE</th>
          <th>Name</th>
          <th>NICKNAME</th>
          <th>SEX</th>
        </tr>
      </thead>
      <tbody>
        {!items || items.length <= 0 ?
          <tr>
            <td colSpan="6" align="center"><b>No Users yet</b></td>
          </tr>
          : items.map(item => (
            <tr>
        
              <td>
                {item.age}
              </td>
              <td>
                {item.name}
              </td>
              <td>
                {item.nickname}
              </td>
              <td>
                {item.sex}
              </td>
            </tr>
          ))}
      </tbody>
    </Table>;
  }
}

export default DataTable;
