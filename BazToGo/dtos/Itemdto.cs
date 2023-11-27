using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazToGo.dtos
{
    internal partial class Itemdto : ObservableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ObservableProperty]
        private string? _image;

        public decimal Price { get; set; }
        public string Unit { get; set; }
        public short CategoryId { get; set; }

        [ObservableProperty]
        private int _cartQuantity;
        public Itemdto(int id, string name, string? image, decimal price, string unit, short categoryId)
        {
            Id = id;
            Name = name;
            Image = image;
            Price = price;
            Unit = unit;
            CategoryId = categoryId;
        }
    }
}

