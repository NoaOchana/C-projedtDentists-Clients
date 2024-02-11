import React, { FC } from 'react';
import './user-details.scss';
import User from '../../models/User';
import { useFormik } from 'formik';
import * as Yup from 'yup'

interface UserDetailsProps { 
    funcParentAdd:(user: User)=>void
    children:React.ReactNode
}

const UserDetails: FC<UserDetailsProps> = (props:UserDetailsProps) => {
  const myForm=useFormik({
    initialValues: new User("id", "name", "hmo"),
    onSubmit: (valueForm: User) => {
      props.funcParentAdd(valueForm)
    },
    validationSchema: Yup.object().shape({
      id: Yup.string().required(),
      name: Yup.string().required(),
      hmo: Yup.string().required(),
    })
  })

  return <div className="user-details">
    <form onSubmit={myForm.handleSubmit} className='col-sm-6 '>
      <h2 className='mt-5'>{props.children}</h2>

      <div className='form-group mt-3'>
        <label>id</label>
        <input name='id' onChange={myForm.handleChange} className={myForm.errors.id ? 'form-control is-invalid' : 'form-control'}></input>
        {myForm.errors.id ? <small>{myForm.errors.id}</small> : ''}
      </div>
      <div className='form-group mt-3'>
        <label>name</label>
        <input name='name' onChange={myForm.handleChange} className={myForm.errors.name ? 'form-control is-invalid' : 'form-control'}></input>
        {myForm.errors.name ? <small>{myForm.errors.name}</small> : ''}
      </div>

      <div className='form-group mt-3'>
        <label>HMO</label>
        <input name='hmo' onChange={myForm.handleChange} className={myForm.errors.hmo ? 'form-control is-invalid' : 'form-control'}></input>
        {myForm.errors.hmo ? <small>{myForm.errors.hmo}</small> : ''}
      </div>

      
      <button type='submit' className='btn btn-warning mt-5'>Add new User</button>

    </form>
  </div>
}

export default UserDetails;
