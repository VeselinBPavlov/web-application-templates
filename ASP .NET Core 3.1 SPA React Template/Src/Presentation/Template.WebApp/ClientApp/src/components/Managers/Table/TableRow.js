import React, { Component } from 'react';
import { EditButton } from '../Table/EditButton';
import { DeleteButton } from '../Table/DeleteButton';

export class TableRow extends Component {
    render() {
        return (
            <tr>
                <td>{this.props.manager.firstName}</td>
                <td>{this.props.manager.lastName}</td>
                <td>{this.props.manager.receptionDay}</td>
                <td ><EditButton managerIdChange={this.props.managerIdChange} editManager={this.props.editManager} managerId={this.props.manager.id} /> <DeleteButton deleteManager={this.props.deleteManager} managerId={this.props.manager.id} /></td>
            </tr>
        )
    }
}