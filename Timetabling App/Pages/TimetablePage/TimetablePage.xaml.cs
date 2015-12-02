using System.Collections.Generic;
using System.Windows.Controls;
using Timetabling_App.Models;
using Timetabling_App.Services;

namespace Timetabling_App.Pages.TimetablePage
{
    public partial class TimetablePage : UserControl
    {
        public TimetableScope Scope { get; set; }

        public TimetablePage()
        {
            InitializeComponent();

            Scope = new TimetableScope();
            InitializeScope();
        }

        private void InitializeScope()
        {
            Scope.ModuleShortCodes = new List<string>();
        }

        public void UpdateWeek(Week week)
        {
            new DayFormatterService().Format(Monday, week.Monday);
            new DayFormatterService().Format(Tuesday, week.Tuesday);
            new DayFormatterService().Format(Wednesday, week.Wednesday);
            new DayFormatterService().Format(Thursday, week.Thursday);
            new DayFormatterService().Format(Friday, week.Friday);
        }

        public void ReloadTimetableData()
        {
            var retrievalService = new WeekTimetableRetrieverService();

            var weeklyTimetable = retrievalService.GetSchedule();
            UpdateWeek(weeklyTimetable);
        }
    }

    public class TimetableScope : BaseScope
    {
        private IList<string> _moduleShortCodes;
        public IList<string> ModuleShortCodes { get { return _moduleShortCodes; } set { SetProperty(ref _moduleShortCodes, value); } }
    }
}
