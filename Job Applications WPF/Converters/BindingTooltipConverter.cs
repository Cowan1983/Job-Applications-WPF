using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Job_Applications_WPF
{
    //class MultiBindingTooltipConverter : MarkupExtension, IMultiValueConverter
    //{

    //    public override object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        return this;
    //    }

    //    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
    //            return null;
    //        return string.Format("{0} - {1}", values);
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }


    //}

    public class BindingTooltipConverter : BaseValueConverter<BindingTooltipConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == DependencyProperty.UnsetValue) return null;

            return value;
        }

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            //if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
            //    return null;
            //return string.Format("{0} - {1}", values);

            //First, convert the array to a list
            List<object> inputList = new List<object>(values);

            //Do the test to see that all the values have been set
            if (inputList.Contains(DependencyProperty.UnsetValue)) return null;

            //Return each provided value with a newline char
            return string.Join("\n", inputList);

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
