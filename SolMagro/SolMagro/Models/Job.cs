using Prism.Mvvm;
using SolMagro.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SolMagro.Models
{
    public class Job : BindableBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Category { get; set; }
        public JobState State { get; set; }
        public DateTime Date { get; set; }
        public List<string> Comments { get; set; }
        public List<string> PhotosLink { get; set; }
    }
}
