using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace IccWorld2015
{
    public class ImageUrlConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                // May want to validate url for image types that are supported in Silverlight.
                // if (!ImageValidator.IsImageFileNameSupported((string)value)) return null;
                return new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));
            }
            catch { }
            return null;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
