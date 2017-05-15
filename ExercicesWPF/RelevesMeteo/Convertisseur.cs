using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RelevesMeteo
{
    public class TemplateConverter : IValueConverter
    {
        public DataTemplate determinedTemplate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Combobox</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Dictionnaire de ressources</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (((ComboBox) value).SelectedIndex == 0)
                determinedTemplate= (DataTemplate) ((ResourceDictionary) parameter)["dtListMeteo"];
           else
                determinedTemplate = (DataTemplate)((ResourceDictionary)parameter)["dtListGroupee"];

            return determinedTemplate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
