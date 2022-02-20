using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace OrganizerWPF.Converters
{
    class IneqalityResultToBoolConverter : IValueConverter
    {
        public bool IsGraterThanTrue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

           
           if (IsGraterThanTrue)
                return System.Convert.ToInt32(value) > System.Convert.ToInt32(parameter);
           else
                return System.Convert.ToInt32(value) < System.Convert.ToInt32(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }
}
