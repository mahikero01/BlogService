using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BlogService.Models;

namespace BlogService.Controllers
{
    public class PostsController : ApiController
    {
        private BlogServiceContext db = new BlogServiceContext();

        // GET: api/Posts
        /*
        public IQueryable<Post> GetPosts()
        {
            return db.Posts
                .Include(p => p.Person);
        }
        */

        public IQueryable<PostDTO> GetPosts()
        {
            var posts = from p in db.Posts
                        select new PostDTO() 
                        { 
                            Id = p.Id,
                            Title = p.Title,
                            AuthorName = p.Person.Name
                        };

            return posts;
        }


        // GET: api/Posts/5
        /*
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> GetPost(Guid id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
        */

        [ResponseType(typeof(PostDetailDTO))]
        public async Task<IHttpActionResult> GetPost(Guid id)
        {
            var post = await db.Posts.Include(p => p.Person).Select(p =>
                new PostDetailDTO() 
                { 
                    Id = p.Id,
                    Title = p.Title,
                    Comment = p.Comment,
                    AuthorName = p.Person.Name
                }).SingleOrDefaultAsync(p => p.Id == id);

            if (post == null) 
            {
                return NotFound();
            }

            return Ok(post);
        }


        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPost(Guid id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostExists(post.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
            //return CreatedAtRoute("DefaultApi", post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> DeletePost(Guid id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            await db.SaveChangesAsync();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(Guid id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}