using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingHelperToolkit.Models
{
    public class Shopping
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public List<ShoppingItem> Items { get; set; } = new();
    }
}
