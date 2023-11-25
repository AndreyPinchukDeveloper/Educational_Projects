import { useEffect, useState } from "react";

const URL = `/api/posts`;

const Posts = () => {

    const [allPosts, setPosts] = useState([]);

    const getPosts = async () => {
        const options = {
            method: 'GET',
            headers: new Headers()
        }
        const result = await fetch(URL, options);
        if (result.ok) {
            const posts = await result.json();
            setPosts(posts);
            return posts;
        }
        return [];
    }

    const addPost = async () => {

        const headerFromUser = document.querySelector('#header').value;
        const textFromUser = document.querySelector('#text').value;

        const newPost = {
            header: headerFromUser,
            text: textFromUser
        };

        const options = {
            method: 'POST',
            headers: new Headers(),
            body: JSON.stringify(newPost)
        };

        const result = await fetch(URL, options);
        if (result.ok) {
            const post = await result.json();
            setPosts(allPosts.push(post));
        }
        return [];
    }

    useEffect(() => {
        getPosts();
    }, [])

    return (
        <div>
            <div>
                <p>Posts creator</p>
                <div style={{ margin: '10px' }}>
                    <input id="header" type="text" />
                </div>
                <div style={{ margin: '10px' }}>
                    <textarea id="text" />
                </div>
                <button onClick={() => addPost()}>Add post</button>
            </div>
            <div>
                {allPosts.map(x => <PostItem key={x.id} id={x.id} header={x.header} text={x.text}/>})}
            </div>
        </div>
        
    )
}

export default Posts;

const PostItem = ({ id, header, text }) => {
    return (
        <div>
            <h2>{x.header}</h2>
            <p>{x.text}</p>
        </div>
    )
}