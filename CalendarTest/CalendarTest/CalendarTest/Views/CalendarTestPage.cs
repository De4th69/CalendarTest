using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarTest.Controls;
using Xamarin.Forms;

namespace CalendarTest.Views
{
    public class CalendarTestPage : ContentPage
    {
        public CalendarTestPage()
        {
            var testDates = new List<DateTime>
            {
                DateTime.Today,
                DateTime.Today.AddDays(1),
                DateTime.Today.AddDays(4)
            };

            var calendarView = new CalendarView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HighlightedDays = testDates
            };

            var selectedDateLabel = new Label {HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = Device.GetNamedSize(NamedSize.Medium,typeof(Label))};
            selectedDateLabel.SetBinding(Label.TextProperty, new Binding(path: "SelectedDate", source: calendarView));

            Content = new StackLayout {Children = {selectedDateLabel, calendarView}};
        }
    }
}
