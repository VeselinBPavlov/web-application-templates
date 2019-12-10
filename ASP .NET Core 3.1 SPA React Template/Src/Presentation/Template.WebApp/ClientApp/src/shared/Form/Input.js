import React, { Component } from 'react'
import { Form } from 'react-bootstrap';

export class Input extends Component {

    render() {
        return (
            <Form.Control
                ref={input => this.input = input}
                onChange={(e) => this.props.func(e)}
                id={this.props.data}
                name={this.props.data}
                type={this.props.type}
                placeholder={this.props.name}
                style={{ border: '1px solid #0062cc' }}
                autoComplete="off"
            />
        )
    }

    clear() {
        this.input.value = '';
    }

    fill(value) {
        this.input.value = value;
    }
}
