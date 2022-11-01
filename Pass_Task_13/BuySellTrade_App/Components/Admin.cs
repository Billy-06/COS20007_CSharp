using System;
namespace BuySellTrade_App.Components;

public class Admin : User
{
    private Catalogue _catalogue;
    
    public Catalogue Catalogue
    {
        get => _catalogue;
        set => _catalogue = value; 
    }

    public Admin(string name, string email, string password, int phone) 
        : base(name, email, password, phone)
    {
        _catalogue = new();
    }

    public Product Advertise(Product product){
        if (product.Advertise.Life > 0) {
            Console.WriteLine("This product is already being advertised");
            
        }
        else {
            product.Advertise.Life = 5;
            Console.WriteLine("This product is now being advertised");
        }
        return product;
    }

    public Product Update(Product oldProduct, Product newProduct){
        if (_catalogue.ListOfProduct.FirstOrDefault( n => n.Name == oldProduct.Name ) != null){
            oldProduct.ProdId = newProduct.ProdId;
            oldProduct.Name = newProduct.Name;
            oldProduct.Price = newProduct.Price;
            oldProduct.Condition = newProduct.Condition;
            oldProduct.Description = newProduct.Description;
            oldProduct.Advertise = newProduct.Advertise;

            Console.WriteLine("Product updated successfully");
        }
        else Console.WriteLine("Couldn't find the product you're attempting to replace");
 
        return newProduct;
    }
    public string Remove(Product product){
        if (_catalogue.ListOfProduct.FirstOrDefault( n => n.Name == product.Name ) != null){
            _catalogue.ListOfProduct.Remove(product);
            return $"Product removed successfully";
        }
        else return $"The product you passed does not exist";
    }
    public string View(Product product){
        return product.PrintInfo();
    }
    
    public override string PrintInfo()
    {
        return $"Name: {base.Name}\nEmail: {base.Email}\nPassword: {base.Password}\nPhone: {base.Phone}\nCatalogue Items: {_catalogue.ListOfProduct.Count} Products\n";
    }

}