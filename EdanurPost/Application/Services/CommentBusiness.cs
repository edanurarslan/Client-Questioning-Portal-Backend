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

public class CommentBusiness : ICommentServices
{
    private readonly EdanurContext _context;

    public CommentBusiness(EdanurContext context)
    {
        _context = context;
    }

    public Comment GetByID(int id)
    {
        var comment = _context.Comments.SingleOrDefault(x => x.Id == id);
        return comment;
    }

    public InsertCommentToPost Insert(int postId,InsertCommentToPost comment)
    {
        Comment comment_ = new Comment() { CommentText = comment.CommentText ,PostId = postId };
        _context.Comments.Add(comment_);
        _context.SaveChanges();
        return comment;
    }
}
