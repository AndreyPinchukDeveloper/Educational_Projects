using AspWithReact.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspWithReact.Services.Interfaces
{
    public interface PostService
    {
        PostModel Create(PostModel model);
        PostModel Update(PostModel model);
        PostModel Get(int id);
        List<PostModel> GetAll();
        void Delete(int id);
    }|
}
