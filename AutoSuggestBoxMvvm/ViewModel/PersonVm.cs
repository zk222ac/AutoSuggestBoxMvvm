using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using AutoSuggestBoxMvvm.Catalog;
using AutoSuggestBoxMvvm.Command;
using AutoSuggestBoxMvvm.Common;
using AutoSuggestBoxMvvm.Model;

namespace AutoSuggestBoxMvvm.ViewModel
{
    public class PersonVm : NotifyChangeProperty
    {
        private ObservableCollection<Patient> _patients;
        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(_patients));
            }

        }

        private string _displayChosenText = "Patient Info";

        public string DisplayChosenText
        {
            get => _displayChosenText;
            set
            {
                _displayChosenText = value;
                OnPropertyChanged(nameof(DisplayChosenText));
            }
        } 

        // ICommand ..................................
        public ICommand SuggessionSelectPatientQuerySubmitted => new RelayCommandArgs<AutoSuggestBoxQuerySubmittedEventArgs>(SuggessionSelectPatientQuerySubmittedDelegateMethod);

        private void SuggessionSelectPatientQuerySubmittedDelegateMethod(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
          
            if (args.ChosenSuggestion != null)
            {
                string id = ((Patient) (args.ChosenSuggestion)).Id.ToString();
                string name = ((Patient) (args.ChosenSuggestion)).Name.ToString();
                // when we select patient from suggestbox it display id and name on textbox
                DisplayChosenText = id + "-" + name;
            }
            else
            {
               // always refresh the Patient List
                RefreshPatientList();

                // when you press enter or side find bar then see the filter results
                var filterData = _patients.Where(a => (a.Name ?? "").ToLower().Contains(args.QueryText.ToLower()));
                ObservableCollection<Patient> filterList = new ObservableCollection<Patient>();
                filterList.Clear();
                foreach (var item in filterData)
                {
                    filterList.Add(item);
                }

                _patients = filterList;
            }
        }

        public void RefreshPatientList()
        {
            _patients = PatientCatalog.GetPatients();
        }


        public PersonVm()
        {
            _patients = new ObservableCollection<Patient>();
            _patients = PatientCatalog.GetPatients();
            
        }



    }
}
