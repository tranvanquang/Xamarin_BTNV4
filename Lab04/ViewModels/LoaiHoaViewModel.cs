using Lab04.Interface;
using Lab04.Models;
using Lab04.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab04.ViewModels
{
    class LoaiHoaViewModel : INotifyPropertyChanged
    {
        private LoaiHoa loaihoa;
        public ILoaiHoaRepository loaiHoaRepository;
        public ICommand AddLoaiHoa { get; private set; }
        public ICommand UpdateLoaiHoa { get; private set; }
        public ICommand DeleteLoaiHoa { get; private set; }

        public LoaiHoaViewModel()
        {
            loaiHoaRepository = new LoaiHoaRepository();
            LoadLoaiHoas();
            AddLoaiHoa = new Command(Insert);
            UpdateLoaiHoa = new Command(Update, CanExe);
            DeleteLoaiHoa = new Command(Delete, CanExe);
            loaihoa = new LoaiHoa();

        }
        private bool CanExe()
        {
            if (loaihoa == null || loaihoa.MaLoai == 0)
                return false;
            else
                return true;
        }

        private void Delete()
        {
            loaiHoaRepository.Delete(Loaihoa);
            LoadLoaiHoas();
        }


        private void Update()
        {
            loaiHoaRepository.Update(Loaihoa);
            LoadLoaiHoas();
        }
        private void Insert()
        {
            loaiHoaRepository.Insert(Loaihoa);
            LoadLoaiHoas();
        }


        public LoaiHoa Loaihoa
        {
            get { return loaihoa; }
            set
            {
                loaihoa = value;
                RaisePropertyChanged("Loaihoa");
                ((Command)UpdateLoaiHoa).ChangeCanExecute();
            }
        }

        public int MaLoai
        {
            get { return loaihoa.MaLoai; }
            set
            {             
                loaihoa.MaLoai = value;
                RaisePropertyChanged("MaLoai");

            }
        }

        public string TenLoai
        {
            get { return loaihoa.TenLoai; }
            set
            {
                loaihoa.TenLoai = value;
                RaisePropertyChanged("TenLoai");
            }
        }

        ObservableCollection<LoaiHoa> loaihoaList;
        public ObservableCollection<LoaiHoa> LoaihoaList
        {
            get { return loaihoaList; }
            set
            {
                loaihoaList = value;
                RaisePropertyChanged("LoaihoaList");
            }
        }


        void LoadLoaiHoas()
        {
            LoaihoaList = loaiHoaRepository.GetLoaiHoas();
        }

        public void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
