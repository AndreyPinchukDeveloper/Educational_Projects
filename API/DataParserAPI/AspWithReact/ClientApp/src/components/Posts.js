const Posts = () => {

    const [allPosts, setPosts] = useState([]);

    const getPosts = async () => {
        const options = {
            method: 'GET'
        }
        const result = await fetch('https://localhost:7131', options);
        if (result.ok) {
            const posts = await result.json();
            return posts;
        }
    }

    return (
        <div>
            <p>Posts creator</p>
            <div style={{ margin: '10px' }}>
                <input type="text" />
            </div>
            <div style={{ margin: '10px' }}>
                <textarea />
            </div>
            <button>Add post</button>
        </div>
    )
}

export default Posts;