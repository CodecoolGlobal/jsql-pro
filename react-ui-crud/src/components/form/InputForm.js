import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';

import { API_URL } from '../../constants';

class InputForm extends React.Component {

    state = {
        id: 0,
        name: ''
    }

    componentDidMount() {
        if (this.props.record) {
            const { id, name} = this.props.record
            this.setState({ id, name});
        }
    }

    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitNew = e => {
        e.preventDefault();
        fetch(`${API_URL}`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name
            })
        })
            .then(res => res.json())
            .then(record => {
                this.props.addRecordToState(record);
                this.props.toggle();
            })
            .catch(err => console.log(err));
    }

    submitEdit = e => {
        e.preventDefault();
        fetch(`${API_URL}/${this.state.id}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name
            })
        })
            .then(() => {
                this.props.toggle();
                this.props.updateRecordIntoState(this.state.id);
            })
            .catch(err => console.log(err));
    }

    render() {
        return <Form onSubmit={this.props.user ? this.submitEdit : this.submitNew}>
            <FormGroup>
                <Label for="name">SQL goes here:</Label>
                <Input type="text" name="name" onChange={this.onChange} value={this.state.name === '' ? '' : this.state.name} />
            </FormGroup>
        </Form>;
    }
}

export default InputForm;