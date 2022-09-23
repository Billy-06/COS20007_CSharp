using System;

namespace COS20007_CSharp;

[Flags]
 public enum Level{
        Beginner = 1,
        Intermediate = 2,
        Advanced = 4
    }
[Flags]
public enum Kind{
    NormalAttack = 1,
    ElementalSkill = 2,
    AlternateSprint = 4
    
}

public class Talent{
    private string _name;
    private Level _level;
    private Kind _kind;

    /*  
        Default constructor starts with assigns the talent name unknown
        the talent level is assigned as Beginner level and the kind 
        of attack is the most basic
    */
    public Talent()
    {
        _name = "Unknown Talent";
        _level = Level.Beginner;
        _kind = Kind.NormalAttack;
    }


    /* 
        This constructor takes the name of the talent and presumes both
        the level and kind are basic level. Constructors are provided if 
        the levels and kind need changing.
     */
    public Talent(string talent_name)
    {
        _name = talent_name;
        _level = Level.Beginner;
        _kind = Kind.NormalAttack;
    }

    /*
        Value assigned constructor where a talent is 
    */
    public Talent(string talent_name, int level_name, int kind_name)
    {
        _name = talent_name;
        _level = (Level)level_name;
        _kind = (Kind)kind_name;
    }

    public string Name {
        get { return _name; }
        set { _name = value; }
    }
    
    public Level Level { 
        get {return _level;}
        set { _level = value; }
    }
    
    public Kind Kind {
        get {return _kind;}
        set { _kind = value; }
    }
    


    public string Cast(){
        
        if (_level == Level.Advanced)
        {
            return $"\tBe Prepared to Feel the Swirl";
        }
        else if(_level == Level.Intermediate && (_kind == Kind.NormalAttack || _kind == Kind.ElementalSkill))
        {
            return $"\tFeel the Force";
        }
        else 
        {
           return $"\tZapp.. First Stage Triggered";

        }
    }
    
}