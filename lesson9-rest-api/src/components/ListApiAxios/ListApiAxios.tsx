import React, { FC, useState, useEffect } from 'react';
import './ListApiAxios.scss';
import axios from 'axios';
import Loadder from '../loadder/loadder';
import apiService from '../../services/api.service';
import { error } from 'console';
import User from '../../models/User';
import UserDetails from '../user-details/user-details'

interface ListApiAxiosProps { }

const ListApiAxios: FC<ListApiAxiosProps> = () => {
  const [listApi, setListApi] = useState<any[]>([])
  // const [listApiDisplay, setListApiDisplay] = useState<any[]>([])  
  const [user, setUser] = useState<any>()

  useEffect(() => {
    loadItems();
  }, [])

  const loadItems = () => {
    apiService.getClientListApi().then((res) => {
      setListApi(res.data)
      // setListApiDisplay(res.data)
    })
  }

  const getClientById = (e: any) => {
    if (e.target.value == '') {
      setUser("")
    }
    apiService.getClientById(e.target.value).then((res) => {
      setUser(res.data)
    })
  }

  const addNewClient = (client: any) => {
    apiService.inserNewClient(client).then((resp) => {
      apiService.getClientListApi().then((res) => {
        setListApi(res.data)
      })
    })
  }


  const deleteClient = (client: any) => {
    if (client.id == user.id) {
      apiService.deleteClient(client).then((res) => {
        loadItems();
        setUser('')
      })
    }
    else {
      apiService.deleteClient(client).then((res) => {
        loadItems();
      })
    }
  }

  return <div className='row'>
    <div className='col-sm-6'>
      <div className='col-sm-8'>
        <input type='text' onBlur={(e) => getClientById(e)} className="search form-control m-4" placeholder="Search..."></input><br></br>
      </div>
      {user ? <div className='m-4'>
        <div className="card col-sm-8">
          <div className="card-body">
            <h5 className="card-title">{user.id}</h5>
            <p className="card-text">{user.name}</p>
            <p className="card-text">{user.hmo}</p>
            <button className='btn btn-warning mt-5' onClick={() => { deleteClient(user) }}>delete {user.name}</button>
          </div>
        </div>
      </div> :
        listApi.map((a) => {
          return <div className='m-4'>
            <div className="card col-sm-8">
              <div className="card-body">
                <h5 className="card-title">{a.id}</h5>
                <p className="card-text">{a.name}</p>
                <p className="card-text">{a.hmo}</p>
                <button className='btn btn-warning mt-5' onClick={() => { deleteClient(a) }}>delete {a.name}</button>
              </div>
            </div>
          </div>
        })}
    </div>
    <div className='col-sm-6'>
      <UserDetails funcParentAdd={addNewClient}>Add new user</UserDetails>
    </div>
  </div>

}

export default ListApiAxios;