import React, { Component } from 'react';
import { Table, Button } from 'reactstrap';
import { API_URL } from '../constants';

class DataTable extends Component {

render() {
  const items = this.props.items;
  const allItems = this.props.allItems;

  return <div>
  <div>
    {!allItems || allItems.length <= 0 ?
    <p>There are no tabels.</p>
    : <div>
      <td>Tables:</td>
      {
    allItems.map(allitem =>(

        <td>
        <p>&nbsp;&nbsp;{allitem.name}</p>

        </td>
    ))}
    </div>
    }
  </div>
  <div>{!items || items.length <= 0 ?
    <p></p>
  :<table striped>
      <thead className="thead-dark">

  {items.slice(0,1).map(item => (


          <tr class="active-row">
          {Object.keys(item).map(function(key)
            { return <th>{key}</th>;})}
          </tr>
          ))}
      </thead>
      <tbody>
        {items.map(item => (
          <tr>
            {Object.keys(item).map(function(key)
              { return <td>{item[key]}</td>;})}
          </tr>
        ))}
      </tbody>
   </table>}
   </div>
   </div>
}
}

export default DataTable;


//WORKING RENDER all tables!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


// class DataTable extends Component {

//   render() {
//     const items = this.props.items;

//     return <div>
//     {items.map(item => (
//       <div>
//       <h1>{item.name}</h1>
//       <Table striped>
//         <thead className="thead-dark">
//           {item.deserialisedRecords.slice(0,1).map(srec => (
//             <tr>
//             {Object.keys(srec).map(function(key)
//               { return <th>{key}</th>;})}
//             </tr>
//             ))}
//         </thead>
//         <tbody>
//           {item.deserialisedRecords.map(srec => (
//             <tr>
//               {Object.keys(srec).map(function(key)
//                 { return <td>{srec[key]}</td>;})}
//             </tr>
//           ))}
//         </tbody>
//      </Table>
//      </div>
//     ))}
//     </div>
//   }
// }

//WORKING RENDER all tables!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



// render() {
//   const items = this.props.items;
//   return (
//     <div>
//       <h1>hello</h1>
//       <tr>
//         {
//           items.map(item => (
//             <p>
//               {item.deserialisedRecords}
//             {/* {Object.keys(item.deserialisedRecords[0]).map(function(key)
//             { return <div>
//               Key: {key}, Value: {item.deserialisedRecords[0][key]}
//               </div>;
//              })} */}
//             </p>
//               ))

//         }
//       </tr>
//       </div>
//   )
// }
  // deleteItem = id => {
  //   let confirmDeletion = window.confirm('Do you really wish to delete it?');
  //   if (confirmDeletion) {
  //     fetch(`${API_URL}/${id}`, {
  //       method: 'delete',
  //       headers: {
  //         'Content-Type': 'application/json'
  //       }
  //     })
  //       .then(res => {
  //         this.props.deleteItemFromState(id);
  //       })
  //       .catch(err => console.log(err));
  //   }
  // }


// EZEGESZENJOVOLT
  // render() {
  //   const items = this.props.items;
  //   return <div>
  // <h2>valami {items.length}</h2>
  //   {items.map(item => (
  //    <p> {item.name}</p>
  //   ))}
  //   </div>
  // }
//     const items = this.props.items;
//     return <Table striped>
//       {/* <thead className="thead-dark">
//         <tr>
//           <th>AGE</th>
//           <th>Name</th>
//           <th>NICKNAME</th>
//           <th>SEX</th>
//         </tr>
//       </thead> */}
//       <tbody>
//         {!items || items.length <= 0 ?
//           <tr>
//             <td colSpan="6" align="center"><b>No Users yet</b></td>
//           </tr>
//           : items.map(function(item, index){
//             return index
//           })
//           // : items.map(item => (
//           //   <tr>

//           //     <td>
//           //       {item.age}
//           //     </td>
//           //     <td>
//           //       {item.name}
//           //     </td>
//           //     <td>
//           //       {item.nickname}
//           //     </td>
//           //     <td>
//           //       {item.sex}
//           //     </td>
//           //   </tr>
//           }
//       </tbody>
//     </Table>;
//   }
// }