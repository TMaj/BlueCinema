'use strict';

import React, { Component } from 'react';
import StepZilla from 'react-stepzilla'
import {Step1, Step2, Step3} from './ReservationSteps'


export default class StepsComponent extends Component {
    constructor(props) {
      super(props);
      this.state = {};
  
      this.sampleStore = {
        email: '',
        gender: '',
        savedToCloud: false
      };
    }
  
    componentDidMount() {}
  
    componentWillUnmount() {}
  
    getStore() {
      return this.sampleStore;
    }
  
    updateStore(update) {
      this.sampleStore = {
        ...this.sampleStore,
        ...update,
      }
    }
  
    render() {
      const steps =
      [
        {name: 'Step1', component: <Step1 getStore={() => (this.getStore())} updateStore={(u) => {this.updateStore(u)}} />},
        {name: 'Step2', component: <Step2 getStore={() => (this.getStore())} updateStore={(u) => {this.updateStore(u)}} />},
        {name: 'Step3', component: <Step3 getStore={() => (this.getStore())} updateStore={(u) => {this.updateStore(u)}} />}     
      ]
  
      return (
        <div className='example'>
          <div className='step-progress'>
            <StepZilla
              steps={steps}
              preventEnterSubmission={true}
              nextTextOnFinalActionStep={"Save"}
              hocValidationAppliedTo={[3]}
              startAtStep={window.sessionStorage.getItem('step') ? parseFloat(window.sessionStorage.getItem('step')) : 0}
              onStepChange={(step) => window.sessionStorage.setItem('step', step)}
             />
          </div>
        </div>
      )
    }
  }