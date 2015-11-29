using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Xna.Framework.Audio;
using Timetabling_App.Models;

namespace Timetabling_App.Services
{
    public class DayFormatterService
    {
        public void format(StackPanel panel, List<Lecture> lectues)
        {
            foreach (var lecture in lectues)
            {
                
                var output = String.Format("{0} - {1}: {2} - {3}", lecture.StartTime, lecture.EndTime, lecture.ModuleCode, lecture.Room);
                var textBlock = new TextBlock();
                textBlock.Text = output;
                panel.Children.Add(textBlock);    
            }

        }
    }
}
