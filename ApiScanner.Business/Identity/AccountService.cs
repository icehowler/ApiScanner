﻿using ApiScanner.Business.Utility;
using ApiScanner.Entities;
using ApiScanner.Entities.DTOs;
using ApiScanner.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiScanner.Business.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RegexUtilities _regexUtilities;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _regexUtilities = new RegexUtilities();
        }

        public async Task<(bool Success, IEnumerable<string> Errors)> Register(UserDTO user)
        {
            // Validate email address
            if (!_regexUtilities.IsValidEmail(user.Email))
                return (false, new string[1] { BadRequestType.InvalidEmail.ToString() });

            var newUser = new ApplicationUser
            {
                UserName = user.Email,
                Email = user.Email,
                Subscribe = user.Subscribe ?? false
            };

            var userCreationResult = await _userManager.CreateAsync(newUser, user.Password);
            if (!userCreationResult.Succeeded)
                return (false, userCreationResult.Errors.Select(e => e.Code));

            return (true, new List<string>());
        }

        public async Task<(bool Success, ApplicationUser User, string Error)> Login (UserDTO user)
        {
            var dbUser = await _userManager.FindByEmailAsync(user.Email);
            if (dbUser == null)
                return (false, null, BadRequestType.UserOrPassIncorrect.ToString());

            // Check if application is configued to accept logins only on confirmed emails
            if (!dbUser.EmailConfirmed && _userManager.Options.SignIn.RequireConfirmedEmail)
                return (false, null, BadRequestType.EmailNotConfirmed.ToString());

            var passwordSignInResult = await _signInManager.PasswordSignInAsync(dbUser, user.Password, isPersistent: user.RememberLogin ?? false, lockoutOnFailure: false);
            if (!passwordSignInResult.Succeeded)
                return (false, null, BadRequestType.UserOrPassIncorrect.ToString());

            return (true, dbUser, null);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUser> AccountData(string account)
        {
            var user = await _userManager.FindByNameAsync(account);
            return user;
        }

        public async Task<(bool Success, IEnumerable<string> Errors)> ResetPassword (UserDTO user)
        {
            var dbUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id.Equals(user.Id));
            if (dbUser == null)
                return (false, new string[1] { BadRequestType.UserNotFound.ToString() });

            if (user.Password != user.PasswordRepeat)
                return (false, new string[1] { BadRequestType.PasswordMissmatch.ToString() });

            var resetPasswordResult = await _userManager.ResetPasswordAsync(dbUser, user.ResetToken, user.Password);
            if (!resetPasswordResult.Succeeded)
                return (false, resetPasswordResult.Errors.Select(e => e.Code));

            return (true, new List<string>());
        }
    }
}