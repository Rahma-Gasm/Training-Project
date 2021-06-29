using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaudiaDocumentManagement.Models;
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
            return RedirectToAction("index", "home");
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
                var result = await userManager.CreateAsync(user, model.PasswordHash);


                //check if the user created succsfuly 
                if (result.Succeeded)

                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
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
            //check if incoming model object is valid
            if (ModelState.IsValid)
            {
                //if valid, code will create new user



                var result = await signInManager.PasswordSignInAsync(model.UserName, model.PasswordHash, model.RmemberMe, false);


                //check if the user created succsfuly 
                if (result.Succeeded)

                {
                    
                    return RedirectToAction("index", "home");
                }

                    ModelState.AddModelError(string.Empty,"Invalid Credentials ");
                }
            return View(model);
        }
           
        }
    }







