import React, { Component } from 'react';
import { Button } from 'react-bootstrap';

export class DeleteButton extends Component {
    render() {
        return (
            <Button type="button" variant="danger" onClick={() => this.props.deleteManager(this.props.managerId)}>Delete</Button>
        )
    }
}