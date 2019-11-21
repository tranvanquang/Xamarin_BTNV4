using Lab04.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lab04.Interface
{
    public interface ILoaiHoaRepository
    {
        ObservableCollection<LoaiHoa> GetLoaiHoas();
        LoaiHoa GetLoaiHoaById(int MaLoai);
        bool Insert(LoaiHoa h);
        bool Update(LoaiHoa h);
        bool Delete(LoaiHoa h);
    }
}
