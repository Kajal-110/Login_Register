using Login_WithRepository.Helpers.Helpers;
using Login_WithRepository.Models.Context;
using Login_WithRepository.Models.Models;
using Login_WithRepository.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_WithRepository.Repository.Services
{
    public class UserServices : IUser
    {
        Theam_Login_RegisterEntities db = new Theam_Login_RegisterEntities();
        public string Login(UserModel userModel)
        {
            try
            {
                var email = db.Users.Where(x => x.Email == userModel.Email).FirstOrDefault();
                var pass = db.Users.Where(x => x.Password == userModel.Password).FirstOrDefault();
                if (email == null && pass == null)
                {
                    return "invalid email and Password";
                }
                else if (email != null)
                {
                    if (email.Password != userModel.Password)
                    {
                        return "Invalid Password";
                    }
                    else
                    {
                        return email.Email;
                    }

                }
                else
                {
                    return "Invalid Email";
                }
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        public UserModel GetUserByUserId(int id)
        {
            try
            {


                Users users = db.Users.Where(x => x.Id == id).FirstOrDefault();

                if (users != null)
                {
                    UserModel userdetail = UserHelper.convertUserToUserModelForId(users);
                    return userdetail;
                }
                else
                {
                    return null;
                }


            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        
    }
}
