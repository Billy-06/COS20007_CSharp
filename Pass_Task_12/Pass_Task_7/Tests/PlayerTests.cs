using NUnit.Framework;
using System;
using Pass_Task_7.Talents;

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
     *      This test performs an assertion test on the number of talents
     *      available to the player after using the AddTalent() method
     *  <br/>
     * </summary>
     */
    [Test]
    public void TestAddTalent()
    {
        NormalAttack chargeAttack = new( "Charge Attack", 1, 1 );
        NormalAttack randomCharge = new( "Random Charge", 2, 2 );
        NormalAttack swirl = new( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        Assert.AreEqual(3, billy.Talents.Count);
    }

    /**
     * <summary>
     * 
     *  <br/>
     *  (ii) Remove Talent
     *  <br/>
     *      This test performs an assertion test on the number of talents
     *      after using the RemoveTalent() method.
     * 
     *  <br/>
     * </summary>
     */
    [Test]
    public void TestRemoveTalent()
    {
        NormalAttack chargeAttack = new( "Charge Attack", 1, 1 );
        NormalAttack randomCharge = new( "Random Charge", 2, 2 );
        NormalAttack swirl = new( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        billy.RemoveTalent(swirl);

        Assert.AreEqual(2, billy.Talents.Count);
    }
    /**
     * <summary>
     * 
     *  <br/>
     *  (iii) Fetching Talent
     *  <br/>
     *      This test performs an assertion test on whether talents are
     *      retrievable from the player using indices. It compares and 
     *      instance of the talent class with a talent retrieved from the 
     *      player talent list.
     * 
     *  <br/>
     * </summary>
     */
    [Test]
    public void TestFetchingTalent()
    {
        NormalAttack chargeAttack = new( "Charge Attack", 1, 1 );
        NormalAttack randomCharge = new( "Random Charge", 2, 2 );
        NormalAttack swirl = new( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        Assert.AreEqual(randomCharge, billy[1]);
        Assert.AreEqual(randomCharge.Name, billy[1].Name);
    }

    /**
     * <summary>
     * 
     *  <br/>
     *  (iv) AttackWith() method
     *  <br/>
     *      This test performs an assertion test on the string value returned
     *      after using the AttackWith() method in the player
     * 
     *  <br/>
     * </summary>
     */
    [Test]
    public void TestAttackWith()
    {
        NormalAttack chargeAttack = new( "Charge Attack", 1, 1 );
        NormalAttack randomCharge = new( "Random Charge", 2, 2 );
        NormalAttack swirl = new( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        string outputString = $"Player {billy.Name} attacking with:\nTalent Name: {swirl.Name}\nTalent Level: {swirl.Level}\nTalent Kind: {swirl.Kind }\n{swirl.Cast()}";

        Assert.AreEqual(outputString, billy.AttackWith("Swirl"));
        
    }

    /**
     * <summary>
     * 
     *  <br/>
     *  (v) GetTalents
     *  <br/>
     *      This test performs an assertion test on whether the list of talents
     *      of a player contains an instance of a talent.
     * 
     *  <br/>
     * </summary>
     */
    [Test]
    public void TestGetTalents()
    {
        NormalAttack chargeAttack = new( "Charge Attack", 1, 1 );
        NormalAttack randomCharge = new( "Random Charge", 2, 2 );
        NormalAttack swirl = new( "Swirl", 4, 4 );
        
        Player billy = new Player("Billy");
        Talent[] talents = { chargeAttack, randomCharge, swirl };
        billy.AddTalent(talents);

        string outputString = $"Player {billy.Name} attacking with:\nTalent Name: {swirl.Name}\nTalent Level: {swirl.Level}\nTalent Kind: {swirl.Kind }\n{swirl.Cast()}";

        Assert.IsTrue(billy.Talents.Contains(swirl));
        Assert.IsTrue(billy.Talents.Contains(randomCharge));
        
    }
}