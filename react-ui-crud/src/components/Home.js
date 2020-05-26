import React, { Component } from 'react';
import { Col, Container, Row } from 'reactstrap';
import DataTable from './DataTable';
import InputForm from './form/InputForm';

import { API_URL } from '../constants';

class Home extends Component {

  state = {
    items: [],
    allItems: []
  }

  componentDidMount() {
    this.getItens();
  }

  getItens = () => {
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
    return <Container style={{ paddingTop: "100px" }}>
      <Row>
        <Col>
        <InputForm/>
        </Col>
      </Row>
      <Row>
        <Col>
          <DataTable
          allItems={this.state.allItems}
            items={this.state.items}
            updateState={this.updateState}
            deleteItemFromState={this.deleteItemFromState} />
        </Col>
      </Row>
    </Container>;
  }
}

export default Home;
