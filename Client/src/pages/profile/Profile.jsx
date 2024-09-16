import "./profile.css";
import Topbar from "../../components/topbar/Topbar";
import Sidebar from "../../components/sidebar/Sidebar";
import Feed from "../../components/feed/Feed";
import Rightbar from "../../components/rightbar/Rightbar";
import { UsePostsContext } from "../../components/contexts/PostsContext";

export default function Profile() {
  const{users,setUsers}=UsePostsContext() ;
  return (
    <>
      <Topbar />
      <div className="profile">
        <Sidebar />
        <div className="profileRight">
          <div className="profileRightTop">
            <div className="profileCover">
              <img
                className="profileCoverImg"
                src="assets/post/3.jpeg"
                alt=""
              />
              <img
                className="profileUserImg"
                src={users.length!=0?users.filter((ele)=>ele.id===3)[0].profilePicture:null}
                alt="..."
              />
            </div>
            <div className="profileInfo">
                <h4 className="profileInfoName">{users.length!=0?users.filter((ele)=>ele.id===3)[0].name:null}</h4>
                <span className="profileInfoDesc">Hello my friends!</span>
            </div>
          </div>
          <div className="profileRightBottom">
            <Feed />
            <Rightbar profile/>
          </div>
        </div>
      </div>
    </>
  );
}
