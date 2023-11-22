using AspWithReact.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspWithReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController:ControllerBase
    {
        [HttpPost]
        public object Create(PostModel model)
        {

        }

        [HttpPatch]
        public object Update(PostModel model)
        {

        }

        [HttpGet("{id}")]
        public object Get(int id)
        {

        }

        [HttpGet]
        public object GetAll()
        {


        }

        [HttpDelete]
        public object Delete(int id)
        {

        }
    }
}
