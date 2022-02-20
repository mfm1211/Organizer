using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace OrganizerWPF.Converters
{
    class BoolToStyleConverter : IValueConverter
    {
        public Style SuccessStyle { get; set; }

        public Style FailureStyle { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? SuccessStyle : FailureStyle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new InvalidOperationException();
        }
    }
}
