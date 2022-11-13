using System;
using System.Collections.Generic;

namespace Teaser;

public class Session
{
    private string _name;
    private Participant _speaker;
    private List<Participant> _participants;
    private RoomType _roomType;
    private List<Facility> _facilities;
    private int _maximumCapacity;
    private Boolean _fullStatus;
    private int _durationInDays;

    public Session(string name, Participant speaker, RoomType roomType, 
    int maximumCapacity, int durationInDays)
    {
        _name = name;
        _speaker = speaker;
        _roomType = roomType;
        _maximumCapacity = maximumCapacity;
        _durationInDays = durationInDays;
        _fullStatus = false;
        _participants = new();
        _facilities = new();
    }

    public string Name 
    {
        get => _name;
    }
    public Boolean FullStatus 
    {
        get => _fullStatus;
    }
    public List<Participant> Participants 
    {
        get => _participants;
    }

    public string RetrieveSessionDetails()
    {
        string facilityTypeName = "";
        foreach(Facility item in _facilities) facilityTypeName += $"{item.Type} ";
        return $"Name: {_name}\nDuration In Days: {_durationInDays}\nNumber of Participants: {_participants.Count}\nRoom Type: {_roomType}\nFacilty Type Name(s): {facilityTypeName}";
    }

    public void AddParticipant(Participant participant)
    {
        if (_participants.Count < _maximumCapacity) _participants.Add( participant );
        else {
            _fullStatus = true;
        }
    }

    public void RemoveParticipant(Participant participant)
    {
        _participants.Remove( participant );
        if (_participants.Count < _maximumCapacity) _fullStatus = false;
    }

    public void AddFacility(Facility facility)
    {
        _facilities.Add( facility );
    }


    public int CalculateTotalChargesForRoomAndFacility()
    {
        int facilitySum = 0;
        int roomSum = (int) _roomType;
        foreach(Facility item in _facilities) facilitySum += item.ChargesPerDay;
        
        return (facilitySum + roomSum) * _durationInDays;

    }

}

[Flags]
public enum RoomType
{
    MeetingRoom = 200,
    Auditorium = 500,
    BoardRoom = 200,
    Banquet = 800
}