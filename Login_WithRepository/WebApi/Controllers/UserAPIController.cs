using Login_WithRepository.Helpers.Helpers;
using Login_WithRepository.Models.Context;
using Login_WithRepository.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class UserAPIController : ApiController
    {
        Theam_Login_RegisterEntities db = new Theam_Login_RegisterEntities();
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/UserAPI/DisplayUserList")]
        public async Task<IHttpActionResult> ReadUserData()
        {
            try
            {
                List<Users> users = await db.Users.ToListAsync();
                if (users != null && users.Count > 0)
                {
                    List<UserModel> userModelList = UserHelper.convertUserToUserModel(users);
                    return Ok(userModelList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [System.Web.Http.HttpPost]       
        public async Task<IHttpActionResult> PostCreateUserData(UserModel userModel)
        {
            try
            {
                if (userModel.Id == 0)
                {
                    Users user = new Users();
                    user = UserHelper.convertToUserModel(userModel);
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    if (user != null)
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    try
                    {
                        Users users = UserHelper.convertToUserModel(userModel);
                        db.Entry(users).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return Ok(users);
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [System.Web.Http.HttpGet]        

        public async Task<IHttpActionResult> GetFindUserById(int id)
        {
            try
            {
                Users user = await db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    var result = UserHelper.convertUserToUserModelForId(user);
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Users users = await db.Users.FindAsync(id);
                if(users != null)
                {
                    var delete =  db.Users.Remove(users);
                    await db.SaveChangesAsync();
                    return Ok(delete);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }



       
    }
}
