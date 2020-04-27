import React, { Component } from 'react';
import { Col, Container, Row } from 'reactstrap';
import DataTable from './DataTable';
import InputForm from './form/InputForm';

import { API_URL } from '../constants';

class Home extends Component {

  state = {
    items: []
  }

  componentDidMount() {
    this.getItens();
  }

  getItens = () => {
    fetch(`${API_URL}/data`)
      .then(res => res.json())
      .then(res => this.setState({ items: res }))
      .catch(err => console.log(err));
  }

  addRecordToState = record => {
    this.setState(previous => ({
      items: [...previous.items, record]
    }));
  }

  updateState = (id) => {
    this.getItens();
  }

  deleteItemFromState = id => {
    const updated = this.state.items.filter(item => item.id !== id);
    this.setState({ items: updated })
  }

  render() {
    return <Container style={{ paddingTop: "100px" }}>
      <Row>
        <Col>
        <InputForm
                        addRecordToState={this.addRecordToState}
                        updateRecordIntoState={this.updateRecordIntoState}
                        toggle={this.toggle}
                        user={this.user} />
        </Col>
      </Row>
      <Row>
        <Col>
          <DataTable
            items={this.state.items}
            updateState={this.updateState}
            deleteItemFromState={this.deleteItemFromState} />
        </Col>
      </Row>
    </Container>;
  }
}

export default Home;
