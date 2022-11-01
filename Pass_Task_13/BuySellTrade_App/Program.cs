using System;
using BuySellTrade_App.Components;

namespace BuySellTrade_App;
internal class Program
{
    public static void TestAdmin()
    {
        Admin billy = new(
            "Billy Micah",
            "me@you.com",
            "pass",
            456789876
        );

        Category Cars = new(
            "Cars"
        );
        Category Furniture = new(
            "Furniture"
        );
        Category Crokery = new(
            "Crokery"
        );

        Product one = new(
            "Honda Civic",
            "34567 KM mileage, within Kuching",
            10000.00,
            Condition.Used,
            Cars
        );
        Product two = new(
            "Italian Leather",
            "Nick Scali imported leather couch",
            4500.00,
            Condition.BrandNew,
            Furniture
        );
        Product trois = new(
            "Ford Falcon",
            "1347 KM mileage, From Kuala Lumpar",
            22000.00,
            Condition.Used,
            Cars
        );
        Product unn = new(
            "Home Couch",
            "Just bought this couch but won't fit in my house",
            2500.00,
            Condition.BrandNew,
            Furniture
        );
        Product via = new(
            "Perodua",
            "3467 KM mileage, within Kuching",
            10000.00,
            Condition.Used,
            Cars
        );

        via.Advertise.Life = 5;
        unn.Advertise.Life = 3;
        trois.Advertise.Life = 4;

        List<Product> products = new();

        products.Add( one );
        products.Add( two );
        products.Add( trois );
        products.Add( unn );
        products.Add( via );


        billy.Catalogue.AddItem(products);
        billy.Catalogue.Display();
        Console.WriteLine($"Number of Categories: {billy.Catalogue.AllCategories()}");
        Console.WriteLine($"Number of Products: {billy.Catalogue.TotalCount()}");
        Console.WriteLine($"Number of Advertisements: {billy.Catalogue.TotalAds()}");

        billy.Catalogue.RemoveItem(via);
        
        billy.Catalogue.Display();
        Console.WriteLine($"Number of Categories: {billy.Catalogue.AllCategories()}");
        Console.WriteLine($"Number of Products: {billy.Catalogue.TotalCount()}");
        Console.WriteLine($"Number of Advertisements: {billy.Catalogue.TotalAds()}");
        // Console.WriteLine(billy.Catalogue.);
        
    }
    private static void Main(string[] args)
    {
        TestAdmin();
    }
}