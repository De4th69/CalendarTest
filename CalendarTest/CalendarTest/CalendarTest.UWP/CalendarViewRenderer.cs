using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using CalendarTest.Controls;
using CalendarTest.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CalendarTest.Controls.CalendarView), typeof(CalendarViewRenderer))]

namespace CalendarTest.UWP
{
    public class CalendarViewRenderer : ViewRenderer<CalendarTest.Controls.CalendarView, Windows.UI.Xaml.Controls.CalendarView>
    {
        private Windows.UI.Xaml.Controls.CalendarView _calendar;

        protected override void OnElementChanged(ElementChangedEventArgs<CalendarTest.Controls.CalendarView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                _calendar = new Windows.UI.Xaml.Controls.CalendarView
                {
                    VerticalFirstOfMonthLabelAlignment = Windows.UI.Xaml.VerticalAlignment.Top,
                    IsTodayHighlighted = true,
                    Language = "de-DE"
                };
                _calendar.SelectedDatesChanged += (sender, args) =>
                {
                    if (args.AddedDates == null) return;
                    Element.SelectedDate = args.AddedDates.First().Date;
                    Element.NotifyDateSelected(args.AddedDates.First().Date);
                };
                _calendar.CalendarViewDayItemChanging += (sender, args) =>
                {
                    if (args.Item != null && Element.HighlightedDays.Contains(args.Item.Date.Date))
                    {
                        args?.Item?.SetDensityColors(new List<Color> { Colors.Black });
                    }
                };
                SetNativeControl(_calendar);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CalendarTest.Controls.CalendarView.HighlightedDaysProperty.PropertyName)
            {
                _calendar.DataContext = Element.HighlightedDays;

            }
        }
    }
}
