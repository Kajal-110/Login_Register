using Login_WithRepository.Models.Context;
using Login_WithRepository.Models.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_WithRepository.Helpers.Helpers
{
        
    public class UserHelper
    {
        public static Users convertToUserModel(UserModel userModel)
        {
            Users user = new Users();
            user.Id = userModel.Id;
            user.Fullname = userModel.Fullname;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
          

            return user;
        }

        public static List<UserModel> convertUserToUserModel(List<Users> users)
        {
            try
            {

                List<UserModel> userModel = new List<UserModel>();
                foreach (var item in users)
                {
                    UserModel UserList = new UserModel();
                    UserList.Id = item.Id;
                    UserList.Fullname = item.Fullname;
                    UserList.Email = item.Email;
                    UserList.Password = item.Password;
                    
                    userModel.Add(UserList);

                }
                return userModel;
            }
            catch(System.Exception e)
            {
                throw e;
            }

        }

        public static UserModel convertUserToUserModelForId( Users user)
        {
            try
            {
                    UserModel UserList = new UserModel();
                    UserList.Id = user.Id;
                    UserList.Fullname= user.Fullname;
                   
                    UserList.Email = user.Email;
                    UserList.Password = user.Password;
                    
               
                return UserList;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static UserModel EditUser(Users user)
        {
            UserModel usermodel = new UserModel();

            usermodel.Id = user.Id;
            usermodel.Fullname = user.Fullname;           
            usermodel.Email = user.Email;
            usermodel.Password = user.Password;
           
            return usermodel;
        }
    }
}
