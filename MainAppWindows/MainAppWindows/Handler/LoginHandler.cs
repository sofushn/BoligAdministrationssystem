using MainAppWindows.Models;
using MainAppWindows.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAppWindows.Handler
{
    public class LoginHandler
    {
        private LoginViewModel VM;

        public LoginHandler() { }
        public LoginHandler(LoginViewModel loginViewModel)
        {
            VM = loginViewModel;
        }

        public bool GetAccountForLogin()
        {
            return false;
        }

        //Need to get a username and check if password match
        public Andelshaver Login(int anID)
        {
            return Persistency.PersistencyFacade.GetAndelshaver(anID);
        }
    }
}
