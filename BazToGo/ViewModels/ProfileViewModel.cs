using BazToGo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazToGo.ViewModels
{
    public partial class ProfileViewModel:ObservableObject
    {
        [ObservableProperty]
        public string _firstName = "Guest";
        [ObservableProperty]
        public string _lastName = "";
        [ObservableProperty]
        public double _dcb;
        [ObservableProperty]
        public int _mealTrade;

        public ProfileViewModel()
        {
        }

    }
}
