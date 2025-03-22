using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace WpfCalendarTest;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		ChangeCulture("en-US");
	}

	private void ChangeCulture(string cultureName)
	{
		var c = new CultureInfo(cultureName);
		Thread.CurrentThread.CurrentCulture = c;
		Thread.CurrentThread.CurrentUICulture = c;

		var oldNames = c.DateTimeFormat.ShortestDayNames;

		// Replace DateTimeFormatInfo.ShortestDayNames.
		// These names are used to fill day title of week.
		// https://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/Windows/Controls/Primitives/CalendarItem.cs,1024
		c.DateTimeFormat.ShortestDayNames = DayNameHelper.GetDayNames().Select(x => x.dayName).ToArray();

		var newNames = c.DateTimeFormat.ShortestDayNames;

		for (int i = 0; i < oldNames.Length; i++)
		{
			Debug.WriteLine($"[{i}] {oldNames[i]} -> {newNames[i]}");
		}
	}
}