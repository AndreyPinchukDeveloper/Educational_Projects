using AspWithReact.Models;

namespace AspWithReact.Data
{
    public class ProjectDataContext
    {
        public List<PostModel> Posts { get; set; }
        public ProjectDataContext()
        {
            Posts = new List<PostModel>();
        }
    }
}
