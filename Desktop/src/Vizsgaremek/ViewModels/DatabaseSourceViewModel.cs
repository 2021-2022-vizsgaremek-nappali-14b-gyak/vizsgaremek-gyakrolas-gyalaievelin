using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaremek.Repositories;

namespace Vizsgaremek.ViewModels
{
    class DatabaseSourceViewModel
    {
        private ObservableCollection<string> displayedDatabaseSources;
        private string selectedDatabaseSource;
        DatabaseSources repoDatabaseSources;

        public DatabaseSourceViewModel()
        {
            repoDatabaseSources = new DatabaseSources();
            displayedDatabaseSources = new ObservableCollection<string>(repoDatabaseSources.GetAllDatabaseSources());
        }

        public ObservableCollection<string> DisplayedDatabaseSource { get => displayedDatabaseSources; set => displayedDatabaseSources = value; }
        public string SelectedDatabaseSource { get => selectedDatabaseSource; set => selectedDatabaseSource = value; }
    }
}
