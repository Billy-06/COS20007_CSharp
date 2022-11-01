using System;
namespace BuySellTrade_App.Components;


public class Advertisement
{
    public int Life { get; set; }

    public Advertisement()
    {
        Life = 0;
    }
    public Advertisement(int life)
    {
        Life = life;
    }
    public void End()
    {
        if (Life > 0) {
            Life = 0;
            Console.WriteLine("The advertisement has been ended");
        } else {
            Console.WriteLine("No active advertisement was found");
        }
    }
}