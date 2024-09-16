import React, { useEffect, useState } from "react";
import "./comment.css";
import axios from "axios";
import { UsePostsContext } from "../contexts/PostsContext";

function Comment(props) {
    const [newComment,setNewComment]=useState({userId:2,id:1,PostId:props.post.id??3 , Content:""}) ;
    const [defaultComment,setDefaultComment]=useState("") ;

    const {Posts,setPosts,postComment,setPostComment,users,setUsers,getAllUsers} = UsePostsContext() ;
    const [commentId,setCommentId]=useState(0) ; // Using React.useState directly instead of just useState
    const data = props.comments.filter((ele) => ele.postId === props.post.id);
    const str = "No Comments yet!";
    const baseUrl=`https://localhost:7151/api`
    const postNewComment=async()=>{
        if(newComment.content!==""){
         await axios.post(`${baseUrl}/Comment`,newComment).
        then((res)=>console.log(res.status)
            )
            await axios.get(`${baseUrl}/Comment`).then((res)=>{
                setPostComment(res.data)
            })
           
        }

    }
    const EditComment=async(id)=>{
        await axios.put(`${baseUrl}/Comment/${id}`,newComment).
        then((res)=>res.status)
        await axios.get(`${baseUrl}/Comment`).then((res)=>{
            setPostComment(res.data)
        })
    

    }
    const RemoveComment=async(id)=>{
        await axios.delete(`${baseUrl}/Comment/${id}`)
        .then((res)=>console.log(res.status)
        )
        await axios.get(`${baseUrl}/Comment`).then((res)=>{
            setPostComment(res.data)
        })
    }
    // const [currentUser,setCurrentUser]=useState({}) ;
    // const getCommentUser=async(id)=>{
    //     await axios.get(`${baseUrl}/User/${id}`).
    //     then((res)=>{setCurrentUser(res.data) ; console.log(`currentis${res.data}`);
    //     })
    // }
    useEffect(()=>{

//getAllUsers() ;
    },[])
    if(users.length==0){
        console.log(`loading......`);
        
      }
      else{
        console.log("user is",users.filter((ele)=>ele.id==5)[0].name);
        
      }
     
    //console.log("users",users.filter((ele2)=>ele2.$id==10)[0].profilePicture)
    


    return (
        <>
            {props.show ? (
                <div className="comment">
                    <ol>
                        {data.length>0 && users.length > 0 ? (
                            data.map((ele) => (
                                <li key={ele.id}>
                                    
                                    
                                    <div className="details">
                                    <img src={users.filter((ele2)=>ele2.id===ele.userId)[0].profilePicture} alt=".." />
                                    <h5>{users.filter((ele2)=>ele2.id===ele.userId)[0].name}</h5>
                                    <span className="content">{ele.content}</span>
                                    </div>
                                    <div className="btns">
                                    
                                    <button className="edit" onClick={()=>{
                                    setDefaultComment(ele.content)
                                    setCommentId(ele.id)
                                }}>Edit</button><button className="delete" onClick={()=>{RemoveComment(ele.id)}}>Delete</button>
                                </div></li>
                            ))
                        ) : (
                            <li>{str}</li>
                        )}
                    </ol>
                    <input className="text-box" defaultValue={defaultComment} onChange={(e)=>{
                        setNewComment({userId:3,id:commentId,PostId:props.post.id,Content:e.target.value})
                        //setDefaultComment(e.target.value) ;
                        }} type="text" placeholder="write a comment here" />
                    {(defaultComment==="")?
                    <button onClick={postNewComment} className="comment-btn" >Comment</button>
                    :<button className="comment-btn" onClick={()=>{EditComment(commentId)}} >update</button>}
                </div>
            ) : null}
        </>
    );
}

export default Comment;
