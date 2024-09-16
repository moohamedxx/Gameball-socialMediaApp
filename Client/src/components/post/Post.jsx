import "./post.css";
//import { MoreVert } from "@material-ui/icons";
import MoreVert from "@mui/icons-material/MoreVert";
//import { Users } from "../../dummyData";
import { useEffect, useState } from "react";
import Comment from "../Comment/Comment";
import axios from "axios";
import PostPopup from "../postPopup/PostPopUp";
import { UsePostsContext } from "../contexts/PostsContext";
import { Users } from "../../dummyData";

export default function Post({ post}) {
  const[showComment,setShowComment]=useState(false) ;
  const {Posts,setPosts,postComment,setPostComment,users} = UsePostsContext() ;
  
  const [like,setLike] = useState(11) ;
  const [isLiked,setIsLiked] = useState(false) ;

  const [pop,setPop]=useState(false) ;
  //const {Posts,setPosts,postComment,setPostComment}=UsePostsContext() ;
  useEffect(()=>{
 axios.get(`https://localhost:7151/api/Comment`)
.then((res)=>{
  setPostComment(res.data) ;
})

 },[])
if(users.length==0){
  console.log(`looooooooooding`);
  
}
else{
  
}
  
 

  const likeHandler =()=>{
    setLike(isLiked ? like-1 : like+1)
    setIsLiked(!isLiked)
  }

  
  return (
    <>
    { users.length!==0?
     <div className="post">
       <div className="postWrapper">
         <div className="postTop">
           <div className="postTopLeft">
            <img className="postProfileImg" src={users.filter((ele)=>ele.id===post.userId)[0].profilePicture??null} alt="profile-picture" />
             <span className="postUsername">
               {users.filter((ele)=>ele.id===post.userId)[0].name}
             </span>
             <span className="postDate">{post.dateOfCreation}</span>
           </div>
           <div  className="postTopRight">
             <MoreVert onClick={()=>{pop===true?setPop(false):setPop(true)}} className="mor" />
             <PostPopup post={post}  popState={pop} />
           </div>
           
         </div>
         
         <div className="postCenter">
           <span className="postText">{post?.title}</span>
           {post.pictureUrl?<img className="postImg" src={post.pictureUrl} alt="postImage" />:null}
         </div>
         <div className="postBottom">
           <div className="postBottomLeft">
             <img className="likeIcon" src="assets/like.png" onClick={likeHandler} alt="" />
            <img className="likeIcon" src="assets/heart.png" onClick={likeHandler} alt="" />
           <span className="postLikeCounter">{like} people like it</span>
          </div>
       <div  className="postBottomRight">
           <span onClick={()=>showComment?setShowComment(false):setShowComment(true)} className="postCommentText" > {post.comments.$values.length} comments</span>
           
         </div>
       
        </div>
    </div>

         <Comment post={post} comments={postComment.$values??[]} show={showComment}/>
         
    </div>:null
    }
    </>
    
  );
}
