using AspWithReact.Data;
using AspWithReact.Models;
using AspWithReact.Services.Interfaces;
using System.Reflection;

namespace AspWithReact.Services
{
    public class PostServices : PostService
    {
        private readonly ProjectDataContext _context;
        public PostServices(ProjectDataContext projectDataConte)
        {
            _context = projectDataConte;
        }
        public PostModel Create(PostModel model)
        {
            var lastPost = _context.Posts.LastOrDefault();
            int newId = lastPost is null ? 1 : lastPost.Id + 1;

            model.Id = newId;
            _context.Posts.Add(model);

            return model;
        }

        public void Delete(int id)
        {
            var modelToUpdate = _context.Posts.FirstOrDefault(x => x.Id == id);
            _context.Posts.Remove(modelToUpdate);
        }

        public PostModel Get(int id)
        {
            return _context.Posts.FirstOrDefault(x => x.Id == id);
        }

        public List<PostModel> GetAll()
        {
            return _context.Posts;
        }

        public PostModel Update(PostModel model)
        {
            var modelToUpdate = _context.Posts.FirstOrDefault(x => x.Id == model.Id);
            modelToUpdate.Title = model.Title;
            modelToUpdate.Description = model.Description;

            return modelToUpdate;
        }
    }
}
