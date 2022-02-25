using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Dtos;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Repositories;
using SolrNet.Utils;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //Esta es la inyeccion de dependencias 
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        //Esto sirve para decirle que este metodo se invocara por Get
        [HttpGet]

        /*With this method we will give back all the post it exits
         Nos dara el listado de todos los post que hayan*/
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            var postDto = posts.Select(x => new PostDto
            {
                PostId = x.PostId,
                Date =x.Date,
                Description =x.Description,
                Image = x.Image,
                UserId = x.UserId

            });
            return Ok(postDto);
            //Ok works to give us back a 200 status which means that everything is ok on worked well
        }

        [HttpGet("{id}")]


        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            return Ok(postDto);

        }

        [HttpPost]


        public async Task<IActionResult> Post(PostDto post)
        {
            await _postRepository.InsertPost(post);
            return Ok(post);

        }
    }
}
