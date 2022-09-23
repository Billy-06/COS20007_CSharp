using System;
using NUnit.Framework;

namespace Week3_Exercise;

[TestFixture]
public class Tests
{
    [Test]
    public void TestMadeBooking()
    {
        Booking mon = new Booking("Monday 2/2/2002", "4pm");
        Booking tue = new Booking("Tuesday 3/2/2002", "5pm");
        Booking wed = new Booking("Wednesday 4/2/2002", "5pm");
        Booking thur = new Booking("Thursday 5/2/2002", "8am");
        Booking fri = new Booking("Friday 6/2/2002", "3pm");

        Manager billy = new Manager("Billy", Department.IT);

        billy.MadeBooking(mon);
        billy.MadeBooking(tue);
        billy.MadeBooking(wed);
        billy.MadeBooking(thur);

        Assert.AreEqual(billy.AppointmentCount(), 4);
    }

    [Test]
    public void TestCancelBooking()
    {
        Booking mon = new Booking("Monday 2/2/2002", "4pm");
        Booking tue = new Booking("Tuesday 3/2/2002", "5pm");
        Booking wed = new Booking("Wednesday 4/2/2002", "5pm");
        Booking thur = new Booking("Thursday 5/2/2002", "8am");
        Booking fri = new Booking("Friday 6/2/2002", "3pm");

        Manager billy = new Manager("Billy", Department.IT);

        billy.MadeBooking(mon);
        billy.MadeBooking(tue);
        billy.MadeBooking(wed);
        billy.MadeBooking(thur);
        billy.MadeBooking(fri);

        billy.CancelBooking(mon);

        Assert.AreEqual(billy.AppointmentCount(), 4);
    }

    [Test]
    public void TestSearchBooking()
    {
        Booking mon = new Booking("Monday 2/2/2002", "4pm");
        Booking tue = new Booking("Tuesday 3/2/2002", "5pm");
        Booking wed = new Booking("Wednesday 4/2/2002", "5pm");
        Booking thur = new Booking("Thursday 5/2/2002", "8am");
        Booking fri = new Booking("Friday 6/2/2002", "3pm");

        Manager otherBilly = new Manager("Billy", Department.IT);

        otherBilly.MadeBooking(mon);
        otherBilly.MadeBooking(tue);
        otherBilly.MadeBooking(wed);
        otherBilly.MadeBooking(thur);
        otherBilly.MadeBooking(fri);

        Assert.AreEqual(otherBilly.SearchBooking(mon.Date, mon.Time), 1);
    }
    [Test]
    public void TestIndexer()
    {
        Booking mon = new Booking("Monday 2/2/2002", "4pm");
        Booking tue = new Booking("Tuesday 3/2/2002", "5pm");
        Booking wed = new Booking("Wednesday 4/2/2002", "5pm");
        Booking thur = new Booking("Thursday 5/2/2002", "8am");
        Booking fri = new Booking("Friday 6/2/2002", "3pm");

        Manager otherBilly = new Manager("Billy", Department.IT);

        otherBilly.MadeBooking(mon);
        otherBilly.MadeBooking(tue);
        otherBilly.MadeBooking(wed);
        otherBilly.MadeBooking(thur);
        otherBilly.MadeBooking(fri);

        Assert.AreEqual(otherBilly[2], wed);
        Assert.AreEqual(otherBilly[0], mon);
    }


}