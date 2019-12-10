import React, { Component, Fragment } from 'react';
import { CreateForm } from './Form/CreateForm';
import { TableManagers } from './Table/TableManagers';
import { getAllManagers } from '../../sevices/manager-service';

export class Managers extends Component {

    constructor() {
        super();

        this.state = {
            managers: [],
            managerId: "",
            loading: true
        };
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderManagersTable(this.state.managers);

        return (
            <div>
                {contents}
            </div>
        );
    }

    renderManagersTable(data) {
        return (
            <Fragment>
                <h2>Managers</h2>
                <br />

                <CreateForm
                    refresh={this.populateManagersData}
                    ref={instance => { this.createForm = instance; }}
                    managerId={this.state.managerId}
                />

                <TableManagers
                    managerIdChange={this.onManagerIdChange}
                    editManager={() => this.createForm.fillInputs(this.state.managerId)}
                    reset={() => this.createForm.cancel()}
                    refresh={this.populateManagersData}
                    data={data}
                />
            </Fragment>
        );
    }

    // Lifecycle methods.
    componentDidMount() {
        this.populateManagersData();
    }

    // State change methods.
    populateManagersData = () => {
        getAllManagers()
            .then(data => {
                this.setState({ managers: data, loading: false });
                console.log(data)
                console.log(this.state.managers)
            } );
    }

    onManagerIdChange = (id) => {
        this.setState({
            managerId: id
        });

        console.log("Change")
    }
}