using System;
using System.Collections.Generic;

namespace Teaser;

public class Conference
{
    private string _title;
    private int _year;
    private List<Session> _sessions;

    public Conference(string title, int year)
    {
        _title = title;
        _year = year;
        _sessions = new();
    }

    public List<Session> Sessions
    {
        get => _sessions;
    }

    public void AddSession(Session session)
    {
        _sessions.Add( session );
    }
    public void RemoveSession(Session session)
    {
        if (_sessions.Count > 0) _sessions.Remove( session );

    }
    public void PrintDetails()
    {
        Console.WriteLine($"Year: {_year}");
        foreach(Session item in _sessions) Console.WriteLine(item.RetrieveSessionDetails());
        Console.WriteLine("=========================");
    }

    public void ViewSessionParticipantList(string sessionName)
    {
        var sessn = _sessions.FirstOrDefault<Session>( n => n.Name.ToLower() == sessionName.ToLower());
        if (sessn != null)
        {
            foreach(Participant item in sessn.Participants)
            {
                item.ViewInfo();
            }
        }
    }

    public Boolean RegisterParticipantIntoSession(string sessionName, Participant participant)
    {
        var sessn = _sessions.FirstOrDefault<Session>( n => n.Name.ToLower() == sessionName.ToLower());
        if (sessn != null)
        {
            if (sessn.FullStatus) return false;
            else {
                sessn.AddParticipant( participant );
                return true;
            }
        } else {
            return false;
        }
    }

    public int CalculateTotalSessionCharges()
    {
        int totalCost = 0;
        foreach(Session item in _sessions) totalCost += item.CalculateTotalChargesForRoomAndFacility();

        return totalCost;
    }
}