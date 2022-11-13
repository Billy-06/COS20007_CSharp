using System;
using Teaser;
public class Program
{
    private static void Main()
    {
        // Organiser
        Organizer orgnzer = new(
            Category.Admin,
            "MicroBolt"
        );

        // Speaker
        Participant spker = new(
            Category.Speaker,
            "Billy Micah",
            "Student Village",
            "me@you.mail"
        );

        // Session
        Session sessn = new(
            "Teaching Programming",
            spker,
            RoomType.Auditorium,
            50,
            2
        );

        // Facility

        Facility fclty = new(
            FacilityType.Projector,
            "A projector for classwork",
            120
        );

        // Conference
        Conference conf = new(
            "Effective Modern C++",
            2022
        );

        // Participant
        Participant joe = new(
            Category.Audience,
            "Joe Stevens",
            "Next Door",
            "he@his.mail"
        );



        sessn.AddFacility( fclty );
        conf.AddSession( sessn );
        orgnzer.AddConference( conf );

        sessn.AddParticipant( joe );

        Console.Clear();
        Console.WriteLine("Organizer Details");
        Console.WriteLine("==========================");
        orgnzer.ViewInfo();
        Console.WriteLine("\n");
        Console.WriteLine("Participants Details");
        Console.WriteLine("==========================");
        conf.ViewSessionParticipantList("Teaching Programming");
    }
}