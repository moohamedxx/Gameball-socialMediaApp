import axios from "axios";
import React, { createContext, useContext, useEffect, useState } from "react";
const PostsContext=createContext() ;

export const PostsProvider=({children})=>{
const Url = `https://localhost:7151/api`;
const [Posts,setPosts]=useState([]) ;
const [postComment,setPostComment]=useState([]) ;
const [users,setUsers]=useState([]) ;
const getAllUsers=async()=>{
    await axios.get(`${Url}/User`).then((res)=>{setUsers(res.data.$values)}) ;
}
useEffect(()=>{
getAllUsers() ;
},[])
return(
<PostsContext.Provider value={{Posts,setPosts,postComment,setPostComment,users,setUsers,getAllUsers}}>
{children}
</PostsContext.Provider>)
}
export const UsePostsContext=()=>useContext(PostsContext) ;