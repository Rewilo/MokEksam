using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MokEksam.Common.Converter
{
    class NotClickableWhenInvalidUsername : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == (object) false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
