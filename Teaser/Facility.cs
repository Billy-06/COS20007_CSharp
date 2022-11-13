using System;

namespace Teaser;

public class Facility
{
    private FacilityType _type;
    private string _description;
    private int _chargesPerDay;

    public Facility(FacilityType type, string description, int chargesPerDay)
    {
        _type = type;
        _description = description;
        _chargesPerDay = chargesPerDay;
    }

    public FacilityType Type 
    {
        get => _type;
        set => _type = value;
    }
    public string Description 
    {
        get => _description;
        set => _description = value;
    }
    public int ChargesPerDay 
    {
        get => _chargesPerDay;
        set => _chargesPerDay = value;
    }
}

public enum FacilityType
{
    Projector,
    FlipChart,
    PenSet,
    Catering,
    TV
}