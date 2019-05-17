using AutoSuggestBoxMvvm.Common;

namespace AutoSuggestBoxMvvm.Model
{
    public class Patient: NotifyChangeProperty
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                 OnPropertyChanged(nameof(_id));
                
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(_name));

            }
        }

        public Patient(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public Patient()
        {

        }

        public override string ToString()
        {
            return $"{_id}-{_name}";
        }
    }
}
