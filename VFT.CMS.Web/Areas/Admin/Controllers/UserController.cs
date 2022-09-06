﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VFT.CMS.EntityFrameworkCore;
using VFT.CMS.Web.Areas.Admin.Models;
using VFT.CMS.Web.Areas.Admin.Models.UserViewModels;

namespace VFT.CMS.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserController : BaseController
    {
        private UserManager<CMSIdentityUser> userManager;
        private IUserValidator<CMSIdentityUser> userValidator;
        private IPasswordValidator<CMSIdentityUser> passwordValidator;
        private IPasswordHasher<CMSIdentityUser> passwordHasher;

        private CMSIdentityUser testUser = new CMSIdentityUser
        {
            UserName = "TestTestForPassword",
            Email = "testForPassword@test.test"
        };

        public UserController(UserManager<CMSIdentityUser> userMgr,
            IUserValidator<CMSIdentityUser> userValid, IPasswordValidator<CMSIdentityUser> passValid,
            IPasswordHasher<CMSIdentityUser> passHasher)
        {
            userManager = userMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passHasher;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            var users = userManager.Users.ToList();

            var usersModel = users.ConvertAll(x => new UserViewModel()
            {
                Id = x.Id.ToString(),
                UserName = x.UserName,
                Email = x.Email,
                DateRegistered = x.DateRegistered,
                FirstName = x.FirstName,
                LastName = x.LastName,
                AvatarURL = x.AvatarURL,
                NickName = x.NickName,
                Position = x.Position,
            });

            return View(usersModel);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel createVm)
        {
            if (ModelState.IsValid)
            {
                CMSIdentityUser user = new CMSIdentityUser
                {
                    UserName = createVm.Email,
                    Email = createVm.Email,
                    //extended properties
                    FirstName = createVm.FirstName,
                    LastName = createVm.LastName,
                    AvatarURL = "/images/user.png",
                    DateRegistered = DateTime.UtcNow.ToString(),
                    Position = "",
                    NickName = "",
                };

                IdentityResult result = await userManager.CreateAsync(user, createVm.Password);

                if (result.Succeeded)
                {
                    return Index();
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(createVm);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.TryAddModelError("", error.Description);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            CMSIdentityUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Index();
                }
                else
                {
                    AddErrors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }

            return View("Index", userManager.Users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            CMSIdentityUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id.ToString(),
                    UserName = user.UserName,
                    Email = user.Email,
                };

                return View(userViewModel);
            }
            else
            {
                return Index();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // the names of its parameters must be the same as the property of the User class if we use asp-for in the view
        // otherwise form values won't be passed properly
        public async Task<IActionResult> Edit(string id, string userName, string email)
        {
            CMSIdentityUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                // Validate UserName and Email 
                user.UserName = userName; // UserName won't be changed in the database until UpdateAsync is executed successfully
                user.Email = email;
                IdentityResult validUseResult = await userValidator.ValidateAsync(userManager, user);
                if (!validUseResult.Succeeded)
                {
                    AddErrors(validUseResult);
                }

                // Update user info
                if (validUseResult.Succeeded)
                {
                    // UpdateAsync validates user info such as UserName and Email except password since it's been hashed 
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            ;

            return View(user);
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id.ToString(),
                    UserName = user.UserName,
                };

                return View(userViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, string password)
        {
            CMSIdentityUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                // Validate password
                // Step 1: using built in validations
                //IdentityResult passwordResult = await userManager.CreateAsync(testUser, password);
                //if (passwordResult.Succeeded)
                //{
                //    await userManager.DeleteAsync(testUser);
                //}
                //else
                //{
                //    AddErrors(passwordResult);
                //}
                /* Step 2: Because of DI, IPasswordValidator<User> is injected into the custom password validator. 
                   So the built in password validation stop working here */
                IdentityResult validPasswordResult = await passwordValidator.ValidateAsync(userManager, user, password);
                if (validPasswordResult.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                }
                else
                {
                    AddErrors(validPasswordResult);
                }

                // Update user info
                if (validPasswordResult.Succeeded)
                {
                    AddPageAlerts(PageAlertType.Success, "Đổi mật khẩu thành công");

                    // UpdateAsync validates user info such as UserName and Email except password since it's been hashed 
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Người dùng không tìm thấy");
            }

            return View(user);
        }
    }
}
