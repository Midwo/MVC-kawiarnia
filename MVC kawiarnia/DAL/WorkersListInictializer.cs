using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class WorkersListInictializer : CreateDatabaseIfNotExists<WorkersListContext>
    {
        protected override void Seed(WorkersListContext context)
        {
            var WorkersListAdd = new List<WorkersList>
            {
                new WorkersList { Email = "michal.dwojak92@gmail.com", NameSurname = "Michał Dwojak", WorkersListId = 1 } ,
                new WorkersList { Email = "jataman92@gmail.com", NameSurname = "" } ,
            };
            RatingEmployees.ForEach(g => context.RatingEmployees.Add(g));
            context.SaveChanges();


        }
    }
}