using NUnit.Framework;
using System;
using Pass_Task_7.Talents;

namespace Pass_Task_7.Tests;

/**
    <summary>

        This Class contains Three tests on the talent class
        <br/>
        Talent Tests<br/>
        ------------<br/>
        <br/>
        (i) BeginnerNormalTalent
        <br/>
            This test is meant to test the cast message from the beginner
            class.
        <br/>
        (ii) IntermediateNormalTalent
        <br/>
            This test performs an assertion test on the cast message from
            the talent instane with both Intermediate Level and Elemental
            skill kind.
        <br/>
        (iii) AdvancedNormalTalent
        <br/>
            This test performs an assertion test on the message returned
            if the talent instance has a level, Advanced and is of kind,
            Alternate Skill.
        <br/>
        
    </summary>

*/

[TestFixture]
public class TalentTests
{
    /**
        <summary>
        1. BeginnerNormalTalent:<br/>
            Checks that you can create a NormalAttack object of Beginner level and 
            that it returns the right messages upon calling the Cast()
        </summary>
    */
    [Test]
    public void BeginnerNormalTalent()
    {
        NormalAttack playerOne = new("The Slayer");
        Assert.AreEqual("\t4 consecutive strikes triggered", playerOne.Cast());
    }


    /**
        <summary>
        2. IntermediateNormalTalent:<br/>
            Checks that you can create a NormalAttack object of Intermediate level with
            Elemental Skill talent kind, and that it returns the right messages upon
            calling the Cast()
        </summary>
    */
    [Test]
    public void IntermediateNormalTalent()
    {
        NormalAttack playerTwo = new("The BodyGuard", 2, 2);
        Assert.AreEqual("\tA powerful final slash strike", playerTwo.Cast());

    }

    /**
        <summary>
        3. AdvancedNormalTalent:<br/>
            Performs an AreEqual test which checks against the string returned by 
            the cast method if the NormalAttack talent object had level advanced.
        </summary>
    */
    [Test]
    public void AdvancedNormalTalent()
    {
        NormalAttack playerThree = new("Indulgence Traveler", 4, 1);
        Assert.AreEqual("\tPlunging attack triggered", playerThree.Cast());
    }

    /**
        <summary>
        4. TestAlternateSkill:</br>
            This performs an AreWqual tests to check against the string outputted
            as the stamina steadily decreases when calling the cast() method from
            the AlternateSprint talent class.
        </summary>
     */
    [Test]
    public void TestAlternateSkill()
    {
        AlternateSprint playerThree = new("Princess Danger");

        Assert.AreEqual("You can now move at high speed in water", playerThree.Cast());
        for(int i = 0; i < 5; i++) Assert.AreEqual("Sprint triggered on the road", playerThree.Cast());
        for(int i = 0; i < 3; i++) Assert.AreEqual("Sprint at reduced level", playerThree.Cast());
        Assert.AreEqual("No more sprint is allowed", playerThree.Cast());
        
    }
    /**
        <summary>
        5. TestElementalSkill:</br>
            This performs an AreEqual test which checks against the expected value after
            calling the cast() method from ElementalSkill talent class.
        </summary>
     */
    [Test]
    public void TestElementalSkill()
    {
        ElementalSkill whisperer = new("Tiger Whisperer");
        Assert.AreEqual($"Cool Down Period Activated:\nCharge: {whisperer.Charge}", whisperer.Cast());
    }

}

