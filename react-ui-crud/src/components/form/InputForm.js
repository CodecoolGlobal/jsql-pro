import React from 'react';
import {Button, Form, FormGroup, Input, Label} from 'reactstrap';

import {API_URL} from '../../constants';

class InputForm extends React.Component {

    state = {
        name: ''
    }

    onChange = e => {
        this.setState({[e.target.name]: e.target.value})
    }

    submitNew = e => {

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
                <div class="form__group field">
                    <input type="input" class="form__field" placeholder="SQL goes here" name="name" id='name' required
                           onChange={this.onChange} value={this.state.name === '' ? '' : this.state.name}/>
                    <label for="name" class="form__label">SQL goes here:</label>
                    <p>Please append a semicolon ";" at the end of the query to avoid error.</p>
                </div>
            </FormGroup>
        </Form>;
    }
}

export default InputForm;