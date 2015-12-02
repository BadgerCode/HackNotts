using System.Collections.Generic;
using System.Windows.Controls;
using Timetabling_App.Models;
using Timetabling_App.Services;

namespace Timetabling_App.Pages.ModuleWizard
{
    public partial class SelectSchool : UserControl
    {
        public SelectSchoolScope Scope;

        public SelectSchool()
        {
            InitializeComponent();
        }

        private void InitializeScope()
        {
            Scope.Schools = new SchoolRetrievalService().GetSchools();
        }

        private void UpdateSchools()
        {
            SchoolsList.Items.Clear();
            foreach (var school in Scope.Schools)
            {
                SchoolsList.Items.Add(school);
            }
        }

        public void Initialize()
        {
            Scope = new SelectSchoolScope();
            InitializeScope();

            UpdateSchools();
        }
    }

    public class SelectSchoolScope : BaseScope
    {
        private IList<string> _schools;
        public IList<string> Schools { get { return _schools; } set { SetProperty(ref _schools, value); } }
    }
}
