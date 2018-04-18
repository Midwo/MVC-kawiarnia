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
                new Reviews { Name = "Michał",  ReviewText = "<p>Kawa bardzo dobra ale obsługa kiepska.&nbsp;Potraktowano mnie bardzo źle. Jestem negatywnie nastawiony na dalszą wsp&oacute;łpracę z tym miejsce.</p>", RatingMealsId = 5,  RatingEmployeesId = 1, RatingPlaceId = 1} ,
                new Reviews { Name = "Darek",  ReviewText = "<p>Świetne i klimatyczne miejsce, pyszna kawa a ciasta jeszcze lepsze. Drugie danie przepyszne, jednak mały minus co do obsługi mogła by być bardziej milsza i nie robić foch&oacute;w gdy chce się zam&oacute;wić inne danie.</p>", RatingMealsId = 5,  RatingEmployeesId = 4, RatingPlaceId = 5} ,
                new Reviews { Name = "Ania",  ReviewText = "<p>Świetne miejsce uwielbiamy tu przychodzić. Dania pyszne, byliśmy już wiele razy i zawsze wszystko nam baardzo smakowało. Moja druga poł&oacute;wka m&oacute;wi, że najlepsze kawy i desery w mieście. :-) Polecamy!!!</p>", RatingMealsId = 4,   RatingEmployeesId = 3, RatingPlaceId = 4} ,
                new Reviews { Name = "Kasia",  ReviewText = "<p>Parokrotnie bywałem tam na deserach i były pyszne, raz wybrałem się na obiad w poniedziałek. Lokal pustawy a posiłek wyczekany ,smaczny lecz chłodny.</p>", RatingMealsId = 2, RatingEmployeesId = 3, RatingPlaceId = 5} ,
            };
            Review.ForEach(g => context.Messages.Add(g));
            context.SaveChanges();

         
        }



    }
}