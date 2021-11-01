using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private readonly DataContext context;

    public PostsController(DataContext context)
    {
      this.context = context;
    }
    ///<summary>
    /// GET api/posts
    ///<summary>
    /// <returns>A lis of posts</returns>

        [HttpGet]
    public ActionResult<List<Post>> Get()
    {
      return this.context.Posts.ToList();
    }

    ///<summary>
    ///Get api/post/[id]
    ///</summary>
    ///<para name ="id">Post id</param>
    ///<returns> A single post</returns>

    [HttpGet("{id}")]
    public ActionResult<Post> GetById(Guid id)
    {
      return this.context.Posts.Find(id);
    }
        /// <summary>
        /// POST api/post
        /// </summary>
        /// <param name="request">JSON request containing post fields</param>
        /// <returns>A new post</returns>
        [HttpPost]
        public ActionResult<Post> Create([FromBody] Post request)
        {
            var post = new Post
            {
                Id = request.Id,
                Title = request.Title,
                Body = request.Body,
                Date = request.Date
            };

            context.Posts.Add(post);
            var success = context.SaveChanges() > 0;

            if (success)
            {
                return post;
            }

            throw new Exception("Error creating post");
        }






  }
}
