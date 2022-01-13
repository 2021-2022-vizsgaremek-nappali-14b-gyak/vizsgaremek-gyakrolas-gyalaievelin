using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaremek.Repositories;
using Vizsgaremek.Models;

namespace Vizsgaremek.ViewModels
{
    public class DatabaseSourceViewModel
    {
        private ObservableCollection<string> displayedDatabaseSources;
        private string selectedDatabaseSource;
        DatabaseSources repoDatabaseSources;
        private DbSource dbSource;
    

        public DatabaseSourceViewModel()
        {
            repoDatabaseSources = new DatabaseSources();
            displayedDatabaseSources = new ObservableCollection<string>(repoDatabaseSources.GetAllDatabaseSources());
        }

        public DbSource DbSource
        {
            get
            {
                return DbSource.NONE;
            }
        }

        public ObservableCollection<string> DisplayedDatabaseSource { get => displayedDatabaseSources; set => displayedDatabaseSources = value; }
        public string SelectedDatabaseSource { get => selectedDatabaseSource; set => selectedDatabaseSource = value; }
    }
}
