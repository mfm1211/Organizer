using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrganizerWPF
{
    /// <summary>
    /// Interaction logic for RetractableWindow.xaml
    /// </summary>
    public partial class RetractableWindow : Window
    {
        public RetractableWindow(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
