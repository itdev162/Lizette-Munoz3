import React from "react";

const Post = props => {
    const { post } = props;

    return (
        <div>
            <hi>{post.title}</hi>
            <p>{post.body}</p>
        </div>
    )
}
export default Post;