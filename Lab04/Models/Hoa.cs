using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Models
{
    public class Hoa
    {
        [PrimaryKey, AutoIncrement]
        public int MaHoa { get; set; }
        public int MaLoai { get; set; }
        public string TenHoa { get; set; }
        public string Hinh { get; set; }
        public string Mota { get; set; }
        public int Gia { get; set; }
    }
}
