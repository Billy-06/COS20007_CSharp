using System;

namespace Week7_Class;

public class GameObject
{
    private List<Component> _items;
    private Category _type;

    public GameObject()
    {
        _items = new();
        _type = Category.Beginner;
    }

    public List<Component> Items 
    {
        get => _items;
    }
    public Category Type 
    {
        get => _type;
        set => _type = value;
    }

    public void Owns(Component comp){
        _items.Add( comp );
    }

    public string ListAll()
    {
        if (_items.Count > 0) {
            string lines = "";
            foreach(Component comp  in _items) lines += $"{comp.Execute(this.Type)}" ;
            return $"{lines}";
        }
        else {
            return "This player doesn't have any Component Items";
        }
    }


}

public enum Category
{
    Beginner,
    Intermediate,
    Advanced
}