import React, { Component } from 'react';
import { Button } from 'react-bootstrap';

export class EditButton extends Component {
    render() {
        return (
            <Button type="button" variant="primary" onFocus={() => this.props.managerIdChange(this.props.managerId)} onClick={() => { this.props.editManager(this.props.managerId) }}>Edit</Button>
        )
    }
}