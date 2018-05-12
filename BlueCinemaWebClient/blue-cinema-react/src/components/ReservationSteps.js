'use strict';

import React, { Component } from 'react';

export class Step1 extends Component {
  constructor(props) {
    super(props);

    this.state = {};
  }

  componentDidMount() {}

  componentWillUnmount() {}

  // not required as this component has no forms or user entry
  // isValidated() {}

  render() {
    return (
      <div className="step step1">
        <div className="row">
          <form id="Form" className="form-horizontal">
            <div className="form-group">
              <label className="col-md-12 control-label">
                <h1>Step 1: Welcome to the official React StepZilla Example</h1>
                
              </label>
              <div className="row">
                <div className="col-md-12">
                  <div className="col-md-6">
                    <h3>This example uses this custom config (which overwrites the default config):</h3>
                   
                  </div>
                  <div className="col-md-6">
                   
                  </div>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
    )
  }
}

export const Step2 = (props) => (
  <div className="step step2">
    <div className="row">
      <form id="Form" className="form-horizontal">
        <div className="form-group">
          <label className="col-md-12 control-label">
            <h1>Step 2: Pure Component Example</h1>
          </label>
          <div className="row content">
            <div className="col-md-12">
                You can use Pure React Components as well (as of v4.2.0)!
                <br /><br />
                <span className="red">... but you cant provide validation logic here (i.e. you cant specify an <span className="bold">isValidated()</span> method and have StepZilla use that to determine if it can move to the next step). This is a limitation of using a Pure Component.</span>
                <br /><br />
                <span className="green">... so use a Pure Component if you just want to show some presentation content and a regular React Component (which extends from React.Component) if you need to provide Component level validation checkpoints via <span className="bold">isValidated()</span>.</span>
            </div>
            <div className="col-md-12 eg-jump-lnk">
              <a href="#" onClick={() => props.jumpToStep(0)}>e.g. showing how we use the jumpToStep method helper method to jump back to step 1</a>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
)

export class Step3 extends Component {
  constructor(props) {
    super(props);

    this.state = {
      email: props.getStore().email,
      gender: props.getStore().gender
    };

    this._validateOnDemand = true; // this flag enables onBlur validation as user fills forms

    this.validationCheck = this.validationCheck.bind(this);
    this.isValidated = this.isValidated.bind(this);
  }

  componentDidMount() {}

  componentWillUnmount() {}

  isValidated() {
    const userInput = this._grabUserInput(); // grab user entered vals
    const validateNewInput = this._validateData(userInput); // run the new input against the validator
    let isDataValid = false;

    // if full validation passes then save to store and pass as valid
    if (Object.keys(validateNewInput).every((k) => { return validateNewInput[k] === true })) {
        if (this.props.getStore().email != userInput.email || this.props.getStore().gender != userInput.gender) { // only update store of something changed
          this.props.updateStore({
            ...userInput,
            savedToCloud: false // use this to notify step4 that some changes took place and prompt the user to save again
          });  // Update store here (this is just an example, in reality you will do it via redux or flux)
        }

        isDataValid = true;
    }
    else {
        // if anything fails then update the UI validation state but NOT the UI Data State
        this.setState(Object.assign(userInput, validateNewInput, this._validationErrors(validateNewInput)));
    }

    return isDataValid;
  }

  validationCheck() {
    if (!this._validateOnDemand)
      return;

    const userInput = this._grabUserInput(); // grab user entered vals
    const validateNewInput = this._validateData(userInput); // run the new input against the validator

    this.setState(Object.assign(userInput, validateNewInput, this._validationErrors(validateNewInput)));
  }

   _validateData(data) {
    return  {
      genderVal: (data.gender != 0), // required: anything besides N/A
      emailVal: /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/.test(data.email), // required: regex w3c uses in html5
    }
  }

  _validationErrors(val) {
    const errMsgs = {
      genderValMsg: val.genderVal ? '' : 'A gender selection is required',
      emailValMsg: val.emailVal ? '' : 'A valid email is required'
    }
    return errMsgs;
  }

  _grabUserInput() {
    return {
      gender: this.refs.gender.value,
      email: this.refs.email.value
    };
  }

  render() {
    // explicit class assigning based on validation
    let notValidClasses = {};

    if (typeof this.state.genderVal == 'undefined' || this.state.genderVal) {
      notValidClasses.genderCls = 'no-error col-md-8';
    }
    else {
       notValidClasses.genderCls = 'has-error col-md-8';
       notValidClasses.genderValGrpCls = 'val-err-tooltip';
    }

    if (typeof this.state.emailVal == 'undefined' || this.state.emailVal) {
        notValidClasses.emailCls = 'no-error col-md-8';
    }
    else {
       notValidClasses.emailCls = 'has-error col-md-8';
       notValidClasses.emailValGrpCls = 'val-err-tooltip';
    }

    return (
      <div className="step step3">
        <div className="row">
          <form id="Form" className="form-horizontal">
            <div className="form-group">
              <label className="col-md-12 control-label">
                <h1>Step 3: Basic JavaScript Validation Example</h1>
              </label>
            </div>
            <div className="row content">
              <div className="col-md-12">
                This example component has a form that uses local standard basic JavaScript validation.
              </div>
            </div>
            <div className="form-group col-md-12 content form-block-holder">
                <label className="control-label col-md-4">
                  Gender
                </label>
                <div className={notValidClasses.genderCls}>
                  <select
                    ref="gender"
                    autoComplete="off"
                    className="form-control"
                    required
                    defaultValue={this.state.gender}
                    onBlur={this.validationCheck}>
                      <option value="">Please select</option>
                      <option value="Male">Male</option>
                      <option value="Female">Female</option>
                      <option value="Other">Other</option>
                  </select>
                  <div className={notValidClasses.genderValGrpCls}>{this.state.genderValMsg}</div>
                </div>
              </div>
              <div className="form-group col-md-12 content form-block-holder">
                <label className="control-label col-md-4">
                  Email
                </label>
                <div className={notValidClasses.emailCls}>
                  <input
                    ref="email"
                    autoComplete="off"
                    type="email"
                    placeholder="john.smith@example.com"
                    className="form-control"
                    required
                    defaultValue={this.state.email}
                    onBlur={this.validationCheck} />
                  <div className={notValidClasses.emailValGrpCls}>{this.state.emailValMsg}</div>
                </div>
              </div>
          </form>
        </div>
      </div>
    )
  }
}