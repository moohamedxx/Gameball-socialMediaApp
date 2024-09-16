import React, { useState } from "react";
import "./postpopup.css"
import axios from "axios";
import { UsePostsContext } from "../contexts/PostsContext";
const PostPopup=(props)=>{
    const {popState,post}=props ;
    const{Posts,setPosts,postComment,setPostComment}=UsePostsContext() ;
    const [defaultPost,setDefaultPost]=useState(post.title) ;
    const [show,setShow]=useState(true) ;
    const [data,setData]=useState({id:post.id,title:"", userId:0}) ;
    const[showtext,setShowText]=useState(false) ;
    const editPost=async(id)=>{
           await axios.put(`https://localhost:7151/api/Post/${id}`,data)
            .then((res)=>{console.log(res.status)})
            await axios.get(`https://localhost:7151/api/Post`).then((res)=>{
                setPosts(res.data.$values)
            })
              }
    
    const removePost=async(id)=>{
await axios.delete(`https://localhost:7151/api/Post/${id}`)
.then((res)=>{console.log(res.status);
})
await axios.get(`https://localhost:7151/api/Post`).then((res)=>{
    setPosts(res.data.$values)
})
    }
    return(<>
    {
        popState===true && show?
    <div className="post-popup">
        {showtext?<>
        <input onChange={(e)=>{setData({id:post.id,title:e.target.value,userId:post.userId})}} type="text" defaultValue={defaultPost}/>
        <button onClick={()=>{editPost(post.id);setShow(false)}} className="edit-btn">Save</button>
        </>:null}
        <button onClick={()=>(showtext)?setShowText(false):setShowText(true)} className="edit-btn">Edit post</button>
        <button onClick={()=>{removePost(post.id)}} className="delete-btn">delete post</button>
    </div>:null
}
    </>)
}
export default PostPopup ;