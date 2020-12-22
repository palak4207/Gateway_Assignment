using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SourceControlFinalAssignment.DBContext;
using SourceControlFinalAssignment.Models;

namespace SourceControlFinalAssignment.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }



        public IActionResult Dashboard(User user)
        {
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLogin userLogin)
        {
            if(ModelState.IsValid)
            {
                var users = _db.Users.ToList();
                foreach (var user in users)
                {
                    if(user.Email==userLogin.Email && user.Password == userLogin.Password)
                    {
                        return RedirectToAction("Dashboard",user);
                    }
                }
                ModelState.AddModelError("NotFound", "Email or Password is invalid");
            }
            return View(userLogin);
        }

        public async void StoreUserImage(IFormFile formFile, string imagePath)
        {
            using (var stream = System.IO.File.Create(imagePath))
            {
                await formFile.CopyToAsync(stream);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserSignup usersignup)
        {
            if(ModelState.IsValid)
            {
                var users = _db.Users.ToList();
                foreach(var user in users)
                {
                    if(user.Email == usersignup.Email)
                    {
                        ModelState.AddModelError("EmailExits", "Email Already Exits");
                        return View(usersignup);
                    }

                }

                var imagePath = $"C:/user images/{usersignup.Email}{Path.GetExtension(usersignup.Image.FileName)}";

                StoreUserImage(usersignup.Image, imagePath);

                var myUser = new User
                {
                    FirstName = usersignup.FirstName,
                    LastName = usersignup.LastName,
                    Image = imagePath,
                    PhoneNo = usersignup.PhoneNo,
                    Email = usersignup.Email,
                    Password = usersignup.Password,
                    Age = usersignup.Age,
                };

                _db.Users.Add(myUser);
                _db.SaveChanges();
                return RedirectToAction("Dashboard",myUser);
            }
            return View();
        }
    }
}
