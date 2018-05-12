import React from 'react';
import ReactDOM from 'react-dom';
import {Panel} from 'react-bootstrap'
import {Switch, Route} from 'react-router-dom'
import SeanceList from './SeanceList'
import FilmsList from './FilmsList';
import UserPanel from './UserPanel';
import Welcome from './Welcome';
import Information from './Information';

export default class MainPanel extends React.Component{
    render(){
        return(
            <Panel bsStyle="primary">            
                <Panel.Body>
                
                <Switch>
                <Route exact path='/' component={Welcome}/>
                <Route path='/seances' component={ SeanceList }/>
                <Route path='/films' component={ FilmsList } />
                <Route path='/information' component={ Information } />
                </Switch>

                {/* {this.props.body} */}
                </Panel.Body>                            
            </Panel>
        );
    }
}