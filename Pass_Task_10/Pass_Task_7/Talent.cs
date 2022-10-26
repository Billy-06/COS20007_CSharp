using System;
namespace Pass_Task_7;

/**
    <summary>
    Talent Level:
    </br>
    This is an enumeration containing three different talent levels
    available to the talent Level. The enumeration uses flags, which
    can be used while instiating the class Talent.
    </summary>
*/
[Flags]
public enum Level
{
    Beginner = 1,
    Intermediate = 2,
    Advanced = 4
}

/**
    <summary>
    Talent Kind:
    </br>
    This is an enumeration containing three different talent kinds
    available to the talent Kind. The enumeration uses flags, which
    can be used while instiating the class Talent.
    </summary>
*/
[Flags]
public enum Kind
{
    NormalAttack = 1,
    ElementalSkill = 2,
    AlternateSprint = 4
    
}

/**
    [ Pass Task 8 ]
    <summary>
    The Talent class defines three talent attributes namely, 
    the name (string type), the Level of the talent (Enum type Level),
    and the kind of talent (Enum type Kind). 
    <br/>
    It contains properties for all of the three private attributes, and
    all three properties have getters and setters
    <br/>
    
    The Enums use flags which can also be used to instantiate an instance of
    a Talent object.
    <br/>

    The Talent class has three constructors
    <br/>
    (i) Default Constructor - the default constructor takes no parameters
        and assigns the player a name 'Unknown Talent', a skill level of beginner
        and a talent Kind Normal. These values can thereafter be changed using
        their respective getters and setters.
    <br/>

    (ii) Name-Only Constructor - This constructor allows instantiation 
        by simply providing the name of the talent, the Level defaults to 
        Beginner, (since you'd mostly start a game at level one - beginner)
        and the Kind defaults to Normal. Again the defaulted values can be 
        change using their respective getters and setters.
    <br/>
    
    (iii) Explicit Constructor - This constructor takes all three parameters
        requiring the user to explicitly state the talent's name, level and
        talent kind.
    <br/>

    The Talent class also contains a Cast() method that returns strings depending
    on the talent level or talent kind the respective instance has.
    <br/>

    </summary>
*/
public class Talent{
    /**
        <summary>
        Private Attribute _name:
        
        <br/>
        This is a string type attribute that contains the name of the
        talent instance
        </summary>
    */
    private string _name;

    /**
        <summary>
        Private Attribute _level:
        </br>
        This is a Level type attribute that contains the talent level of the
        talent instance. See the docs on Level (Enum)
        </summary>
    */
    private Level _level;

    /**
        <summary>
        Private Attribute _level:
        </br>
        This is a Kind type attribute that contains the talent kind of the
        talent instance. See the docs on Kind (Enum)
        </summary>
    */
    private Kind _kind;

    /**  
        <summary>
        Default Constructor:
        <br/>
        Default constructor starts with assigns the talent name unknown
        the talent level is assigned as Beginner level and the kind 
        of attack is the most basic.
        </summary>

        <returns>
            This constructor returns an instance of the Talent class.
        </returns>
    */
    public Talent()
    {
        _name = "Unknown Talent";
        _level = Level.Beginner;
        _kind = Kind.NormalAttack;
    }


    /** 
        <summary>
        Name Constructor:
        <br/>
        This constructor takes the name of the talent and presumes both
        the level and kind are basic level. Constructors are provided if 
        the levels and kind need changing.
        </summary>

        <param name="talent_name">
            Provide a string value as the name of the talent instance.
        </param>

        <returns>
            This constructor returns an instance of the Talent class.
        </returns>
     */
    public Talent(string talent_name)
    {
        _name = talent_name;
        _level = Level.Beginner;
        _kind = Kind.NormalAttack;
    }

    /**
        <summary>
        Explicit Constructor:
        <br/>
        This constructor takes all three parameters
        requiring the user to explicitly state the talent's name, level and
        talent kind.
        
        </summary>
        
        <param name="talent_name">
            Provide a string value for the name of the talent instance
        </param>
        <param name="level_name">
            Provide an integer value [1, 2 or 4]. This is a flagged 
            enumeration, provide the int value <br/>
            1 for Beginner,<br/> 2 for Intermediate,<br/> 4 for Advanced
        </param>
        <param name="kind_name">
            Provide an integer value [1, 2 or 4]. This is a flagged 
            enumeration, provide the int value <br/>
            1 for NormalAttack,<br/> 2 for ElementalSkill,<br/> 4 for AlternateSprint
        </param>

        <returns>
            This constructor returns an instance of the Talent class.
        </returns>
    */
    public Talent(string talent_name, int level_name, int kind_name)
    {
        _name = talent_name;
        _level = (Level)level_name;
        _kind = (Kind)kind_name;
    }
    
    /**
        <summary>
        Property Name:
        </br>
            This property provides access to the private attribute _name. The
            property contains a getter and a setter to retrieve and change the
            _name of the instance.
        </summary>
        <returns>
            It returns a string type when called and requires a string type
            to be provided when changing the _name attribute
        </returns>
    */
    public string Name {
        get => _name; 
        set => _name = value;
    }
    
    /**
        <summary>
        Property Level:
        </br>
            This property provides access to the private attribute _level. The
            property contains a getter and a setter to retrieve and change the
            _level of the instance. 
        </summary>
        <returns>
            It returns an Enum type when called and
            requires an int (which acts as a flag for the Enum) type to be 
            provided when changing the _level attribute
        </returns>
    */
    public Level Level { 
        get => _level;
        set => _level = value;
    }
    
    /**
        <summary>
        Property Kind:
        </br>
            This property provides access to the private attribute _kind. The
            property contains a getter and a setter to retrieve and change the
            _kind of the instance. 
        </summary>

        <returns>
            It returns an Enum type when called and
            requires an int (which acts as a flag for the Enum) type to be 
            provided when changing the _kind attribute
        <returns>
    */
    public Kind Kind {
        get => _kind;
        set => _kind = value; 
    }
    

    /**
        <summary>
            Cast Method:
        <br/>
            This methods check the talents instance's Level and Kind and returns a
            string type value based on the mentioned attributes
        </summary>

        <returns>
            A string type valuedepending on the Level and Kind: <br/>
            (i.e) <br/>
            Level.Advanced => Expect the string 'Be Prepared to Feel the Swirl' <br/>
            Level.Intermediate => Excpect the string 'Feel the Force' <br/>
            Otherwise => Expect the string 'Zapp.. First Stage Triggered' <br/>
        </returns>
    */
    public string Cast(){
        
        if (_level == Level.Advanced){
            return $"\tBe Prepared to Feel the Swirl";
        }
        else if(_level == Level.Intermediate && (_kind == Kind.NormalAttack || _kind == Kind.ElementalSkill)){
            return $"\tFeel the Force";
        }
        else {
           return $"\tZapp.. First Stage Triggered";

        }
    }
    
}