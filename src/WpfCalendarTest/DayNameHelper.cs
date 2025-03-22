
namespace WpfCalendarTest;

public static class DayNameHelper
{
	public static (DayOfWeek dayOfWeek, string dayName)[] GetDayNames()
	{
		var date = DateTime.Today;
		while (date.DayOfWeek is not DayOfWeek.Sunday)
			date = date.AddDays(1);

		return Enumerable.Range(0, 7)
			.Select(x => ((DayOfWeek)x, date.AddDays(x).ToString("ddd").TrimEnd('.')))
			.ToArray();
	}
}