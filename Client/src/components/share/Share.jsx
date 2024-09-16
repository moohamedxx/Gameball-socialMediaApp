import "./share.css";
import PermMedia from "@mui/icons-material/PermMedia";
import Label from "@mui/icons-material/Label";
import Room from "@mui/icons-material/Room";
import EmojiEmotions from "@mui/icons-material/EmojiEmotions";
import { useEffect, useState } from "react";
import axios from "axios";
import { UsePostsContext } from "../contexts/PostsContext";

export default function Share() {
  const [post, setPost] = useState({ UserId: 3, Title: "" });
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [error, setError] = useState("");
  const {Posts,setPosts,postComment,setPostComment,users,setUsers,getAllUsers} = UsePostsContext() ;

  const postPost = async () => {
    if (post.Title !== "") {
      setIsSubmitting(true);
      setError("");
      try {
        const response = await axios.post("https://localhost:7151/api/Post", post);
        console.log(response);
        // Optionally reset the form
        setPost({ UserId: 3, Title: "" });
        const res2=await axios.get(`https://localhost:7151/api/Post`)
        console.log(res2);
        setPosts(res2.data.$values)
        
      } catch (err) {
        console.error('Error posting data:', err);
        setError("Failed to post data. Please try again.");
      } finally {
        setIsSubmitting(false);
      }
    } else {
      setError("Title must have a value!");
    }
  };

  const handleInputChange = (e) => {
    setPost({
      ...post,
      Title: e.target.value
    });
  };
  // useEffect(()=>{
  //   getAllUsers() ;
  // },[])

  return (

    <div className="share">
      {
        users.length!=0?
      <div className="shareWrapper">
        <div className="shareTop">
          <img className="shareProfileImg" src={users.filter((ele)=>ele.id===post.UserId)[0].profilePicture} alt="" />
          <input
            value={post.Title}
            onChange={handleInputChange}
            placeholder="What's in your mind Safak?"
            className="shareInput"
          />
        </div>
        <hr className="shareHr" />
        <div className="shareBottom">
          <div className="shareOptions">
            <div className="shareOption">
              <PermMedia htmlColor="tomato" className="shareIcon" />
              <span className="shareOptionText">Photo or Video</span>
            </div>
            <div className="shareOption">
              <Label htmlColor="blue" className="shareIcon" />
              <span className="shareOptionText">Tag</span>
            </div>
            <div className="shareOption">
              <Room htmlColor="green" className="shareIcon" />
              <span className="shareOptionText">Location</span>
            </div>
            <div className="shareOption">
              <EmojiEmotions htmlColor="goldenrod" className="shareIcon" />
              <span className="shareOptionText">Feelings</span>
            </div>
          </div>
          <button
            className="shareButton"
            onClick={postPost}
            disabled={isSubmitting}
          >
            {isSubmitting ? "Sharing..." : "Share"}
          </button>
          {error && <p className="error">{error}</p>}
        </div>
      </div>:null
}
    </div>
  );
}
