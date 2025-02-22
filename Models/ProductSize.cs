﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MagazinOnlineHaine.Models
{
    public class ProductSize
    {
        [ForeignKey(typeof(Product))]
        public int ProductId { get; set; }

        [ForeignKey(typeof(Size))]
        public int SizeId { get; set; }
    }
}
