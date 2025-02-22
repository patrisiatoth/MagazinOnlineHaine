using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MagazinOnlineHaine.Models
{
    public class Wishlist
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
    }
}
