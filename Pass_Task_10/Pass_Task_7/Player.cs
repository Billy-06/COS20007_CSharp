using System;
using System.Collections.Generic;
using System.Linq;

namespace Pass_Task_7;

/**
 * <summary>
 * The player class describes a player object and contains attributes 
 * as below:<br/>
 * (i) Name : String -  This is meant to be the name of the player.
 * <br/>
 * (ii) Energy Level: Int - The player energy level is represented by an
 *          integer value. Upon instantiation it defaults to 200.
 * <br/>
 * (iii) Health Status: Boolean - The player health status is represented by
 *          boolean values and at objet instantiation defaults to true.
 * <br/>
 * (iv) Talents: List<Talents> - The player can objtain/loose talents and
 *          these are stored in a generic list of talents.
 * <br/>
 * </summary>
 */
public class Player
{
    private string _name;
    private int _energyLevel;
    private Boolean _healthStatus;
    private List<Talent> _talents;

    /**
     * <summary>
     * Name-Only Constructor<br/>
     * This Constructor only takes a name value at instatiation as a string. The
     * rest of the attributes are defaulted to the below values:
     * <br/>
     * (i) Energy Level defaults to 200 <br/>
     * (ii) Health Status defaults to true <br/>
     * (iii) Talents defaults to an empty List <br/>
     * </summary>
     * <param name="name">
     * Name:<br/>
     * Pass a string value to be assigned as the player's name
     * </param>
     */
    public Player(string name)
    {
        _name = name;
        _energyLevel = 200;
        _healthStatus = true;
        _talents = new List<Talent>();   
    }

    /**
     * <summary>
     * Name & Talent Constructor<br/>
     * This Constructor takes a string value which is the player name , and 
     * a talent object which is the player's talent; the talent is added to 
     * the list of talents. The rest of the attributes are defaulted 
     * to the below values:
     * <br/>
     * (1) Energy Level defaults to 200 <br/>
     * (2) Health Status defaults to true <br/>
     * </summary>
     * <br/>
     * 
     * <param name="name">
     * Name:<br/>
     * Pass a string value to be assigned as the player's name
     * </param>
     * <param name="talent">
     * Talent:<br/>
     * Pass a talent object to be added to the player list of talents
     * </param>
     */
    public Player(string name, Talent talent)
    {
        _name = name;
        _energyLevel = 200;
        _healthStatus = true;

        _talents = new List<Talent>();
        _talents.Add( talent );
        
    }

    /**
     * <summary>
     * This is a read only property to help with retriving the player talents
     * </summary>
     */
    public List<Talent> Talents 
    { 
        get => _talents;
    }

    /**
     * <summary>
     * This is a property that allows for changing the player energy level or retrieving it. 
     * Provide an integer value to update/set the player's energy levels.
     * </summary>
     * <return>
     * If used as a getter it returns an integer value of the energy level
     * </return>
     */
    public int EnergyLevel { 
        get => _energyLevel;
        set => _energyLevel = value;
    }

    /**
     * <summary>
     * This is a property that allows for changing the player name or retrieving it. 
     * Provide string value to update/set the player's name.
     * </summary>
     * <return>
     * If used as a getter it returns an string value of the player name
     * </return>
     */
    public string Name { 
        get => _name;
        set => _name = value;
    }

    /**
     * <summary>
     * This is a property that allows for changing the player health status or retrieving it.
     * Provide a boolean value to update or set the player's health status.
     * </summary>
     * <return>
     * Returns a boolean value if used as an attribute accessor.
     * </return>
     */
    public Boolean HealthStatus { 
        get => _healthStatus;
        set => _healthStatus = value;
    }

    /**
     * <summary>
     * This Method AddTalent adds a single talent to the list of talents 
     * the player contains
     * </summary>
     * <param name="talent">
     * Pass a single talent object to be added to the player list of talents
     * </param>
     */
    
    public void AddTalent(Talent talent)
    {
        _talents.Add( talent );
    }
    

    /**
     * <summary>
     * This method takes an array of talents and adds each item in the
     * array to the list of talents the player has.
     * </summary>
     * <param name="talents">
     * Pass an Array of talents to be added to the list of player's talents
     * </param>
     */
    public void AddTalent(Talent[] talents)
    {
        foreach(Talent item in talents)
        {
            _talents.Add( item );
        }
    }

    /**
     * <summary>
     * This Method RemoveTalent removes a single talent to the list of talents 
     * the player possesses
     * </summary>
     * <param name="talent">
     * Pass a single talent object to be removed from the player list of talents
     * </param>
     */
    public void RemoveTalent(Talent talent)
    {
        _talents.Remove( talent );
    }

    /**
     * <summary>
     * This method prints out all the talents a player has obtained
     * </summary>
     */
    public void ShowTalents()
    {
        Console.WriteLine("===== Player Talents ======");
        foreach(Talent item in _talents) 
        {
            Console.WriteLine($"Talent Name: {item.Name}\nTalent Kind: {item.Kind}\nTalent Level: {item.Level}");
        }
    }

    /**
     * <summary>
     * This method prints out both the player details along with the talents they posses
     * </summary>
     */
    public void PrintStats()
    {
        Console.WriteLine("===== Player Details ======");
        Console.WriteLine($"Name: {_name}\nEnergy Level: {_energyLevel}\nHealth Status: {_healthStatus}");
        this.ShowTalents();
    }

    /**
     * <summary>
     * This is an indexer that allows users to use indexing in accessing the player
     * talents. This is a read only property.
     * </summary>
     */
    public Talent this[int i] => _talents[i];


    /**
     * <summary>
     * This is a string type method that returns a message affirming that the player is
     * attacking using the talent with the name passed. If no such talent exists
     * the method prints out a message confirming the talent was not found.
     * </summary>
     * 
     * <param name="talentName">
     * Pass a talent name to be used in attacking
     * </param>
     * 
     * <return>
     *  Returns a string value showing the talent being used in attacking or affirming that
     * the player doesn't have any talents yet.
     * </return>
     */
    public string AttackWith(string talentName)
    {
        // using FirstOrDefault for enumarable types: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault?view=net-7.0#definition
        if (_talents.FirstOrDefault( n => n.Name == talentName) != null){
            var found = _talents.FirstOrDefault( n => n.Name == talentName);
            return $"Player {this._name} attacking with:\nTalent Name: {found.Name}\nTalent Level: {found.Level}\nTalent Kind: {found.Kind }\n{found?.Cast()}";
        }
        else{
            return "No such talent found for this player";
        }
    }
    
}