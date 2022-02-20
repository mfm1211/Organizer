using OrganizerLibrary.Models;
using OrganizerWPF.State.Navigators;
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

namespace OrganizerWPF.Controls
{
    /// <summary>
    /// Interaction logic for ComboboxWithArrowsUC.xaml
    /// </summary>
    public partial class ComboboxWithArrowsUC : UserControl
    {


        public static DependencyProperty ListOfListObjsForComboboxProperty =
DependencyProperty.Register(
"ListOfListObjsForCombobox",
typeof(List<Tuple<int, string>>),
typeof(ComboboxWithArrowsUC),
 new PropertyMetadata(OnListChangedCallBack));

        public static DependencyProperty SelectedListTupleProperty =
DependencyProperty.Register(
"SelectedListTuple",
typeof(Tuple<int, string>),
typeof(ComboboxWithArrowsUC),
 new PropertyMetadata(null));


        public List<Tuple<int, string>> ListOfListObjsForCombobox
        {
            get
            {
                return (List<Tuple<int, string>>)GetValue(ListOfListObjsForComboboxProperty);
            }

            set
            {
                SetValue(ListOfListObjsForComboboxProperty, value);
            }
        }



        public Tuple<int, string> SelectedListTuple
        {
            get
            {
                return (Tuple<int, string>)GetValue(SelectedListTupleProperty);
            }

            set
            {
                SetValue(SelectedListTupleProperty, value);
            }
        }



        public bool LeftButtonVisibility { get; set; } = true;

        public bool RightButtonVisibility { get; set; } = true;


        public ComboboxWithArrowsUC()
        {
            InitializeComponent();
        }


        private static void OnListChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //int a = (sender as ComboboxWithArrowsUC).ListOfListObjsForCombobox.Count;

            //(sender as ComboboxWithArrowsUC).arrowLeft.Visibility = Visibility.Collapsed;
            //(sender as ComboboxWithArrowsUC).arrowRight.Visibility = Visibility.Collapsed;
        }





        private void arrowLeft_Click(object sender, RoutedEventArgs e)
        {
            Tuple<int, string> currentPair = ListOfListObjsForCombobox.Find(x => x.Item1 == SelectedListTuple.Item1);

            int place = ListOfListObjsForCombobox.IndexOf(currentPair);

            SelectedListTuple = ListOfListObjsForCombobox[place - 1];

            //ChangeDisplayedList.Execute(place-1);
        }

        private void arrowRight_Click(object sender, RoutedEventArgs e)
        {
            Tuple<int, string> currentPair = ListOfListObjsForCombobox.Find(x => x.Item1 == SelectedListTuple.Item1);

            int place = ListOfListObjsForCombobox.IndexOf(currentPair);

            SelectedListTuple = ListOfListObjsForCombobox[place + 1];

            //ChangeDisplayedList.Execute(place + 1);

        }

        private void listCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedListTuple == null)
            {
                arrowLeft.Visibility = Visibility.Collapsed;
                arrowRight.Visibility = Visibility.Collapsed;
                return;
            }




            Tuple<int, string> currentPair = ListOfListObjsForCombobox.Find(x => x.Item1 == SelectedListTuple.Item1);

            int place = ListOfListObjsForCombobox.IndexOf(currentPair);
            RightButtonVisibility = place < ListOfListObjsForCombobox.Count - 1;
            if (RightButtonVisibility == false)
            {
                arrowRight.Visibility = Visibility.Collapsed;
            }
            else
            {
                arrowRight.Visibility = Visibility.Visible;
            }


            LeftButtonVisibility = place > 0;
            if (LeftButtonVisibility == false)
            {
                arrowLeft.Visibility = Visibility.Collapsed;
            }
            else
            {
                arrowLeft.Visibility = Visibility.Visible;
            }
        }


    }
}
