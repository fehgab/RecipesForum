﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebPPublished.Models;
using WF_RecipesClient.RecipesModel;

namespace WF_RecipesClient
{
    partial class RegistrationForm
    {
        bool validation = true;

        private void createUser()
        {
            string displayName = tbDisplayName.Text;
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            clearLabels();

            if (match.Success)
            {
                using (var db = new RecipesModel.RecipesModel())
                {
                    var user = db.AspNetUsers.Where(u => u.Email.Equals(email)).ToList();
                    if (user.Any())
                    {
                        lEmailError.Text = ("Az email-címmel már regisztráltak.");
                        validation = false;
                    }
                }
            }

            else
            {
                lEmailError.Text = ("Nem megfelelő formátumú email-cím.");
                validation = false;
            }
            
            if (!password.Equals(confirmPassword))
            {
                lConfirmPasswordError.Text = ("A jelszavak nem egyeznek meg.");
                validation = false;
            }
            if (password.Length < 8)
            {
                lPasswordError.Text = ("A jelszó legalább 8 kakarkter hosszú legyen.");
                validation = false;
            }
            if (displayName.Length == 0)
            {
                lDisplayNameError.Text = ("Mindenképp adj meg nevet!");
                validation = false;
            }

            if(validation)
            {
                using (var db = new ApplicationDbContext())
                {
                    var store = new UserStore<ApplicationUser>(db);
                    var manager = new UserManager<ApplicationUser>(store);
                    var user = new ApplicationUser
                    {
                        UserName = displayName,
                        Email = email,
                        EmailConfirmed = true
                    };
                    manager.Create(user, password);
                    manager.AddToRole(user.Id, "Users");
                    db.SaveChanges();
                }
            }
        }

        private void clearLabels()
        {
            lDisplayNameError.Text = "";
            lEmailError.Text = "";
            lPasswordError.Text = "";
            lConfirmPasswordError.Text = "";
            validation = true;
        }
    }
}