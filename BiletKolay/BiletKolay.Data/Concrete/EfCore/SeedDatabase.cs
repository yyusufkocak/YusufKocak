using BiletKolay.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new BiletKolayContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Routes.Count() == 0)
                {
                    context.Routes.AddRange(Routes);
                }
                if (context.Cities.Count() == 0)
                {
                    context.Cities.AddRange(Cities);
                }
                if (context.Tickets.Count() == 0)
                {
                    context.Tickets.AddRange(Tickets);
                }
                context.SaveChanges();
            }
        }

        private static City[] Cities =
        {
            new City() { CityName = "İstanbul" },
            new City() { CityName = "Ankara" },
            new City() { CityName = "İzmir" },
            new City() { CityName = "Amasya" },
            new City() { CityName = "Sivas" },
            new City() { CityName = "Kırklareli" },
            new City() { CityName = "Edirne" },
            new City() { CityName = "Tekirdağ" },
            new City() { CityName = "Bursa" },
            new City() { CityName = "Yalova" },
            new City() { CityName = "Balıkesir" },
            new City() { CityName = "Eskişehir" },
            new City() { CityName = "Muğla" },
            new City() { CityName = "Rize" },
            new City() { CityName = "Antalya" },
            new City() { CityName = "Sinop" },
            new City() { CityName = "Kocaeli" },
            new City() { CityName = "Çanakkale" },
            new City() { CityName = "Ardahan" },
            new City() { CityName = "Sakarya" }
        };

        private static Route[] Routes =
        {
            new Route() { StartLocation = "İstanbul", FirstStation = "Bursa", SecondStation = "Amasya", ThirdStation = "Rize", EndLocation = "Ardahan", Date = "10.06.2022", Time = "15.00", Price = 100 },
            new Route() { StartLocation = "İstanbul", FirstStation = "Bursa", SecondStation = "Balıkesir", ThirdStation = "Çanakkale", EndLocation = "İzmir", Date = "10.06.2022", Time = "15.00", Price = 100 },
             new Route() { StartLocation = "Ankara", FirstStation = "Kocaeli", SecondStation = "İstanbul", ThirdStation = "Kırklareli", EndLocation = "Edirne", Date = "11.06.2022", Time = "17.00", Price = 100 },
            new Route() { StartLocation = "Ankara", FirstStation = "Eskişehir", SecondStation = "Antalya", ThirdStation = "", EndLocation = "Muğla", Date = "11.06.2022", Time = "17.00", Price = 100 },
             new Route() { StartLocation = "Kırklareli", FirstStation = "İstanbul", SecondStation = "Yalova", ThirdStation = "Sakarya", EndLocation = "Amasya", Date = "12.06.2022", Time = "19.00", Price = 100 },
            new Route() { StartLocation = "Antalya", FirstStation = "Eskişehir", SecondStation = "Sivas", ThirdStation = "Tokat", EndLocation = "Tokat", Date = "13.06.2022", Time = "19.00", Price = 120 },
             new Route() { StartLocation = "İzmir", FirstStation = "", SecondStation = "", ThirdStation = "", EndLocation = "Sinop", Date = "13.06.2022", Time = "20.00", Price = 120 },
            new Route() { StartLocation = "Sinop", FirstStation = "", SecondStation = "", ThirdStation = "", EndLocation = "İstanbul", Date = "13.06.2022", Time = "22.00", Price = 120 },
            new Route() { StartLocation = "Eskişehir", FirstStation = "Sivas", SecondStation = "Ankara", ThirdStation = "Balıkesir", EndLocation = "Yalova", Date = "14.06.2022", Time = "21.00", Price = 100 },
             new Route() { StartLocation = "İstanbul", FirstStation = "Bursa", SecondStation = "Ankara", ThirdStation = "Eskişehir", EndLocation = "Antalya", Date = "15.06.2022", Time = "21.00", Price = 100 },
            new Route() { StartLocation = "Ardahan", FirstStation = "Amasya", SecondStation = "Tokat", ThirdStation = "Ankara", EndLocation = "İstanbul", Date = "15.06.2022", Time = "17.00", Price = 100 },
             new Route() { StartLocation = "Edirne", FirstStation = "Kırklareli", SecondStation = "Tekirdağ", ThirdStation = "İstanbul", EndLocation = "Kocaeli", Date = "16.06.2022", Time = "24.00", Price = 100 },
            new Route() { StartLocation = "Sivas", FirstStation = "Ankara", SecondStation = "Eskişehir", ThirdStation = "Antalya", EndLocation = "Muğla", Date = "16.06.2022", Time = "19.00", Price = 120 },
        };

        private static Ticket[] Tickets =
        {
            new Ticket() { CustomerName = "Yusuf", CustomerSurname = "Koçak", CustomerNumber = "+5413676988", TravelFrom = "Kırklareli", TravelTo = "Amasya", SeatNumber = 13, Price=100, RouteId = 1},
            new Ticket() { CustomerName = "Azzam", CustomerSurname = "Kılıç", CustomerNumber = "+5555555555", TravelFrom = "İzmir", TravelTo = "Sinop", SeatNumber = 10, Price=120, RouteId = 1},
            new Ticket() { CustomerName = "Yunus", CustomerSurname = "Kaya", CustomerNumber = "+5555555555", TravelFrom = "Sivas", TravelTo = "Muğla", SeatNumber = 24, Price=120, RouteId = 1},
        };
    }
}
