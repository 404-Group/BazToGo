using CommunityToolkit.Mvvm.ComponentModel;

namespace BazToGo.Model
{
    public partial class Items : ObservableObject {
        [ObservableProperty]
        public int _id;
        [ObservableProperty]
        public string _details;
        [ObservableProperty]
        public string _name;
        [ObservableProperty]
        public double _price;
        [ObservableProperty]
        public string _image;
        [ObservableProperty]
        public int _quantity;
        public int cartQuantity;
    }
    
}
    
   
  
