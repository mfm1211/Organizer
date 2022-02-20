using PropertyChanged;
using System.ComponentModel;
using System.Windows.Input;


namespace OrganizerWPF
{

    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel: ViewModelBase;

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        protected void OnPropertyChanged(string propertName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }

        public virtual void Dispose() { }
    }
}
