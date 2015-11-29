using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Timetabling_App.Services;

namespace Timetabling_App
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void GetTimetableData()
        {
            /*string URI = "http://mobile.nottingham.ac.uk/hack/data/timetabling/2015/activities/module/DEFE15F6B6D777913C727DD801F88C6B";
            WebRequest webRequest = WebRequest.Create(URI);
            webRequest.BeginGetRespon*/

            

            var retrievalService = new WeekTimetableRetrieverService();
            var formattingService = new DayFormatterService();

            var weeklyTimetable = retrievalService.GetSchedule();

            formattingService.Format(Monday, weeklyTimetable.Monday);
            formattingService.Format(Tuesday, weeklyTimetable.Tuesday);
            formattingService.Format(Wednesday, weeklyTimetable.Wednesday);
            formattingService.Format(Thursday, weeklyTimetable.Thursday);
            formattingService.Format(Friday, weeklyTimetable.Friday);


            //Service which gives back week object
            // Week object has a list of lectures assigned to each day of the week
        }

        private void LayoutRoot_OnLoaded(object sender, RoutedEventArgs e)
        {
            GetTimetableData();
        }
    }
}