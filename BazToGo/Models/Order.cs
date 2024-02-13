using BazToGo.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazToGo.Models
{
    public class Order : ObservableObject
    {
        public ObservableCollection<Items> items = new();
        public string name;
        public string number;
        public string payment;
        public TimeSpan time;
        public double total;
    }
}
