using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Phone.Controls;
using Timetabling_App.Models;

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
            ModuleWizard.OnSuccess(ReloadTimetableModules);

            TimetablePage.DataContext = Scope;
        }

        private void ReloadTimetableModules(IList<string> moduleShortCodes)
        {
            HideModuleWizard();
            ShowTimetable();

            TimetablePage.Scope.ModuleShortCodes = moduleShortCodes;
            TimetablePage.ReloadTimetableData();
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

        private void OnPageLoad(object sender, RoutedEventArgs e)
        {

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