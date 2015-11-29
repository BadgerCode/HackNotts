using System.Collections.Generic;
using System.Windows;
using Microsoft.Phone.Controls;
using Timetabling_App.Services;

namespace Timetabling_App
{
    public partial class MainPage : PhoneApplicationPage
    {
        public List<string> ModuleIds { get; set; }

        public Visibility ModuleWizardVisibility = Visibility.Visible;
        public Visibility TimetableVisibility = Visibility.Collapsed;

        public MainPage()
        {
            ModuleIds = new List<string>();

            InitializeComponent();
        }

        public void ShowModuleWizard()
        {
            ModuleWizardVisibility = Visibility.Visible;
        }

        public void HideModuleWizard()
        {
            ModuleWizardVisibility = Visibility.Collapsed;
        }

        public void ShowTimetable()
        {
            TimetableVisibility = Visibility.Visible;
        }

        public void HideTimetable()
        {
            TimetableVisibility = Visibility.Collapsed;
        }

        private void GetTimetableData()
        {
            var retrievalService = new WeekTimetableRetrieverService();

            var weeklyTimetable = retrievalService.GetSchedule();
            TimetablePage.UpdateWeek(weeklyTimetable);
        }

        private void OnPageLoad(object sender, RoutedEventArgs e)
        {
            GetTimetableData();
        }
    }
}