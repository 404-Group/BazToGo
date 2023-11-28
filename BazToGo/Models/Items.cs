using CommunityToolkit.Mvvm.ComponentModel;

namespace BazToGo.Model
{
    public partial class Items : ObservableObject { 
        public int id { get; set; }
        public string details { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int cartQuantity;
    }
    
}
    
   
  
