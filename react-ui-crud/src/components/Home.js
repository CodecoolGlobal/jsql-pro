import React, { Component } from 'react';
import { Col, Container, Row } from 'reactstrap';
import DataTable from './DataTable';
import TableNames from './TableNames';
import InputForm from './form/InputForm';
import Toolbar from './Toolbar';

import { API_URL } from '../constants';

class Home extends Component {

  state = {
    items: [],
    allItems: []
  }

  componentDidMount() {
    this.getItems();
  }

  getItems = () => {
    fetch(`${API_URL}/select`)
      .then(res => res.json())
      .then(res => this.setState({ items: res }))
      .catch(err => console.log(err));

      fetch(`${API_URL}/data`)
      .then(res => res.json())
      .then(res => this.setState({ allItems: res }))
      .catch(err => console.log(err));
  }


  render() {
    return <Container>
        <TableNames
         allItems={this.state.allItems}
        />
        <Toolbar/>
        <div id="wrapper">
          <InputForm/>
          <DataTable
            items={this.state.items}
            updateState={this.updateState}
            deleteItemFromState={this.deleteItemFromState} />
        </div>
    </Container>;
  }
}

export default Home;
