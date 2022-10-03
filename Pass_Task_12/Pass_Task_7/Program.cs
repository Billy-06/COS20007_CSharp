using System;
using Pass_Task_7.Talents;
using Pass_Task_7;

/**
    <summary>
        The class Program provides an entry point to our dotnet program. It contains
        a CastAll methods that prints out every single item in the list of talents passed
        to it along with a Main function which acts as the entry point.
    </summary>
*/
public class Program
{

    /**
        <summary>
            The CastAll is a void method that calls the Cast method belonging to the
            talent objects in the telent list passed to it.
        </summary>
    */
    private static void CastAll(Talent[] talents){

        for (int i = 0; i < talents.Length; i++){
            Console.WriteLine($"Talent Name: {talents[i].Name}\nTalent Level: {talents[i].Level}\nTalent Kind: {talents[i].Kind}\n");
            Console.WriteLine(talents[i].Cast());
            Console.WriteLine("========================================\n");
        }
    }
    public static void Main(string[] args)
    {
        NormalAttack chargeAttack = new( "Charge Attack", 1, 1 );
        NormalAttack randomCharge = new( "Random Charge", 2, 2 );
        NormalAttack swirl = new( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);
        
        // CastAll(talents);
        
        // Console.WriteLine(billy.AttackWith("Swirl"));
        // Console.WriteLine($"==============================");

        AlternateSprint playerThree = new("Princess Danger");
        
        for(int i = 0; i < 10; i++) Console.WriteLine(playerThree.Cast());

    }
}