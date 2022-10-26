using System;
using NUnit.Framework;

namespace Week7_Class;

[TestFixture]
public class GameObjectTest
{
    [Test]
    public void TestOwns()
    {
        Bomb bomb = new();
        Potion pot = new();

        GameObject game = new();
        game.Owns(bomb);
        game.Owns(pot);
        game.Owns(pot);
        game.Owns(bomb);

        Assert.AreEqual(4, game.Items.Count);
    }

    [Test]
    public void TestListAll()
    {
        Bomb bomb = new();
        Potion pot = new();

        GameObject game = new();
        game.Owns(bomb);
        // game.Owns(pot);
        // game.Owns(pot);
        // game.Owns(bomb);

        Assert.AreEqual("Run For you Life", game.ListAll());
    }
    
}