import React from 'react';
import ReactDOM from 'react-dom';
import {Panel} from 'react-bootstrap'

export default class MainPanel extends React.Component{
    render(){
        return(
            <Panel bsStyle="primary">            
                <Panel.Body> 
                {this.props.body}
                </Panel.Body>                            
            </Panel>
        );
    }
}