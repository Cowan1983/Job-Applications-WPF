using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Applications_WPF
{
    public class TabControlContentConverter : BaseValueConverter<TabControlContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is TabItem.TabItemType tabContentType)
            {
                switch(tabContentType)
                {
                    case TabItem.TabItemType.JobLeadGrid:
                        return new JobLeadListControl();

                    case TabItem.TabItemType.JobLeadDisplay:
                        return new SingleJobLeadControl();

                    default:
                        break;
                }
            }

            return null;
        }

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
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
