using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab04.Helpers
{
    class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public Database()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.CreateTable<Models.LoaiHoa>();
                    connection.CreateTable<Models.Hoa>();
                }
            }
            catch
            {

            }
        }

        public List<Models.LoaiHoa> GetLoaiHoas()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<Models.LoaiHoa>().ToList();
                }

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public Models.LoaiHoa GetLoaiHoaByid(int Maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var lh = from l in connection.Table<Models.LoaiHoa>().ToList()
                             where l.MaLoai == Maloai
                             select l;
                    return lh.ToList().FirstOrDefault();
                }

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public bool InsertLoaiHoa(Models.LoaiHoa loaiHoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(loaiHoa);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool UpdateLoaiHoa(Models.LoaiHoa loaiHoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Update(loaiHoa);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public bool DeleteLoaiHoa(Models.LoaiHoa loaiHoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Delete(loaiHoa);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
    }
}
