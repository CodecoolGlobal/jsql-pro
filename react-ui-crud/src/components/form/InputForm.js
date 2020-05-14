import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';

import { API_URL } from '../../constants';

class InputForm extends React.Component {

    state = {
        name: ''
    }

    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitNew = e =>{

        fetch(`${API_URL}`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name
            })
        })
        
    }

    render() {
        return <Form onSubmit={this.submitNew}>
            <FormGroup>
                <Label for="name">SQL goes here:</Label>
                <Input type="text" name="name" onChange={this.onChange} value={this.state.name === '' ? '' : this.state.name} />
            </FormGroup>
        </Form>;
    }
}

export default InputForm;