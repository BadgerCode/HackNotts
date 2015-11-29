using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
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
            getTimetableData();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void getTimetableData()
        {
            /*string URI = "http://mobile.nottingham.ac.uk/hack/data/timetabling/2015/activities/module/DEFE15F6B6D777913C727DD801F88C6B";
            WebRequest webRequest = WebRequest.Create(URI);
            webRequest.BeginGetRespon*/

            

            var retrievalService = new WeekTimetableRetrieverService();
            var weeklyTimetable = retrievalService.getSchedule();



            //Service which gives back week object
            // Week object has a list of lectures assigned to each day of the week
        }

        private void LayoutRoot_OnLoaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}