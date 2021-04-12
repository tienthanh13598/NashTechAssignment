import axios from 'axios'

import React, { useEffect, useState } from 'react'
interface Products{
  id:number;
  name:string;
  price:number;
  category:string;

}

const Listproduct = () => {
  const [product,setProduct]=useState<Products[]>([])
  useEffect(() => {
    axios.get('http://localhost:5000/products')
    .then(res=>{
      console.log(res);
      return res.data;
    })
    .then(data=>{
      setProduct(data);
      console.log(data);
      
    }
     )
      
    .catch(error=>console.log(error))
    
  }, [])
  return (
    <div>
      <h2>List products </h2>
      <table >
        <tr>
        <th>ID</th>
        <th>Name product</th>
        <th>Price</th>
        <th>Category</th>
        </tr>
        
        {product.map(item => (
            <tr key={item.id}>
            <td>{item.id}</td>
            <td>{item.name}</td>
            <td>{item.price}</td>
            <td>{item.category}</td>
          </tr>
        )
          
        )}
        
        
      </table>
    </div>
  )
}

export default Listproduct
