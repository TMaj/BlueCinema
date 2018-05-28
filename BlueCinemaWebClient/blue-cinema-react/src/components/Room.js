import React from 'react'

export default class Room extends React.Component {
    renderPlace(i) {
      return <Place value={i} />;
    }

    renderRow(){
     return (<div className="board-row">
        {this.renderPlace(0)}
        {this.renderPlace(1)}
        {this.renderPlace(2)}
        {this.renderPlace(3)}
        {this.renderPlace(4)}
        {this.renderPlace(5)}
        {this.renderPlace(6)}
        {this.renderPlace(7)}
        {this.renderPlace(8)}  
        {this.renderPlace(9)}
        {this.renderPlace(10)}
        {this.renderPlace(11)}
        {this.renderPlace(12)}
        {this.renderPlace(13)}
        {this.renderPlace(14)}
        {this.renderPlace(15)}
        {this.renderPlace(16)}
        {this.renderPlace(17)}            
      </div>);
      }
     
    
  
    render() {
      const status = <b> {this.props.seanceTitle + ' ' + this.props.seanceTime} </b>;
  
      return (
        <div>
        <style type="text/css">{`
        .board-row:after {
            clear: both;
            content: "";
            display: table;
          }
        `}
        </style>

        
        <div>
          <div className="status">{status}</div>
          {this.renderRow()}
          {this.renderRow()}
          {this.renderRow()}
          {this.renderRow()}
          {this.renderRow()}
          {this.renderRow()}
          {this.renderRow()}
          {this.renderRow()}
        </div>
        </div>
      );
    }
  }

  class Place extends React.Component {
    render() {
      return (
        <div>
        <style type="text/css">{`
        .place {
            background: black;
            border: 1px solid #999;
            float: left;
            font-size: 24px;
            font-weight: bold;
            line-height: 34px;
            height: 34px;
            margin-right: -1px;
            margin-top: -1px;
            padding: 0;
            text-align: center;
            width: 34px;
          }
        `}
        </style>

        <button className="place">
          {this.props.value}
        </button>
        </div>
      );
    }
  }