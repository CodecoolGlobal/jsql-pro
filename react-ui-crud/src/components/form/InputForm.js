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
        return <div class="sqlFormDiv">
        <Form onSubmit={this.submitNew} class="sqlForm">
                    <textarea id="sqlTextArea" name="name" rows="4" placeholder="SQL goes here" required
                     onChange={this.onChange} value={this.state.name === '' ? '' : this.state.name}>
                    </textarea><br/>
                    <input type="submit" value="submit"></input>
        </Form>
        </div>

    }
}

export default InputForm;