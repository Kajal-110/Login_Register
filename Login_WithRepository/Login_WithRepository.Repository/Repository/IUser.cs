using Login_WithRepository.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_WithRepository.Repository.Repository
{
    public interface IUser
    {
        string Login(UserModel userModel);

        UserModel GetUserByUserId(int id);
    }
}
