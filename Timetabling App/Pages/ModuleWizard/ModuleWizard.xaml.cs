using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Timetabling_App.Models;

namespace Timetabling_App.Pages.ModuleWizard
{
    public class ModuleWizardScope : BaseScope
    {
        private IList<string> _moduleShortCodes;
        public IList<string> ModuleShortCodes { get { return _moduleShortCodes; } set { SetProperty(ref _moduleShortCodes, value); } } 

        private ModuleWizardStage _currentStage;
        public ModuleWizardStage CurrentStage { get { return _currentStage; } set { SetProperty(ref _currentStage, value); } }

        private Visibility _schoolVisibility;
        public Visibility SchoolVisibility { get { return _schoolVisibility; } set { SetProperty(ref _schoolVisibility, value); } }

        private Visibility _courseVisibility;
        public Visibility CourseVisibility { get { return _courseVisibility; } set { SetProperty(ref _courseVisibility, value); } }

        private Visibility _yearOfCourseVisibility;
        public Visibility YearOfCourseVisibility { get { return _yearOfCourseVisibility; } set { SetProperty(ref _yearOfCourseVisibility, value); } }

        private Visibility _modulesVisibility;
        public Visibility ModulesVisibility { get { return _modulesVisibility; } set { SetProperty(ref _modulesVisibility, value); } }

        public Visibility ShowBackButton => _currentStage != ModuleWizardStage.SelectSchool ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ShowNextButton => _currentStage != ModuleWizardStage.SelectModules ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ShowSaveButton => _currentStage == ModuleWizardStage.SelectModules ? Visibility.Visible : Visibility.Collapsed;

        public void UpdateButtons()
        {
            OnPropertyChanged(nameof(ShowBackButton));
            OnPropertyChanged(nameof(ShowNextButton));
            OnPropertyChanged(nameof(ShowSaveButton));
        }
    }

    public enum ModuleWizardStage
    {
        SelectSchool,
        SelectCourse,
        SelectYearOfCourse,
        SelectModules
    }

    public partial class ModuleWizard : UserControl
    {
        public ModuleWizardScope Scope { get; set; }

        private readonly List<Action<IList<string>>> _successCallbacks;

        public ModuleWizard()
        {
            InitializeComponent();

            _successCallbacks = new List<Action<IList<string>>>();
            Scope = new ModuleWizardScope();
            InitializeScope();

            SchoolPage.DataContext = Scope;
            CoursePage.DataContext = Scope;
            YearOfCoursePage.DataContext = Scope;
            ModulesPage.DataContext = Scope;

            BackButton.DataContext = Scope;
            NextButton.DataContext = Scope;
            SaveButton.DataContext = Scope;
        }

        private void InitializeScope()
        {
            Scope.SchoolVisibility = Visibility.Visible;
            Scope.CourseVisibility = Visibility.Collapsed;
            Scope.YearOfCourseVisibility = Visibility.Collapsed;
            Scope.ModulesVisibility = Visibility.Collapsed;

            Scope.ModuleShortCodes = new List<string>();

            Scope.UpdateButtons();
        }

        private void PreviousStage()
        {
            if (Scope.CurrentStage - 1 < ModuleWizardStage.SelectSchool) return;

            Scope.CurrentStage--;
            UpdateCurrentStage();
        }

        private void NextStage()
        {
            if (Scope.CurrentStage + 1 > ModuleWizardStage.SelectModules) return;

            Scope.CurrentStage++;
            UpdateCurrentStage();
        }

        private void FinishWizard()
        {
            foreach (var successCallback in _successCallbacks)
            {
                successCallback(Scope.ModuleShortCodes);
            }
        }

        private void UpdateCurrentStage()
        {
            Scope.CourseVisibility = Visibility.Collapsed;
            Scope.SchoolVisibility = Visibility.Collapsed;
            Scope.YearOfCourseVisibility = Visibility.Collapsed;
            Scope.ModulesVisibility = Visibility.Collapsed;

            switch (Scope.CurrentStage)
            {
                case ModuleWizardStage.SelectSchool:
                    Scope.SchoolVisibility = Visibility.Visible;
                    break;
                case ModuleWizardStage.SelectCourse:
                    Scope.CourseVisibility = Visibility.Visible;
                    break;
                case ModuleWizardStage.SelectYearOfCourse:
                    Scope.YearOfCourseVisibility = Visibility.Visible;
                    break;
                case ModuleWizardStage.SelectModules:
                    Scope.ModulesVisibility = Visibility.Visible;
                    break;
            }

            Scope.UpdateButtons();
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            NextStage();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            PreviousStage();
        }

        private void FinishButtonClick(object sender, RoutedEventArgs e)
        {
            FinishWizard();
        }

        public void OnSuccess(Action<IList<string>> callback)
        {
            _successCallbacks.Add(callback);
        }
    }
}
