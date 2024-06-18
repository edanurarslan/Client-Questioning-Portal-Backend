using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string CommentText { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }
}
