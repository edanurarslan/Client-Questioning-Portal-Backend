using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Services;

public interface IPostServices
{
    public Post GetByID(int id); //Belirli bir kullanıcının tüm gönderilerini listeler.
    public InsertPostToUser Insert(int userId,InsertPostToUser post); //Belirli bir kullanıcıya gönderi ekler.
    void Delete(int id);
}
