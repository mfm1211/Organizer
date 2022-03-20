using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.WrappedModels
{
    public class BaseItemViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public int ListModelId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string FontColor { get; set; }
    }
}
