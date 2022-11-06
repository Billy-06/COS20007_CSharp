using System;
using NUnit.Framework;
using BuySellTrade_App.Components;

/**
 * <summary>
 * Assignment Requirement:<br/>
 * <hr/>
 * The administrator itself is referring to the client and 
 * they are allowed to: <br/>
 * <list>
 *  <item> &gt; manage their products including </item>
 *  <item> &gt; advertising, </item>
 *  <item> &gt; editing and </item>
 *  <item> &gt; viewing products and when require, </item>
 *  <item> &gt; they can remove the products that are no  longer being offered manually.</item>
 *  <item> &gt; manage the products categories and also </item>
 *  <item> &gt; orders made by their customers.</item>
 * </list>
 * <hr/>
 * <br/>
 * <br/>
 * 
 * This class implements the tests listed out in the assignement on the 
 * Admin module. The tests ascertain that the admin can do each one of the 
 * items listed in the assignement quoted above
 * </summary>
 */
[TestFixture]
public class Tests
{
    
    [Test]
    public void Advertise()
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

        billy.Catalogue.AddItem( products );

        Assert.AreEqual(3, billy.Catalogue.Adverts.Count);
    }
    [Test]
    public void Editing()
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

        List<Product> products = new();

        products.Add( one );
        products.Add( two );
        products.Add( trois );
        products.Add( unn );
        products.Add( via );
        billy.Catalogue.AddItem( products );

        Product new_via = new(
            "Perodua Axia",
            "1000 KM mileage, within Kuching",
            15000.00,
            Condition.Used,
            Cars
        );

        Product updated = billy.Update(via, new_via);

        Assert.AreEqual(updated, new_via);

    }
    
    [Test]
    public void RemoveProduct()
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

        billy.Catalogue.AddItem( products );

        billy.Catalogue.RemoveItem( via );
        billy.Catalogue.RemoveItem( unn );


        Assert.AreEqual(3, billy.Catalogue.ListOfProduct.Count);
    }
    [Test]
    public void Categories()
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
        billy.Catalogue.Categories.Add( Cars );
        billy.Catalogue.Categories.Add( Furniture );
        billy.Catalogue.Categories.Add( Crokery );

        Assert.AreEqual(3, billy.Catalogue.Categories.Count);
    }
}

