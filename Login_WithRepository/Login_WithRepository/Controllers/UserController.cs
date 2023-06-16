using Login_WithRepository.Models.Context;
using Login_WithRepository.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Login_WithRepository.Controllers
{
    public class UserController : Controller
    {
         HttpClient client = new HttpClient();
        

        public  async Task<ActionResult> GetUserList()
        {
            try
            {
                List<UserModel> userModels = new List<UserModel>();
                client.BaseAddress = new Uri("http://localhost:56052/api/");
                var response = await client.GetAsync("UserAPI/DisplayUserList");
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var result = await test.Content.ReadAsAsync<List<UserModel>>();
                    userModels = result;
                }
                else
                {
                    userModels = null;
                    ModelState.AddModelError(string.Empty, "server error");
                }
                return View(userModels);
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
        public async Task<ActionResult> GetUserDetailById(int id)
        {
            try
            {
                UserModel userModel = new UserModel();
                client.BaseAddress = new Uri("http://localhost:56052/api/");
                var responseURL = await client.GetAsync("UserAPI?id="+id);
                var status = responseURL.EnsureSuccessStatusCode();
                if (status.IsSuccessStatusCode)
                {
                    var result = await status.Content.ReadAsAsync<UserModel>();
                    userModel = result;
                }
                else
                {
                    userModel = null;
                    ModelState.AddModelError(string.Empty, "server error");
                }
                return View(userModel);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserModel userModel)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:56052/api/");
                var responseURL =  await client.PostAsJsonAsync<UserModel>("UserAPI", userModel);
                var status = responseURL.EnsureSuccessStatusCode();
                if (status.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetUserList");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "server error");
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                UserModel userModel = new UserModel();
                client.BaseAddress = new Uri("http://localhost:56052/api/");
                var responseURL = await client.GetAsync("UserAPI?id=" + id);
                var status = responseURL.EnsureSuccessStatusCode();
                if (status.IsSuccessStatusCode)
                {
                    var result = await status.Content.ReadAsAsync<UserModel>();
                    userModel = result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "server error");
                    return View();
                }
                return View(userModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit( UserModel userModel)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:56052/api/");
                var responseURL = await client.PostAsJsonAsync("UserAPI", userModel);
                var status = responseURL.EnsureSuccessStatusCode();
                if (status.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetUserList");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "server error");
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:56052/api/");
                var responseURL = await client.DeleteAsync("UserAPI?id=" + id);
                var status = responseURL.EnsureSuccessStatusCode();
                if (status.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetUserList");
                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "server error");
                    return View();
                }
                //return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}