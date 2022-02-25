
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;
using SocialMedia.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Infraestructure.Repositories
{
    //Creamos un metodo que nos devolvera un listado de Post
    public class PostRepository : IPostRepository
    {//Precedido de el PostRepository IMPLEMENT Ipostrepository
    //Cuando implementamos una interfaz estamos obligados a cumplir
    //con el contraro, es decir tenemos que implementar cada uno de los
    //metodos de esa interfaz


        //Inyeccion de dependencias via constructor
        private readonly SocialMediaContext _context;
        public PostRepository (SocialMediaContext context)
        {
            _context = context;
        }

        
        public  async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);

            return post;
        }

        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

    }
}
