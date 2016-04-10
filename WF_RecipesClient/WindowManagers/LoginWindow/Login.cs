using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WF_RecipesClient.RecipesModel;

namespace WF_RecipesClient
{
    partial class LoginForm
    {
        private bool validation = true;
        private async void login()
        {
            string email = tbEmail.Text;
            string password = tbPassword.Text;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            clearLabels();

            if (match.Success)
            {
                using (var db = new RecipesModel.RecipesModel())
                {
                    var user = db.AspNetUsers.Where(u => u.Email.Equals(email)).ToList();
                    if (!user.Any())
                    {
                        lEmailError.Text = ("Nincs ilyen e-mail cím, előbb regisztrálj!");
                        validation = false;
                    }
                }
            }

            else
            {
                lEmailError.Text = ("Nem megfelelő formátumú email-cím.");
                validation = false;
            }

            if (validation)
            {
                if(!(await VerifyUserNamePassword(email, password)))
                {
                    validation = false;
                }               
             }
        }
        private void clearLabels()
        {
            lEmailError.Text = "";
            lPasswordError.Text = "";
            validation = true;
        }

        public async Task<bool> VerifyUserNamePassword(string email, string password)
        {
            var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext()));
            return await usermanager.FindAsync(email, password) != null;
        }
    }
}
