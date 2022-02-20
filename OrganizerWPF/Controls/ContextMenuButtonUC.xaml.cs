using OrganizerWPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrganizerWPF.State.Navigators;

namespace OrganizerWPF.Controls
{
    /// <summary>
    /// Interaction logic for ContextMenuButtonUC.xaml
    /// </summary>
    public partial class ContextMenuButtonUC : UserControl
    {

        public static DependencyProperty EntriesProperty =
        DependencyProperty.Register("Entries",
            typeof(ObservableCollection<Tuple<ViewType,string, ICommand>>),
            typeof(ContextMenuButtonUC),
            new PropertyMetadata(null));

        public ContextMenu ContextMenu111 { get; set; } = new ContextMenu();

        public ObservableCollection<Tuple<ViewType, string, ICommand>> Entries
        {
            get
            {
                return (ObservableCollection<Tuple<ViewType, string, ICommand>>)GetValue(EntriesProperty);
            }

            set
            {
                SetValue(EntriesProperty, value);
            }
        }



     

      

        public string PanelSide { get; set; } = "left";
        



        public ContextMenuButtonUC()
        {
            InitializeComponent();

        }

       

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            if(PanelSide == "right")
                MainButton.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            else
                MainButton.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Left;
            MainButton.ContextMenu.PlacementTarget = MainButton;
           // MainButton.ContextMenu.PlacementTarget = MainButton;
            MainButton.ContextMenu.IsOpen = true;

         
          //  MainContextMenu.IsOpen = true;
          //  MainContextMenu.PlacementTarget = (sender as Button);



        }
    }
}
