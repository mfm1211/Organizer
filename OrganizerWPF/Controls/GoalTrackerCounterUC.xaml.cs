using OrganizerLibrary;
using OrganizerWPF.ViewModels.WrappedModels;
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
    /// Interaction logic for GoalTrackerCounterUC.xaml
    /// </summary>
    public partial class GoalTrackerCounterUC : UserControl
    {
        public static DependencyProperty DisplayedNumberProperty =
        DependencyProperty.Register(
            "DisplayedNumber",
            typeof(int),
            typeof(GoalTrackerCounterUC),
            new PropertyMetadata(null));

      

        public static DependencyProperty ChangeDisplayedNumberProperty =
    DependencyProperty.Register(
      "ChangeDisplayedNumber",
      typeof(ICommand),
      typeof(GoalTrackerCounterUC),
      new PropertyMetadata(default(ICommand)));


    

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
    "CommandParameter",
    typeof(GoalTrackerViewModel),
    typeof(GoalTrackerCounterUC),
    new FrameworkPropertyMetadata(null));



        public static DependencyProperty CheckboxVisibilityProperty =
        DependencyProperty.Register(
            "CheckboxVisibility",
            typeof(bool),
            typeof(GoalTrackerCounterUC),
            new PropertyMetadata(null));


        public GoalTrackerCounterUC()
        {
            InitializeComponent();
        }




     


        public GoalTrackerViewModel CommandParameter
        {
            get
            {
                return (GoalTrackerViewModel)GetValue(CommandParameterProperty);
            }

            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }



        public int DisplayedNumber
        {
            get
            {
                return (int)GetValue(DisplayedNumberProperty);
            }

            set
            {
                SetValue(DisplayedNumberProperty, value);
            }
        }



        public bool CheckboxVisibility
        {
            get
            {
                return (bool)GetValue(CheckboxVisibilityProperty);
            }

            set
            {
                SetValue(CheckboxVisibilityProperty, value);
            }
        }



    


      

        public ICommand ChangeDisplayedNumber
        {
            get
            {
                return (ICommand)GetValue(ChangeDisplayedNumberProperty);
            }

            set
            {
                SetValue(ChangeDisplayedNumberProperty, value);
            }
        }


       

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.RightButton.Visibility == Visibility.Collapsed)
            {
                this.RightButton.Visibility = Visibility.Visible;
                this.LeftButton.Visibility = Visibility.Visible;
            }
        }


        private void Buttons_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.RightButton.Visibility == Visibility.Visible && MainButton.IsMouseOver == false && LeftButton.IsMouseOver == false && RightButton.IsMouseOver == false)
            {
                this.RightButton.Visibility = Visibility.Collapsed;
                this.LeftButton.Visibility = Visibility.Collapsed;
            }
        }

      

       
        private void LeftButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DisplayedNumber = DisplayedNumber - 1;       
            }
            else
            {
                DisplayedNumber = DisplayedNumber - 10;
            }


            ChangeDisplayedNumber.Execute(CommandParameter);
        }

        private void RightButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DisplayedNumber = DisplayedNumber + 1;
            }
            else
            {
                DisplayedNumber = DisplayedNumber + 10;
            }


            ChangeDisplayedNumber.Execute(CommandParameter);
        }

        private void CheckboxButton_Click(object sender, RoutedEventArgs e)
        {
            if (DisplayedNumber == 0)
                DisplayedNumber = 1;
            else
                DisplayedNumber = 0;
        }
    }
}
