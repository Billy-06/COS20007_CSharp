using NUnit.Framework;
using System;
namespace Pass_Task_7.Tests;


/**
 * <summary>
 * Player Tests<br/>
 * ------------<br/>
 * This class contains four tests performed on the player class.
 * </summary>
 */
[TestFixture]
public class PlayerTests
{
    
    /**
     * <summary>
     * 
     *  <br/>
     *  (i) Add Talent
     *  <br/>
     *      This test performs an assertion test on the message returned
     *      if the talent instance has a level, Advanced and is of kind,
     *      Alternate Skill.
     *  <br/>
     * </summary>
     */
    [Test]
    public void TestAddTalent()
    {
        Talent chargeAttack = new Talent( "Charge Attack", 1, 1 );
        Talent randomCharge = new Talent( "Random Charge", 2, 2 );
        Talent swirl = new Talent( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        Assert.AreEqual(3, billy.Talents.Count);
    }
    [Test]
    public void TestRemoveTalent()
    {
        Talent chargeAttack = new Talent( "Charge Attack", 1, 1 );
        Talent randomCharge = new Talent( "Random Charge", 2, 2 );
        Talent swirl = new Talent( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        billy.RemoveTalent(swirl);

        Assert.AreEqual(2, billy.Talents.Count);
    }
    [Test]
    public void TestFetchingTalent()
    {
        Talent chargeAttack = new Talent( "Charge Attack", 1, 1 );
        Talent randomCharge = new Talent( "Random Charge", 2, 2 );
        Talent swirl = new Talent( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        Assert.AreEqual(randomCharge, billy[1]);
        Assert.AreEqual(randomCharge.Name, billy[1].Name);
    }
    [Test]
    public void TestAttackWith()
    {
        Talent chargeAttack = new Talent( "Charge Attack", 1, 1 );
        Talent randomCharge = new Talent( "Random Charge", 2, 2 );
        Talent swirl = new Talent( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        string outputString = $"Player {billy.Name} attacking with:\nTalent Name: {swirl.Name}\nTalent Level: {swirl.Level}\nTalent Kind: {swirl.Kind }\n{swirl.Cast()}";

        Assert.AreEqual(outputString, billy.AttackWith("Swirl"));
        
    }
}