using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaudiaDocumentManagement.Models;
using SaudiaDocumentManagement.ViewModels;
using SaudiaDocumentManagment;

namespace SaudiaDocumentManagement.Controllers
{ 
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //check if incoming model object is valid
            if (ModelState.IsValid)
            {
                //if valid, code will create new user


                var user = new IdentityUser { UserName = model.UserName, Email = model.Email, PhoneNumber = model.PhoneNumber };
                var result = await userManager.CreateAsync(user, model.Password);

                await userManager.AddToRoleAsync(user, "Admin");
                //check if the user created succsfuly 
                if (result.Succeeded)

                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
               
                
                    else
                    {
                        ViewBag.MsgUser = "username is already taken";
                        return View("Register");
                    }
                

                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError("", error.Description);
                //}
            }
            //pass the model object to view,and display any validation error may happend 
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //if valid, code will create new user



                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);


                //check if the user created succsfuly 
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;
                if(!string.IsNullOrWhiteSpace(model.oldPass) || !string.IsNullOrWhiteSpace(model.Password)){
                    await userManager.ChangePasswordAsync(user, model.oldPass, model.Password);

                }

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                       await signInManager.RefreshSignInAsync(user);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            EditViewModel model;

            if (string.IsNullOrWhiteSpace(id))
            {
                System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                id = userManager.GetUserId(User); // Get user id:
            }
            // Find the user by user ID
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                model = new EditViewModel();
                model.Id = user.Id;
                model.Email = user.Email;
                model.PhoneNumber = user.PhoneNumber;
                model.UserName = user.UserName;
            }

            return View(model);
        }
        [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
        {
            ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
            return View("NotFound");
        }
        else
        {
            var result = await userManager.DeleteAsync(user);
            
            if (result.Succeeded)
            {
                return RedirectToAction("ListUsers", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            
            try{
            foreach (var modelState in ViewData.ModelState.Values) {
                foreach (var error in modelState.Errors) {
                    Console.WriteLine("Error: " + ModelState.Values);
                }
            }
            }catch(Exception ex){
                    Console.WriteLine(ex.Message);
            }
            return RedirectToAction("ListUsers", "Account");
        }
    }
        [HttpGet]
    public IActionResult ListUsers()
    {
        var users = userManager.Users;
        return View(users);
    }

    }
}







