import React, { Component } from 'react';
import { Table, Button } from 'reactstrap';
import { API_URL } from '../constants';

class TableNames extends Component {

state = {
    on: false,
    table: []
}


// setToggleData(e){
//     this.getTable(e.target.id);
//     this.toggle();
// }

getTable = (e) => {
    this.setState({table: []});
    fetch(`${API_URL}/data/${e.target.id}`)
    .then(res => res.json())
    .then(res => this.setState({ table: res }))
    .catch(err => console.log(err));
    this.toggleOn();
}

toggleOn = () => {
    this.setState({
        on: true
    })
    document.getElementById("wrapper").style = "margin-top: 15px;"
}

toggleOff = () => {
    this.setState({
        on: false
    })
    document.getElementById("wrapper").style = "margin-top: 10%;"
}
  
render() {
  const allItems = this.props.allItems;
  const table = this.state.table;

  return <div>
      <div>
    {!allItems || allItems.length <= 0 ?
    <a>There are no tabels.</a>
    : <div className='tablenames'>
      <a class="tablesTitle">Tables:</a>
      {
    allItems.map(allitem =>(

        <button class="tableName" id={allitem.name} onClick={this.getTable}>{allitem.name}</button>
    ))}
    </div>
    }
    {/* toggle */}
    {this.state.on && (
       <div id="toggleTable">
       {!table || table.length <= 0 ?
         <a></a>
       :<table striped>
           <thead className="thead-dark">
     
       {table.slice(0,1).map(item => (
     
     
               <tr class="active-row">
               {Object.keys(item).map(function(key)
                 { return <th>{key}</th>;})}
               </tr>
               ))}
           </thead>
           <tbody>
             {table.map(item => (
               <tr>
                 {Object.keys(item).map(function(key)
                   { return <td>{item[key]}</td>;})}
               </tr>
             ))}
           </tbody>
        </table>}
        
        </div>
   )}
    {/* closebutton */}
    {this.state.on && (<div className='closeDiv'><button class="closeButton" onClick={this.toggleOff}>^</button></div>)}
</div>
</div>
}
}

export default TableNames;