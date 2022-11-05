using System;
using BuySellTrade_App.Components;

namespace BuySellTrade_App;
internal class Program
{
    private static void Main(string[] args)
    {
        RegistrationController controller = new();
        controller.WelcomePage();
    }
}