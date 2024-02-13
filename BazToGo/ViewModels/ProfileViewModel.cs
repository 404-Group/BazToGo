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
        public string _name;
        [ObservableProperty]
        public double _dcb;
        [ObservableProperty]
        public int _mealTrade;

        public ProfileViewModel()
        {
            Name = "John Doe";
            Dcb = 200;
            MealTrade = 10;
                
        }
    }
}
