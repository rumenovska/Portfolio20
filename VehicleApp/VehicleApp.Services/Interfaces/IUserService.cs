using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterViewModel registerModel);
        void Login(LoginViewModel loginModel);
        void Logout();
        UserViewModel GetCurrentUser(string username);
    }
}
