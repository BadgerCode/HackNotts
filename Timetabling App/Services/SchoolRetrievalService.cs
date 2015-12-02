using System.Collections.Generic;

namespace Timetabling_App.Services
{
    public class SchoolRetrievalService
    {
        public IList<string> GetSchools()
        {
            return new List<string> { "Computer Science", "Maths" };
        } 
    }
}
