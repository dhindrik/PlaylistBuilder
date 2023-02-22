using System;
using System.Globalization;

namespace PlaylistBuilder.Converters;

public class ViewToColumnWidthConverter : IValueConverter
{
    public int NumberOfColumns { get; set; }
    public double Deducation { get; set; }


    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var view = (View)value;

        var width = view.Width - Deducation;

        return width / NumberOfColumns;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

