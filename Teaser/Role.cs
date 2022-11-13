using System;

namespace Teaser;

public abstract class Role
{
    private Category _category;

    public Role(Category category)
    {
        _category = category;
    }


    public abstract void ViewInfo();
}



public enum Category
{
    Admin,
    Editor,
    Reviewer,
    Speaker,
    Audience
}