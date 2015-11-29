using System.Windows.Controls;
using Timetabling_App.Models;
using Timetabling_App.Services;

namespace Timetabling_App.Pages.TimetablePage
{
    public partial class TimetablePage : UserControl
    {
        public TimetablePage()
        {
            InitializeComponent();
        }

        public void UpdateWeek(Week week)
        {
            new DayFormatterService().Format(Monday, week.Monday);
            new DayFormatterService().Format(Tuesday, week.Tuesday);
            new DayFormatterService().Format(Wednesday, week.Wednesday);
            new DayFormatterService().Format(Thursday, week.Thursday);
            new DayFormatterService().Format(Friday, week.Friday);
        }
    }
}
