using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MyStore
{
    public class ConverterForColumns : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            foreach (object item in values)
            {
                if (item == null) continue;

                if (item.GetType() == typeof(DateTime))
                {
                    result += ((DateTime)item).ToShortDateString() + " ";
                }
                else
                {
                    result += item.ToString() + " ";
                }
            }

            return result.TrimEnd();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ConverterForColumns();
        }
    }
}
