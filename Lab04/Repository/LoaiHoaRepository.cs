using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Lab04.Interface;
using Lab04.Models;

namespace Lab04.Repository
{
    public class LoaiHoaRepository : ILoaiHoaRepository
    {
        Helpers.Database db;
        public LoaiHoaRepository()
        {
            db = new Helpers.Database();
        }
        public bool Delete(LoaiHoa h)
        {
            return db.DeleteLoaiHoa(h);
        }

        public LoaiHoa GetLoaiHoaById(int MaLoai)
        {
            return db.GetLoaiHoaByid(MaLoai);
        }

        public ObservableCollection<LoaiHoa> GetLoaiHoas()
        {
            return new ObservableCollection<LoaiHoa>(db.GetLoaiHoas());
        }

        public bool Insert(LoaiHoa h)
        {
            return db.InsertLoaiHoa(h);
        }

        public bool Update(LoaiHoa h)
        {
            return db.UpdateLoaiHoa(h);
        }
    }
}
