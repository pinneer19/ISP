using _153502_Logvinovich.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.UI.ValueConventers
{
    internal class IdToImageConventer: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            string path = Path.Combine(FileSystem.Current.AppDataDirectory, $"skill_{(int)value}.png");
            if (File.Exists(path))
                return ImageSource.FromFile(path);
            else
                return ImageSource.FromFile("default_image.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
