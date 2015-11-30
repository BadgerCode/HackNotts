using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Timetabling_App.Models;
using Timetabling_App.Services;

namespace Timetabling_App
{
    public class MainScope : BaseScope
    {
        private Visibility _moduleWizardVisibility;
        public Visibility ModuleWizardVisibility { get { return _moduleWizardVisibility; } set { SetProperty(ref _moduleWizardVisibility, value); } }

        private Visibility _timetableVisibility;
        public Visibility TimetableVisibility { get { return _timetableVisibility; } set { SetProperty(ref _timetableVisibility, value); } }
    }

    public partial class MainPage : PhoneApplicationPage
    {
        public MainScope Scope { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Scope = new MainScope();
            InitializeScope();

            ModuleWizard.DataContext = Scope;
            TimetablePage.DataContext = Scope;
        }

        private void InitializeScope()
        {
            Scope.ModuleWizardVisibility = Visibility.Visible;
            Scope.TimetableVisibility = Visibility.Collapsed;
        }

        public void ShowModuleWizard()
        {
            Scope.ModuleWizardVisibility = Visibility.Visible;
        }

        public void HideModuleWizard()
        {
            Scope.ModuleWizardVisibility = Visibility.Collapsed;
        }

        public void ShowTimetable()
        {
            Scope.TimetableVisibility = Visibility.Visible;
        }

        public void HideTimetable()
        {
            Scope.TimetableVisibility = Visibility.Collapsed;
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

        private void OpenTimetable(object sender, EventArgs e)
        {
            HideModuleWizard();
            ShowTimetable();
        }

        private void OpenModuleWizard(object sender, EventArgs e)
        {
            HideTimetable();
            ShowModuleWizard();
        }
    }
}