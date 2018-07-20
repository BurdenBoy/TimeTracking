using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.ViewModel
{
    public static class DataBaseConnector
    {

        public static ObservableCollection<string> GetAllActivities()
        {
            var allActivities = new ObservableCollection<string>();
            using (TimeTrackingDBEntities context = new TimeTrackingDBEntities())
            {
                foreach (var activiy in context.Activities.Select(r => r.Name).OrderBy(r => r))
                {
                    allActivities.Add(activiy);
                }
            }
            return allActivities;
        }

        public static ObservableCollection<string> GetAllCategories()
        {
            var allCategories = new ObservableCollection<string>();
            using (TimeTrackingDBEntities context = new TimeTrackingDBEntities())
            {
                foreach (var activiy in context.Categories.Select(r => r.Name).OrderBy(r => r))
                {
                    allCategories.Add(activiy);
                }
            }
            return allCategories;
        }

        public static void AddCategory(string name, IMessenger messenger)
        {
            using (TimeTrackingDBEntities context = new TimeTrackingDBEntities())
            {
                context.Categories.Add(new Category { Name = name });
                context.SaveChanges();
            }
            messenger.Send("Update");
        }

        public static void AddActivity(string categoryString, string name, IMessenger messenger)
        {
            using (TimeTrackingDBEntities context = new TimeTrackingDBEntities())
            {
                Category category = context.Categories.FirstOrDefault(c => c.Name == categoryString);
                category.Activities.Add(new Activity
                {
                    Name = name                    
                });
                context.SaveChanges();
            }
            messenger.Send("Update");
        }

        public static void AddEntry(string activityString, string comment, string duration, DateTime date, IMessenger messenger)
        {
            using (TimeTrackingDBEntities context = new TimeTrackingDBEntities())
            {
                Activity activity = context.Activities.FirstOrDefault(c => c.Name == activityString);
                activity.TimeEntries.Add(new TimeEntry
                {
                    Comment = comment,
                    Duration = double.Parse(duration),
                    CreationDate = DateTime.Now,
                    Date = date
                });
                context.SaveChanges();
            }
            messenger.Send("Update");
        }

        public static Activity GetActivityFromString(string activity)
        {
            using (TimeTrackingDBEntities context = new TimeTrackingDBEntities())
            {
                return context.Activities.FirstOrDefault(c => c.Name == activity);
            }
        }

        public static ObservableCollection<EntryViewModel> GetTimeEntriesFromDate(DateTime date)
        {
            var tempEntries = new ObservableCollection<EntryViewModel>();
            using (TimeTrackingDBEntities context = new TimeTrackingDBEntities())
            {
                var entriesFromDB = context.TimeEntries.Where(r => r.Date.Day == date.Day).ToList();
                foreach (var entry in entriesFromDB)
                {
                    tempEntries.Add(new EntryViewModel
                    {
                        Activity = entry.Activity.Name,
                        Duration = entry.Duration.ToString(),
                        Comment = entry.Comment
                    });
                }
            }
            return tempEntries;
        }
    }
}
