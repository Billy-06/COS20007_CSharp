using System;
using System.Collections.Generic;
using System.Collections;
using BuySellTrade_App.Algorithms;

namespace BuySellTrade_App.Components;

public class Catalogue
{
    private List<Product> _listOfProducts;
    
    public Hashtable catalogue{ get; set; }

    public List<Product> ListOfProduct 
    {
        get => _listOfProducts;
        set => _listOfProducts = value;
    }

    public Catalogue()
    {
        _listOfProducts = new();
        catalogue = new();
    }
    public Catalogue(List<Product> listOfProducts)
    {
        _listOfProducts = listOfProducts;
        catalogue = new();
    }
    public void AddItem(Product item)
    {
        _listOfProducts.Add( item );
    }

    public void AddItem(Product[] items)
    {
        foreach(Product product in items) _listOfProducts.Add( product );
    }

    public void RemoveItem(Product item)
    {
        if (_listOfProducts.FirstOrDefault<Product>( n => n.Name.ToLower() == item.Name.ToLower() ) != null)
        {
            _listOfProducts.Remove( item );
            Console.WriteLine($"Successfully removed the product: {item.Name}.");
        } 
        else Console.WriteLine($"No item of name {item.Name} was found");
    }

    public void RemoveItem(string productName)
    {
        if (_listOfProducts.FirstOrDefault<Product>( n => n.Name.ToLower() == productName.ToLower() ) != null)
        {
            var item = _listOfProducts.FirstOrDefault<Product>( n => n.Name.ToLower() == productName.ToLower() );
            _listOfProducts.Remove( item );
            Console.WriteLine($"Successfully removed the product: {productName}.");
        }
        else Console.WriteLine($"No item of name {productName} was found");
        
    }

    public static List<Product> Sort(string criteria)
    {
        
        throw new NotImplementedException();
    }

    public void Display()
    {
        foreach(Product prod in _listOfProducts) Console.WriteLine($"{prod.PrintInfo()}");
    }

    public int TotalCount() => _listOfProducts.Count;
}