using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace OrganizerWPF.Behaviors
{
    public class LocationChangedBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.LocationChanged += (sender, e) =>
            {
                if (AssociatedObject.OwnedWindows.Count > 0)
                {
                    AssociatedObject.OwnedWindows[0].Top = AssociatedObject.Top;

                    if (System.Windows.SystemParameters.WorkArea.Width - (AssociatedObject.Left + AssociatedObject.Width) > AssociatedObject.OwnedWindows[0].Width)
                    {
                        AssociatedObject.OwnedWindows[0].Left = AssociatedObject.Left + AssociatedObject.Width + 5;
                    }
                    else
                    {
                        AssociatedObject.OwnedWindows[0].Left = AssociatedObject.Left - (AssociatedObject.OwnedWindows[0].Width + 5);
                    }
                }
            };
        }

    }
}
