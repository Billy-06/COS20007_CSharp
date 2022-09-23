using System;

using COS20007_CSharp;

class Program
{

    static void CastAll(Talent[] talents){

        for (int i = 0; i < talents.Length; i++){
            Console.WriteLine($"Talent Name: {talents[i].Name}\nTalent Level: {talents[i].Level}\nTalent Kind: {talents[i].Kind}\n");
            Console.WriteLine(talents[i].Cast());
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