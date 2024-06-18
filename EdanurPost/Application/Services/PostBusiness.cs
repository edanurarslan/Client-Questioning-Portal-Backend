using Abstract.Services;
using Domain.Dto;
using Domain.Entities;
using Infracture.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class PostBusiness : IPostServices
{
    private readonly EdanurContext _context;

    public PostBusiness(EdanurContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var Post = _context.Posts.SingleOrDefault(p => p.Id == id);
        _context.Posts.Remove(Post);
        _context.SaveChanges();
    }

    public Post GetByID(int id)
    {
        var post = _context.Posts.SingleOrDefault(x => x.Id == id);
        return post;
    }


    public InsertPostToUser Insert(int userId ,InsertPostToUser post)
    {
        Post post_ = new Post() { Title = post.Title,Description=post.Description,UserId=userId };
        _context.Posts.Add(post_);
        _context.SaveChanges();
        return post;
    }
}
