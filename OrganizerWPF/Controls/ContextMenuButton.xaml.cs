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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrganizerWPF.Controls
{
    /// <summary>
    /// Interaction logic for ContextMenuButton.xaml
    /// </summary>
    public partial class ContextMenuButton : UserControl
    {
        public static DependencyProperty ContextMenu111Property =
      DependencyProperty.Register("ContextMenu111",
          typeof(ContextMenu),
          typeof(ContextMenuButton),
          new PropertyMetadata(null));


        public static DependencyProperty ContextDataCustomProperty =
    DependencyProperty.Register("ContextDataCustom",
        typeof(object),
        typeof(ContextMenuButton),
        new PropertyMetadata(null));


        public static DependencyProperty RelativeSourceCustomProperty =
DependencyProperty.Register("RelativeSourceCustom",
    typeof(object),
    typeof(ContextMenuButton),
    new PropertyMetadata(null));


        public static DependencyProperty HeightProperty =
   DependencyProperty.Register("Height",
       typeof(int),
       typeof(ContextMenuButton),
       new PropertyMetadata(null));

        public ContextMenu ContextMenu111
        {
            get
            {
                return (ContextMenu)GetValue(ContextMenu111Property);
            }

            set
            {
                SetValue(ContextMenu111Property, value);
            }
        }

        public object ContextDataCustom
        {
            get
            {
                return (object)GetValue(ContextDataCustomProperty);
            }

            set
            {
                SetValue(ContextDataCustomProperty, value);
            }
        }



        public object RelativeSourceCustom
        {
            get
            {
                return (object)GetValue(RelativeSourceCustomProperty);
            }

            set
            {
                SetValue(RelativeSourceCustomProperty, value);
            }
        }


        public int Height
        {
            get
            {
                return (int)GetValue(HeightProperty);
            }

            set
            {
                SetValue(HeightProperty, value);
            }
        }




        public ContextMenuButton()
        {
            InitializeComponent();
           
        }


        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu111.DataContext = RelativeSourceCustom;
            MainButton.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Left;
            MainButton.ContextMenu.PlacementTarget = MainButton;
            MainButton.ContextMenu.Tag = ContextDataCustom;
            MainButton.ContextMenu.IsOpen = true;


        }

    }
}
