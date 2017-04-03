using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarTest.Controls
{
    public class CalendarView : View
    {
        public static readonly BindableProperty HighlightedDaysProperty = BindableProperty.Create("HighlightedDays", typeof(List<DateTime>), typeof(CalendarView), new List<DateTime>());

        public List<DateTime> HighlightedDays
        {
            get { return (List<DateTime>)GetValue(HighlightedDaysProperty); }
            set { SetValue(HighlightedDaysProperty, value); }
        }

        private static readonly BindableProperty SelectedDateProperty = BindableProperty.Create("SelectedDate", typeof(DateTime), typeof(CalendarView), DateTime.Now);

        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public event EventHandler<DateTime> DateSelected;

        public void NotifyDateSelected(DateTime dateSelected)
        {
            DateSelected?.Invoke(this, dateSelected);
        }
    }
}
