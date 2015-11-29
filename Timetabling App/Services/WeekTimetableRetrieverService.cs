using System.Collections.Generic;
using Timetabling_App.Models;

namespace Timetabling_App.Services
{
    public class WeekTimetableRetrieverService
    {
        public Week GetSchedule()
        {
            return new Week
            {
                Monday = new List<Lecture>()
                {
                    new Lecture() {EndTime = "10:00", StartTime = "9:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"},
                    new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"}
                },
                Tuesday = new List<Lecture>() { new Lecture() {EndTime = "11:00", StartTime = "10:00", ModuleCode = "G52AAA", Room = "My room"} },
                Wednesday = new List<Lecture>() { new Lecture() {EndTime = "12:00", StartTime = "11:00", ModuleCode = "G52AAA", Room = "My room"} },
                Thursday = new List<Lecture>() { new Lecture() {EndTime = "13:00", StartTime = "12:00", ModuleCode = "G52AAA", Room = "My room"} },
                Friday = new List<Lecture>() { new Lecture() {EndTime = "14:00", StartTime = "13:00", ModuleCode = "G52AAA", Room = "My room"} },
            };
        }
    }
}
