using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Serialization;
using HelperMVVMLib;
using Libraries.Model;
using JsonSerDeserLib;

namespace Libraries.ViewModel
{
    internal class MainWindowViewModel : HelpCommand
    {
        private string _name;
        public string Name {  get { return _name; } set { _name = value; OnPropertyChanged(Name); } }

        private string _surnname;
        public string SurName { get { return _surnname; } set { _surnname = value; OnPropertyChanged(SurName); } }

        private string _patronomyc;
        public string Patronomyc { get { return _patronomyc; } set { _patronomyc = value; OnPropertyChanged(Patronomyc); } }

        private string _age;
        public string Age { get { return _age; } set { _age = value; OnPropertyChanged(Age); } }

        private Human _select;
        public Human Select { get { return _select; } set { _select = value; OnPropertyChanged(nameof(Select)); } }

        public ObservableCollection<Human> Employees { get; set; }

        public BindableCommand Add { get; }
        public BindableCommand Remove { get; }
        private SerDeser serDeser = new SerDeser("C:\\Users\\user\\Desktop\\test");

        public MainWindowViewModel()
        {
            Employees = serDeser.DeserObsCollection<Human>("emp.json");
            Add = new BindableCommand(_ => AddEmployee());
            Remove = new BindableCommand(_ => RemoveEmployee());
        }

        public void AddEmployee()
        {
            bool isCheck = false;

            try
            {
                Convert.ToInt32(Age);
                isCheck = true;
            }
            catch (Exception ex) { Age = "ОШИБКА"; }

            if(isCheck)
            {
                Human human = new Human(Name, SurName, Patronomyc, Convert.ToInt32(Age));
                Employees.Add(human);
                serDeser.SerData<Human>(Employees, "emp.json");

            }
        }
        public void RemoveEmployee()
        {
            if(Select != null)
            {
                Employees.Remove(Select);
                serDeser.SerData<Human>(Employees, "emp.json");
            }
        }

    }
}
