using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class ReviewsInictializer : CreateDatabaseIfNotExists<ReviewContext>
    {
        protected override void Seed(ReviewContext context)
        {
            var RatingEmployees = new List<RatingEmployees>
            {
                new RatingEmployees { RatingEmployeesInt = 5, RatingEmployeesId = 5} ,
                new RatingEmployees { RatingEmployeesInt = 4, RatingEmployeesId = 4} ,
                new RatingEmployees { RatingEmployeesInt = 3, RatingEmployeesId = 3} ,
                new RatingEmployees { RatingEmployeesInt = 2, RatingEmployeesId = 2} ,
                new RatingEmployees { RatingEmployeesInt = 1, RatingEmployeesId = 1} ,
            };
            RatingEmployees.ForEach(g => context.RatingEmployees.Add(g));
            context.SaveChanges();

            var RatingMeals = new List<RatingMeals>
            {
                new RatingMeals { RatingMealsId = 5, RatingPlaceInt = 5} ,
                new RatingMeals { RatingMealsId = 4, RatingPlaceInt = 4} ,
                new RatingMeals { RatingMealsId = 3, RatingPlaceInt = 3} ,
                new RatingMeals { RatingMealsId = 2, RatingPlaceInt = 2} ,
                new RatingMeals { RatingMealsId = 1, RatingPlaceInt = 1} ,
            };
            RatingMeals.ForEach(g => context.RatingMeals.Add(g));
            context.SaveChanges();

            var RatingPlace = new List<RatingPlace>
            {
                new RatingPlace { RatingPlaceInt = 5, RatingPlaceId = 5} ,
                new RatingPlace { RatingPlaceInt = 4, RatingPlaceId = 4} ,
                new RatingPlace { RatingPlaceInt = 3, RatingPlaceId = 3} ,
                new RatingPlace { RatingPlaceInt = 2, RatingPlaceId = 2} ,
                new RatingPlace { RatingPlaceInt = 1, RatingPlaceId = 1} ,
            };
            RatingPlace.ForEach(g => context.RatingPlace.Add(g));
            context.SaveChanges();


            var Review = new List<Reviews>
            {
                new Reviews { Name = "Michał",  ReviewText = "Laoreet ac, aliquam sit amet justo nunc tempor, metus vel placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante fusce non.", RatingMealsId = 5,  RatingEmployeesId = 5, RatingPlaceId = 5} ,
                new Reviews { Name = "Darek",  ReviewText = "Laoreet ac, aliquam sit amet justo nunc tempor, metus vel placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante fusce non.", RatingMealsId = 4,  RatingEmployeesId = 4, RatingPlaceId = 4} ,
                new Reviews { Name = "Ania",  ReviewText = "Laoreet ac, aliquam sit amet justo nunc tempor, metus vel placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante fusce non.", RatingMealsId = 3,   RatingEmployeesId = 3, RatingPlaceId = 3} ,
                new Reviews { Name = "Kasia",  ReviewText = "Laoreet ac, aliquam sit amet justo nunc tempor, metus vel placerat suscipit, orci nisl iaculis eros, a tincidunt nisi odio eget lorem nulla condimentum tempor mattis ut vitae feugiat augue cras ut metus a risus iaculis scelerisque eu ac ante fusce non.", RatingMealsId = 2, RatingEmployeesId = 2, RatingPlaceId = 2} ,
            };
            Review.ForEach(g => context.Messages.Add(g));
            context.SaveChanges();

         
        }



    }
}