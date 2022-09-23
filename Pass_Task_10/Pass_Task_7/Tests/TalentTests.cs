using NUnit.Framework;
using System;
namespace Pass_Task_7.Tests;

/**
    <summary>

        This Class contains Three tests on the talent class
        <br/>
        Talent Tests<br/>
        ------------<br/>
        <br/>
        (i) BeginnerCast
        <br/>
            This test is meant to test the cast message from the beginner
            class.
        <br/>
        (ii) IntermediateElementalSkill
        <br/>
            This test performs an assertion test on the cast message from
            the talent instane with both Intermediate Level and Elemental
            skill kind.
        <br/>
        (iii) AdvancedAlternateSkill
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
        1. TestBeginnerCast:<br/>
            Checks that you can create a Talent object of Beginner level and 
            that it returns the right messages upon calling the Cast()
        </summary>
    */
    [Test]
    public void BeginnerCast()
    {
        Talent playerOne = new Talent("The Slayer", 1, 1);
        Assert.AreEqual("\tZapp.. First Stage Triggered", playerOne.Cast());
    }


    /**
        <summary>
        2. TestIntermediateElementalSkill:<br/>
            Checks that you can create a Talent object of Intermediate level with
            Elemental Skill talent kind, and that it returns the right messages upon
            calling the Cast()
        </summary>
    */
    [Test]
    public void IntermediateElementalSkill()
    {
        Talent playerTwo = new Talent("The BodyGuard", 2, 2);
        Assert.AreEqual("\tFeel the Force", playerTwo.Cast());

    }

    /**
        <summary>
        3. TestAdvanceAlternateSprint:<br/>
            Check you can create a Talent object of Advance level with
            Alternate Sprint talent kind, and it returns the right messages
            upon calling the Cast()
        </summary>
    */
    [Test]
    public void AdvancedAlternateSkill()
    {
        Talent playerThree = new Talent("Princess Danger", 4, 4);
        Assert.AreEqual("\tBe Prepared to Feel the Swirl", playerThree.Cast());
    }

}

