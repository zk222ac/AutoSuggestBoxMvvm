using System.Collections.ObjectModel;
using AutoSuggestBoxMvvm.Model;

namespace AutoSuggestBoxMvvm.Catalog
{
    public static class PatientCatalog
    {
        private static ObservableCollection<Patient> _patientCatalog;
        public static ObservableCollection<Patient> GetPatients()
        {
            _patientCatalog = new ObservableCollection<Patient>
            {
                new Patient(100, "zuhair"),
                new Patient(200, "khem"),
                new Patient(300, "dady"),
                new Patient(400, "popular"),
                new Patient(600, "ganga"),
                new Patient(500, "mizaroa"),
                new Patient(700, "boris")
            };
            for (int i = 0; i < 50; i++)
            {
                _patientCatalog.Add(new Patient(i, "Patient:" + i));
            }
            return _patientCatalog;

        }

    }
}
