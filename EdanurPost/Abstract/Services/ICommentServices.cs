using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Services;

public interface ICommentServices
{
    public Comment GetByID(int id); //Belirli bir göneriye ait tüm yorumlarını listeler.
    public InsertCommentToPost Insert(int postId, InsertCommentToPost comment); // Belirli bir gönderiye yorum eklemek
}
