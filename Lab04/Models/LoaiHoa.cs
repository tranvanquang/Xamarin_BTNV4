using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Models
{
    public class LoaiHoa
    {
        [PrimaryKey, AutoIncrement]
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
}
