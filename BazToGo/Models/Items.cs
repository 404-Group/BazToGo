using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazToGo.Model
{
    public class Items : ObservableObject
    {
        public string Price { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string picture { get; set; }
     }   
}
    
   
  
