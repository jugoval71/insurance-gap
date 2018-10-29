import React, { Component } from 'react';
import { Alert} from 'react-bootstrap'
import BootstrapTable from 'react-bootstrap-table-next';
import cellEditFactory, { Type } from 'react-bootstrap-table2-editor';

class Home extends Component {

  getColumns() {
    const columns = [{
      dataField: 'id',
      text: 'Id'
    }, {
      dataField: 'name',
      text: 'Name'
    }, {
      dataField: 'description',
      text: 'Description'
    }, 
    {
      dataField: 'durationMonths',
      text: 'Duration (Months)'
    },
    {
      dataField: 'price',
      text: 'Price (COP)'
    },
    {
      dataField: 'risk',
      text: 'Risk'
    },
    {
      dataField: 'user',
      text: 'User'
    },
    {
      dataField: 'coverage',
      text: 'Coverage'
    },
    {
      dataField: 'startDate',
      text: 'Start Date',
      formatter: (cell) => {
        let dateObj = cell;
        if (typeof cell !== 'object') {
          dateObj = new Date(cell);
        }
        return `${('0' + dateObj.getDate()).slice(-2)}/${('0' + (dateObj.getMonth() + 1)).slice(-2)}/${dateObj.getFullYear()}`;
      },
      editor: {
        type: Type.DATE
      }
    },
    {
      dataField: 'types',
      text: 'Policy Types',
      editor: {
        type: Type.SELECT,
        options: [{
          value: 'earthquake',
          label: 'Earthquake'
        }, {
          value: 'fire',
          label: 'Fire'
        }, {
          value: 'loss',
          label: 'Loss'
        }, {
          value: 'theft',
          label: 'Theft'
        }]
      }
    }];
    return columns;
  } 

  getPolicies(){
    return [{
      id: '4d18e5c7-d279-4813-a763-6cdc8519c555',
      name: 'Test Name',
      description: 'Test Description',
      durationMonths: 12,
      price: '200000',
      risk: 'Low',
      user: 'testUser',
      startDate: 'Mon Oct 29 2018 08:46:20 GMT-0500 (Central Daylight Time)',
      types: 'fire'
    }]
  }

  render() {
    return (
      <div>
        <br />
        <Alert variant={'info'}>
          Available policies
        </Alert>

        <BootstrapTable
          keyField="id"
          data={this.getPolicies()}
          columns={this.getColumns()}
          cellEdit={ cellEditFactory({ mode: 'click', blurToSave: true }) }
          striped
          hover
          condensed
        />
      </div>
    );
  }
}

export default Home;
