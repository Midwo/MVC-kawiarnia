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
                new RatingEmployees { RatingEmployeesInt = 5} ,
                new RatingEmployees { RatingEmployeesInt = 4} ,
                new RatingEmployees { RatingEmployeesInt = 3} ,
                new RatingEmployees { RatingEmployeesInt = 2} ,
                new RatingEmployees { RatingEmployeesInt = 1} ,
            };
            RatingEmployees.ForEach(g => context.RatingEmployees.Add(g));
            context.SaveChanges();

            var RatingMeals = new List<RatingMeals>
            {
                new RatingMeals { RatingPlaceInt = 5} ,
                new RatingMeals { RatingPlaceInt = 4} ,
                new RatingMeals { RatingPlaceInt = 3} ,
                new RatingMeals { RatingPlaceInt = 2} ,
                new RatingMeals { RatingPlaceInt = 1} ,
            };
            RatingMeals.ForEach(g => context.RatingMeals.Add(g));
            context.SaveChanges();

            var RatingPlace = new List<RatingPlace>
            {
                new RatingPlace { RatingPlaceInt = 5} ,
                new RatingPlace { RatingPlaceInt = 4} ,
                new RatingPlace { RatingPlaceInt = 3} ,
                new RatingPlace { RatingPlaceInt = 2} ,
                new RatingPlace { RatingPlaceInt = 1} ,
            };
            RatingPlace.ForEach(g => context.RatingPlace.Add(g));
            context.SaveChanges();

            var RatingSummary = new List<RatingSummary>
            {
                new RatingSummary { RatingPlaceText = "Perfekcyjnie"} ,
                new RatingSummary { RatingPlaceText = "Bardzo dobrze"} ,
                new RatingSummary { RatingPlaceText = "Dobrze"} ,
                new RatingSummary { RatingPlaceText = "Względnie"} ,
                new RatingSummary { RatingPlaceText = "Nie polecam"} ,
            };
            RatingSummary.ForEach(g => context.RatingSummary.Add(g));
            context.SaveChanges();



            var Review = new List<Reviews>
            {
                new Reviews { Name = "Michał D.",  ReviewText = "Najlepsza strona1", RatingMealsId = 1, RatingSummaryId = 1, RatingEmployeesId = 1, RatingPlaceId = 1} ,
                new Reviews { Name = "Michał D.",  ReviewText = "Najlepsza strona2", RatingMealsId = 2, RatingSummaryId = 2, RatingEmployeesId = 2, RatingPlaceId = 2} ,
                new Reviews { Name = "Michał D.",  ReviewText = "Najlepsza strona3", RatingMealsId = 1, RatingSummaryId = 1, RatingEmployeesId = 1, RatingPlaceId = 1} ,
                new Reviews { Name = "Michał D.",  ReviewText = "Najlepsza strona4", RatingMealsId = 5, RatingSummaryId = 5, RatingEmployeesId = 5, RatingPlaceId = 5} ,
            };
            Review.ForEach(g => context.Messages.Add(g));
            context.SaveChanges();

        }



    }
}