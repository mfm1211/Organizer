using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace OrganizerWPF.Behaviors
{
    class DragBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseDown += (sender, e) =>
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    AssociatedObject.DragMove();

                    
                }
                    
            };
        }

    }
}
