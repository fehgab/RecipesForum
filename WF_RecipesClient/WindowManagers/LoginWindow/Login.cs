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
        private async Task<bool> login()
        {
            string userName = tbUserName.Text;
            string password = tbPassword.Text;

            clearLabels();

            if (validation)
            {
                bool log = await VerifyUserNamePassword(userName, password);
                if ((log))
                {
                    mainWindow.userName = userName;
                }
                else
                {
                    validation = false;
                    lPasswordError.Text = "Helytelen jelszó vagy felhasználónév.";
                }            
             }
            return validation;
        }
        private void clearLabels()
        {
            lEmailError.Text = "";
            lPasswordError.Text = "";
            validation = true;
        }

        public async Task<bool> VerifyUserNamePassword(string userName, string password)
        {
            var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext()));
            return await usermanager.FindAsync(userName, password) != null;
        }
    }
}
