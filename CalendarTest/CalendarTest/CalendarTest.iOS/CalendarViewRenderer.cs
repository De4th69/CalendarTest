using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CalendarTest.iOS;
using Foundation;
using Softweb.Xamarin.Controls.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CalendarTest.Controls.CalendarView), typeof(CalendarViewRenderer))]

namespace CalendarTest.iOS
{
    public class CalendarViewRenderer : ViewRenderer<CalendarTest.Controls.CalendarView, CalendarContentView>
    {
        private Calendar _calendar;

        protected override void OnElementChanged(ElementChangedEventArgs<CalendarTest.Controls.CalendarView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                _calendar = new Calendar();

                var menuView = new CalendarMenuView { Frame = new CoreGraphics.CGRect(0f, 0f, UIScreen.MainScreen.Bounds.Width - 10, 42f) };

                var contentView = new CalendarContentView
                {
                    Frame = new CoreGraphics.CGRect(0f, 0f, UIScreen.MainScreen.Bounds.Width - 10, (UIScreen.MainScreen.Bounds.Height / 2) - 42f),
                    BackgroundColor = UIColor.White
                };

                var appearance = _calendar.CalendarAppearance;
                appearance.DayCircleColorSelected = UIColor.Orange;
                appearance.DayCircleRatio = (9f / 10f);
                appearance.WeekDayFormat = CalendarWeekDayFormat.Single;
                appearance.GetNSCalendar().FirstWeekDay = 2;
                appearance.SetMonthLabelTextCallback((NSDate date, Calendar cal) => new Foundation.NSString(((DateTime)date).ToString("MMMM yyyy")));

                _calendar.ContentView = contentView;
                _calendar.DateSelected += (sender, args) =>
                {
                    Element.SelectedDate = (DateTime)args.Date;
                    Element.NotifyDateSelected((DateTime)args.Date);
                };

                var view = new UIView
                {
                    Frame = new CoreGraphics.CGRect(0f, 0f, UIScreen.MainScreen.Bounds.Width - 10, UIScreen.MainScreen.Bounds.Height / 2)
                };

                HighlightDays();

                view.Add(menuView);
                view.Add(contentView);
                SetNativeControl(_calendar.ContentView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CalendarView.HighlightedDaysProperty.PropertyName)
            {
                HighlightDays();
            }
        }

        private void HighlightDays()
        {
            var eventSchedule = new List<EventDetails>();
            foreach (var day in Element.HighlightedDays)
            {
                eventSchedule.Add(new EventDetails
                {
                    StartDate = day.Date.ToNSDate(),
                    EndDate = day.Date.ToNSDate()
                });
                _calendar.EventSchedule = eventSchedule.ToArray();
            }
        }
    }
}