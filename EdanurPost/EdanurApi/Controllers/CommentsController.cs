using Abstract.Services;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace EdanurApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IUserServices _userService;
    private readonly IPostServices _postService;
    private readonly ICommentServices _commentService;

    public CommentsController(IUserServices userService, IPostServices postService, ICommentServices commentService)
    {
        _userService = userService;
        _postService = postService;
        _commentService = commentService;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var data = _commentService.GetByID(id);
        return Ok(data);
    }

    [HttpPost("{PostId}")]
    public IActionResult Insert([FromRoute] int PostId,[FromBody] InsertCommentToPost comment)
    {
        var data = _commentService.Insert(PostId,comment);
        return Created(string.Empty, data);
    }
}
