import React, { Component } from 'react';
import { TableRow } from './TableRow';
import { deleteManager } from '../../../sevices/manager-service';
import { Table } from 'react-bootstrap';

export class TableManagers extends Component {
    render() {
        return (
            <Table striped hover responsive="sm">
                <thead className='thead-dark'>
                    <tr className="centered">
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Reception Day</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.data.managers.map(manager =>
                        <TableRow
                            key={manager.id}
                            manager={manager}
                            managerIdChange={this.props.managerIdChange}
                            editManager={this.props.editManager}
                            deleteManager={this.delete}
                            reset={this.props.reset}
                        />                        
                    )}
                </tbody>
            </Table>
        )
    }

    delete = id => {
        deleteManager(id)
            .then(() => {
                this.props.refresh();
                this.props.reset();
            })
    }
}