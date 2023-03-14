using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfMagyarVarosok.Models;

namespace WpfMagyarVarosok
{
    public class ContextAdapter
    {
        public magyar_telepulesekContext context;

        public ObservableCollection<Jogallas> Jogallasok { get; set; }
        public ObservableCollection<Megyek> Megyek { get; set; }
        public ObservableCollection<Telepulesek> Telepulesek { get; set; }


        public ContextAdapter()
        {
            context = new magyar_telepulesekContext();
            context.Telepulesek.Load();
            context.Jogallas.Load();
            context.Megyek.Load();

            Jogallasok = context.Jogallas.Local.ToObservableCollection();
            Megyek= context.Megyek.Local.ToObservableCollection();
            Telepulesek= context.Telepulesek.Local.ToObservableCollection();
        }




    }
}
