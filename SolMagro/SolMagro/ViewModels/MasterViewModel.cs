using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SolMagro.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace SolMagro.ViewModels
{
    public class MasterViewModel : BindableBase
    {

        INavigationService navigationService;
        public MasterViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public ICommand NavigateCommand => new DelegateCommand<string>(NavigateCommandExecute);
        private async void NavigateCommandExecute(string pag)
        {
            await navigationService.NavigateAsync($"Master/NavigationPage/{pag}");
        }
    }
}
