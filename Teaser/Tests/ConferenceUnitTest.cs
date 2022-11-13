using System;
using NUnit.Framework;
using Teaser;

namespace Teaser.Tests;

[TestFixture]
public class ConferenceUnitTest
{
    [Test]
    public void TestCalculateTotalChargesForRoomAndFacility()
    {
        Participant spker = new(
            Category.Speaker,
            "Billy Micah",
            "Student Village",
            "me@you.mail"
        );

        Session sessn = new(
            "Teaching Programming",
            spker,
            RoomType.Auditorium,
            50,
            2
        );

        Facility fclty = new(
            FacilityType.Projector,
            "A projector for classwork",
            120
        );

        sessn.AddFacility( fclty );

        Assert.AreEqual(1240, sessn.CalculateTotalChargesForRoomAndFacility());
    }

    [Test]
    public void TestSessionCount()
    {
        Participant spker = new(
            Category.Speaker,
            "Billy Micah",
            "Student Village",
            "me@you.mail"
        );

        Session sessn = new(
            "Teaching Programming",
            spker,
            RoomType.Auditorium,
            50,
            2
        );

        Conference conf = new(
            "Effective Modern C++",
            2022
        );

        conf.AddSession( sessn );

        Assert.AreEqual(1, conf.Sessions.Count);
    }
}