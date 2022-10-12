using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SolMagro.Models;
using SolMagro.Services;
using SolMagro.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SolMagro.ViewModels
{
    public class CalendarPageViewModel : ViewModelBase
    {
        FileService fileService;
        public CalendarPageViewModel(INavigationService navigationService,
                                     FileService fileService)
            : base(navigationService)
        {
            this.fileService = fileService; 
            SelectedDate = DateTime.Today;
            Jobs = new List<Job>();
        }

        public User User { get; set; }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get => selectedDate;
            set => SetProperty(ref selectedDate, value);
        }

        private string textDate;
        public string TextDate
        {
            get => textDate;
            set => SetProperty(ref textDate, value);
        }

        private List<Job> jobs;
        public List<Job> Jobs
        {
            get => jobs;
            set => SetProperty(ref jobs, value);
        }
 
        public ICommand ConsultCommand => new DelegateCommand(ConsultCommandExecute);
        private void ConsultCommandExecute()
        {
            TextDate = SelectedDate.ToString("M");
            try
            {
                foreach (Job job in User.Jobs)
                {
                    if (job.Date == SelectedDate)
                    {
                        Jobs.Add(job);
                    }
                }
            }
            catch(Exception ex)
            {
                TextDate = ex.Message;
            }
            
        }
        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            User = await fileService.LoadAsync<User>("User"); 
        }

    }
}
