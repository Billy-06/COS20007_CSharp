using System;

using COS20007_CSharp;

class Program
{

    static void CastAll(Talent[] talents){

        for (int i = 0; i < talents.Length; i++){
            Console.WriteLine($"Name: {talents[i].Name}\nLevel: {talents[i].Level}\nKind: {talents[i].Kind}\n{talents[i].Cast()}");
            Console.WriteLine("========================================");
        }
    }
    static void Main(string[] args)
    {
        Talent chargeAttack = new Talent( "Charge Attack", 1, 1 );
        Talent randomCharge = new Talent( "Random Charge", 2, 2 );
        Talent swirl = new Talent( "Swirl", 4, 4 );
        
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        
        CastAll(talents);
    }
}