import axios from "axios";
import Post from "../post/Post";
import Share from "../share/Share";
import "./feed.css";
import {  useEffect, useState } from "react";
import { UsePostsContext } from "../contexts/PostsContext";


export default function Feed() {
  
  

  const {Posts,setPosts,postComment,setPostComment} = UsePostsContext() ;
  console.log(Posts);
  

  const [users, setUsers] = useState([]);

  const Url = `https://localhost:7151/api`;

  const fetchData = async (endpoint) => {
    try {
      const response = await axios.get(`${Url}/${endpoint}`);
      const data = response.data.$values;
      if (endpoint === "Post") {
        setPosts(data);
      } else if (endpoint === "User") {
        setUsers(data);
      
      }
    } catch (error) {
      console.error(`Failed to fetch ${endpoint}:`, error);
    }
  };

  useEffect(() => {
    fetchData("Post");
    fetchData("User");
  }, []);

  return (
      
      <div className="feed">
        <div className="feedWrapper">
          <Share />
          {Posts.map((post) => (
            <Post key={post.$id} post={post} user={users} />
          ))}
        </div>
      </div>
  );
}
