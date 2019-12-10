import React, { Component } from 'react';
import { Select } from './Select';
import { Input } from '../../../shared/Form/Input';
import { SubmitButton } from '../../../shared/Form/SubmitButton';
import authService from '../../api-authorization/AuthorizeService';
import { getManager } from '../../../sevices/manager-service';
import { createManager } from '../../../sevices/manager-service';
import { updateManager } from '../../../sevices/manager-service';
import { Container, Row, Col, Button, Form } from 'react-bootstrap';

export class CreateForm extends Component {
    constructor() {
        super()

        this.state = {
            fisrtName: "",
            lastName: "",
            receptionDay: '',
            isCreate: true,
            userId: ""
        }
    }

    render() {
        return (
            <Container>
                <Row>
                    <Form onSubmit={this.state.isCreate ? this.create : this.update}>
                        <Form.Row>
                            <Form.Group as={Col} md="3">
                                <Input
                                    ref={firstName => this.firstName = firstName}
                                    type='text'
                                    data='firstName'
                                    name='First Name'
                                    func={e => { this.setState({ firstName: e.target.value }) }}                     
                                />
                            </Form.Group>   
                            <Form.Group as={Col} md="3">
                                <Input
                                    ref={lastName => this.lastName = lastName}
                                    type='text'
                                    data='lastName'
                                    name='Last Name'
                                    func={e => { this.setState({ lastName: e.target.value }) }}
                                />
                            </Form.Group>  
                            <Form.Group as={Col} md="3">
                                <Select
                                    ref={receptionDay => this.receptionDay = receptionDay}
                                    data="receptionDay"
                                    name='Reception Day'
                                    func={e => { this.setState({ receptionDay: e.target.value }) }}                                  
                                >
                                </Select>
                            </Form.Group>                            
                            <Form.Group as={Col} md="3">
                                <SubmitButton
                                    clearInputs={this.clearInputs}
                                    isCreate={this.state.isCreate}
                                />
                                <Button className='cancel' onClick={this.cancel}>Cancel</Button>
                            </Form.Group>
                        </Form.Row>
                    </Form>
                </Row>
            </Container>            
        )
    }

    // Lifecycle methods.
    componentDidMount() {
        authService
            .getUser()
            .then(user => {
                this.setState({
                    userId: user.sub
                });
            });
    }    

    // State change methods.
    fillInputs = id => {
        getManager(id)
            .then(income => {
                this.updateState(income);
                this.fillFields();
                this.setState({ isCreate: false });
            });
    }

    create = event => {
        event.preventDefault();
        let payload = this.getPayload();

        createManager(payload)
            .then((res) => {
                if (res) {
                    this.fillFields();
                } else {
                    this.resetState();
                    this.props.refresh();
                }
            });
    }

    update = event => {
        event.preventDefault();
        let payload = this.getPayload();

        updateManager(payload)
            .then((res) => {
                if (res) {
                    this.fillFields();
                } else {
                    this.resetState();
                    this.props.refresh();
                }
            });
    }

    resetState = () => {
        this.setState({
            firstName: '',
            lastName: '',
            receptionDay: '',
            isCreate: true
        });
    }

    updateState = manager => {
        this.setState({
            firstName: manager.firstName,
            lastName: manager.lastName,
            receptionDay: manager.receptionDay,
            isCreate: false
        });
    }

    // Helper methods.
    clearInputs = () => {
        this.firstName.clear();
        this.lastName.clear();
        this.receptionDay.clear();
    }

    fillFields = () => {
        this.firstName.fill(this.state.firstName);
        this.lastName.fill(this.state.lastName);
        this.receptionDay.fill(this.state.receptionDay);
    }

    getPayload = () => {
        let payload = {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            receptionDay: this.state.receptionDay,
            userId: this.state.userId,
            id: this.props.managerId
        }

        return payload;
    }

    cancel = () => {
        this.clearInputs();
        this.resetState();
    }
}