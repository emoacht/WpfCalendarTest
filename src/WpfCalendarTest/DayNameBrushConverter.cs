using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfCalendarTest;

public class DayNameBrushConverter : IValueConverter
{
	public Brush DefaultBrush { get; set; } = Brushes.Gray;
	public Brush SundayBrush { get; set; } = Brushes.Gray;
	public Brush SaturdayBrush { get; set; } = Brushes.Gray;

	private (DayOfWeek dayOfWeek, string dayName)[]? _names;

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is string name)
		{
			_names ??= DayNameHelper.GetDayNames();

			foreach (var (dayOfWeek, dayName) in _names)
			{
				if (name == dayName)
				{
					return dayOfWeek switch
					{
						DayOfWeek.Sunday => SundayBrush,
						DayOfWeek.Saturday => SaturdayBrush,
						_ => DefaultBrush
					};
				}
			}
		}
		return DependencyProperty.UnsetValue;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}