using System.Collections.Generic;

namespace Timetabling_App.Models
{
    public class Week
    {
        public List<Lecture> Monday { get; set; }
        public List<Lecture> Tuesday { get; set; }
        public List<Lecture> Wednesday { get; set; }
        public List<Lecture> Thursday { get; set; }
        public List<Lecture> Friday { get; set; }

    }
}