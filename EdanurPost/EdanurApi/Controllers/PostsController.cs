using Abstract.Services;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EdanurApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IUserServices _userService;
    private readonly IPostServices _postService;
    private readonly ICommentServices _commentService;

    public PostsController(IUserServices userService, IPostServices postService, ICommentServices commentService)
    {
        _userService = userService;
        _postService = postService;
        _commentService = commentService;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _postService.Delete(id);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var data = _postService.GetByID(id);
        return Ok(data);
    }

    [HttpPost("{UserId}")]
    public IActionResult Insert([FromRoute] int UserId, [FromBody] InsertPostToUser post)
    {
        var data = _postService.Insert(UserId,post);
        return Created(string.Empty, data);
    }
}
