using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Services;

public interface IUserServices
{
    public IEnumerable<User> GetAll(); //Tüm kullanıcıları listeler.
    public UserDto GetByID(int id); //Belirli bir kullanıcının tüm gönderilerini listeler.
    void Update(User user); //Kullanıcının bilgilerini günceller.

}
