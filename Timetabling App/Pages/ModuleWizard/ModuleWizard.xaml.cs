using System.Windows;
using System.Windows.Controls;
using Timetabling_App.Models;

namespace Timetabling_App.Pages.ModuleWizard
{
    public class ModuleWizardScope : BaseScope
    {
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

        public ModuleWizard()
        {
            InitializeComponent();

            Scope = new ModuleWizardScope();
            InitializeScope();

            SchoolPage.DataContext = Scope;
            CoursePage.DataContext = Scope;
            YearOfCoursePage.DataContext = Scope;
            ModulesPage.DataContext = Scope;
        }

        private void InitializeScope()
        {
            Scope.SchoolVisibility = Visibility.Visible;
            Scope.CourseVisibility = Visibility.Collapsed;
            Scope.YearOfCourseVisibility = Visibility.Collapsed;
            Scope.ModulesVisibility = Visibility.Collapsed;
        }

        public void PreviousStage()
        {
            if (Scope.CurrentStage - 1 >= ModuleWizardStage.SelectSchool)
            {
                Scope.CurrentStage--;
            }

            UpdateCurrentStage();
        }

        public void NextStage()
        {
            if (Scope.CurrentStage + 1 <= ModuleWizardStage.SelectModules)
            {
                Scope.CurrentStage++;
            }

            UpdateCurrentStage();
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
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            NextStage();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            PreviousStage();
        }
    }
}
