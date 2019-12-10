import React, { Component } from 'react';
import { Form } from 'react-bootstrap';

export class Select extends Component {
    constructor() {
        super()

        this.state = {
            selectedValue: "",
            options: [
                { id: 1, day: "Monday" },
                { id: 2, day: "Tuseday" },
                { id: 3, day: "Wednesday" },
                { id: 4, day: "Thursday" },
                { id: 5, day: "Friday" } 
            ]
        }
    }

    render() {
        return (
            <Form.Control as="select"
                defaultValue={this.state.selectedValue}
                ref={option => this.option = option}
                className="form-control col-md-12"
                onChange={(e) => this.props.func(e)}
                id={this.props.data}
                name={this.props.data}
                style={{ border:'1px solid #0062cc'}}
            >
                <option value="" key="0" disabled>Select Reception Day</option>
                {this.state.options.map(option =>
                    <option key={option.id} value={option.id}>{option.day}</option>)}
            </Form.Control>
        )
    }
    
    // Helper methods.
    clear() {
        this.option.value = "";
    }

    fill(id) {
        this.option.value = id;
    }
}