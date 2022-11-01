using System;
using System.Collections.Generic;
using System.Collections;
using BuySellTrade_App.Algorithms;

namespace BuySellTrade_App.Components;

public class Catalogue
{
    private List<Product> _listOfProducts;
    
    public Hashtable catalogue{ get; set; }
    public List<Category> Categories { get; set; }

    public List<Product> Adverts { get; set; }

    public List<Product> ListOfProduct 
    {
        get => _listOfProducts;
        set => _listOfProducts = value;
    }

    public Catalogue()
    {
        _listOfProducts = new();
        catalogue = new();
        Adverts = new();
        Categories = new();
    }
    private int GenerateId(){
        Random rand = new();
        int idNum = rand.Next();
        do
        {
            idNum = rand.Next();
        }
        while (_listOfProducts.FirstOrDefault<Product>( n => n.ProdId == idNum ) != null );

        return idNum;
    }
    public Catalogue(List<Product> listOfProducts)
    {
        _listOfProducts = new();

        foreach(Product item in listOfProducts) {
            AddCategory(item);
            item.ProdId = GenerateId();
        }
        catalogue = new();
        Adverts = new();
        Categories = new();
    }
    public void AddItem(Product item)
    {
        item.ProdId = GenerateId();
        AddCategory(item);
        _listOfProducts.Add( item );

        CheckAdvert();
    }
    private void AddCategory(Product item)
    {
        if (Categories.FirstOrDefault<Category>( n => n == item.Category ) == null) Categories.Add( item.Category );

    }

    public void AddItem(List<Product> items)
    {
        foreach(Product product in items) {
            product.ProdId = GenerateId();
            AddCategory(product);
            _listOfProducts.Add( product );
        }

        CheckAdvert();
    }

    public void RemoveItem(Product item)
    {
        var ad = Adverts.FirstOrDefault<Product>( n => n.ProdId == item.ProdId );
        
        if (_listOfProducts.FirstOrDefault<Product>( n => n.ProdId == item.ProdId ) != null)
        {
            _listOfProducts.Remove( item );
            if ( ad != null ) Adverts.Remove( ad );
            Console.WriteLine($"Successfully removed the product: {item.Name}.");

            CheckAdvert();
        } 
        else Console.WriteLine($"No item of name {item.Name} was found");
    }

    public void RemoveItem(string productName)
    {
        var item = _listOfProducts.FirstOrDefault<Product>( n => n.Name.ToLower() == productName.ToLower() );
        var ad = Adverts.FirstOrDefault<Product>( n => n.Name.ToLower() == productName.ToLower() );
        
        if ( item != null)
        {
            if (ad != null ) Adverts.Remove( ad );
            _listOfProducts.Remove( item );
            Console.WriteLine($"Successfully removed the product: {productName}.");

            CheckAdvert();
        }
        else Console.WriteLine($"No item of name {productName} was found");
        
    }

    public List<Product> Sort(string criteria)
    {
        CheckAdvert();

        return _listOfProducts;
    }

    public void Display()
    {
        if(Adverts.Count > 0){
            Console.WriteLine("Advertisements\n===================\n");
            foreach(Product prod in Adverts) Console.WriteLine($"Advertisement\n-----------------\n{prod.PrintInfo()}\n");
            Console.WriteLine();
        }
        if(_listOfProducts.Count > 0){
            Console.WriteLine("Products\n===================\n");
            foreach(Product prod in _listOfProducts) Console.WriteLine($"{prod.PrintInfo()}\n");
        }
        else {
            Console.WriteLine("There aren't any products in this catalogue");
        }
    }

    public int AllCategories() => Categories.Count;
    public int TotalCount() => _listOfProducts.Count;
    public int TotalAds() {
        CheckAdvert();
        return Adverts.Count;
    
    }

    private void CheckAdvert()
    {
        foreach(Product item in _listOfProducts)
        {
            if (item.Advertise.Life > 0 && Adverts.FirstOrDefault<Product>(n => n.ProdId == item.ProdId) == null)
            {
                Adverts.Add( item );
            }

        }
        foreach(Product item in Adverts)
        {
            if (item.Advertise.Life < 1 || _listOfProducts.FirstOrDefault<Product>(n => n.ProdId == item.ProdId) == null)
            {
                Adverts.Remove( item );
            }
        }
    }
}