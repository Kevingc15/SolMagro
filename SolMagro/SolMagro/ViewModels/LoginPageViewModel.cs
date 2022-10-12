using Android.Service.QuickSettings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using SolMagro.Contracts.Repositories;
using SolMagro.Helpers;
using SolMagro.Models;
using SolMagro.Models.Request;
using SolMagro.Models.Response;
using SolMagro.Repositories;
using SolMagro.Services;
using SolMagro.ViewModels.Items;
using SolMagro.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SolMagro.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        IUserRepository userRepository;
        ContextViewModel context;
        INavigationService navigationService;
        FileService fileService;
        public LoginPageViewModel(IUserRepository userRepository,
                                    ContextViewModel context,
                                    INavigationService navigationService,
                                    FileService fileService)
        {
            User = new UserLoginRequest();
            this.userRepository = userRepository;
            this.context = context;
            this.navigationService = navigationService;
            this.fileService = fileService;
        }

        public UserLoginRequest User { get; set; }
        public ICommand LoginCommand => new DelegateCommand(Login);
        private void Login()
        {
            try
            {
                if (LoginValidation())
                {
                    var response = userRepository.UserLogin(User);
                    if (response)
                    {
                        GetUserData(User);
                    }
                }
            }
            catch
            {

            }
        }


        private string text;
        public string Text { get => text; set => SetProperty(ref text, value); }

        private bool LoginValidation()
        {
            if (string.IsNullOrEmpty(User.Email))
            {
                Text = "Debe escribit un Email";

                return false;
            }
            else if (!Regex.IsMatch(User.Email.Trim(), @"^([+\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"))
            {
                Text = "Email incorrecto";

                return false;
            }

            if (string.IsNullOrEmpty(User.Password))
            {
                Text = "Escriba una contraseña";

                return false;
            }
            else if (User.Password.Length < 7)
            {
                Text = "La contraseña debe ser mayo a 7 digitos";
                return false;
            }

            return true;
        }

        private async void GetUserData(UserLoginRequest user)
        {
            try
            {
                var userResponse = userRepository.GetUserData(user);
                if(userResponse != null)
                {
                    context.User = userResponse;
                    await fileService.SaveAsync("User", userResponse);
                    await navigationService.NavigateAsync($"Master/NavigationPage/{NavigationConstants.Calendar}");
                }
            }
            catch
            {

            }
        }
    }
}
