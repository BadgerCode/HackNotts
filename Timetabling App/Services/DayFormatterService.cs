using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Timetabling_App.Models;

namespace Timetabling_App.Services
{
    public class DayFormatterService
    {
        public void Format(Panel panel, List<Lecture> lectues)
        {
            foreach (var lecture in lectues)
            {
                var output = String.Format("{0} - {1}: {2} - {3}", lecture.StartTime, lecture.EndTime, lecture.ModuleCode, lecture.Room);
                var textBlock = new TextBlock
                {
                    Text = output
                };

                panel.Children.Add(textBlock);    
            }

        }
    }
}
