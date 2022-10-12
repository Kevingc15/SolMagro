using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using SolMagro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolMagro.ViewModels.Items
{
    public class ContextViewModel : BindableBase
    {
        private readonly INavigationService navigationService;

        public ContextViewModel(INavigationService navigationService,
            IDialogService dialogService)
        {
            this.navigationService = navigationService;
        }

        public User User { get; set; }

    }
}
