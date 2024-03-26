using System;

public class Person : Object //toto dedeni je implicitne pritomne (doplnene kompilatorem)
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birth { get; set; }

    public override string ToString()
    {
        return  Name + " " + Age + " " + Birth;
    }
}