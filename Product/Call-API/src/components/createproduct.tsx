import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useForm } from 'react-hook-form';


interface AddProduct{
  id:number;
  name:string;
  price:number;
  category:string;
}
interface ICategory{
  categoryid:number;
  categoryname:string;
}
const Createproduct = () => {
  const [category,setCategory]=useState<ICategory[]>([]);
  const [newproduct,setProduct]=useState<AddProduct>()
  
  const{register,handleSubmit,formState:{errors}}=useForm<AddProduct>();
 
async function onSubmit(data:AddProduct,e:any){
      console.log(data);
      setProduct(data)
      
      try{
        
        await axios.post('http://localhost:5000/products' ,newproduct);
        await alert(' Add seccess !');
        e.target.reset();
      }
      catch(err){
        console.log(err.response.data);
      }
  }
  

  useEffect(() => {
    axios.get('http://localhost:5000/category').then(res=>res.data)
    .then(data=> setCategory(data))
    .catch(errors=> console.log(errors))
  }, [])  
  return (
    
    <form onSubmit={handleSubmit(onSubmit)} >
      <h1>Add product</h1>
      <div>
        <label >ID</label>
        <input {...register("id",{required:true})} type="number" />
        {errors?.id?.type === "required" && <p>This field is required</p>}
      </div>
      <div>
        <label >Name product</label>
        <input {...register("name",{required:true})} placeholder="Input name product"/>
        {errors.name && <p>Name product is null</p>}
      </div>
      <div>
        <label >Price</label>
        <input {...register("price",{required:true})}type="number" />
        {errors.price && <p>Price is null</p>}
      </div>
      <div>
        <label >Category</label>
        <select {...register("category",{required:true})} >
          <option></option>
         {category.map((cate)=>(
           <option key={cate.categoryid}>{cate.categoryname}</option>
         )
         
         )}
        </select>
        {errors.category && <p>category product is null</p>}
      </div>
      
      <input type="submit" value="Add"/>
      
    </form>
      
    
  )
}

export default Createproduct
