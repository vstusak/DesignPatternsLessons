﻿using System;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

// drive: pri deserializaci - objekt by mel byt vytvoren takto (mit public settery a bezparametricky konstruktor)
// ted (4_2024) uz je pro deserializaci json mozne pouzit s parametrickym konstruktorem

public class Person : Object //toto dedeni je implicitne pritomne (doplnene kompilatorem)
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birth { get; set; }

    // implicitni konstruktor zpusobi, ze kdyz se pri tvorbe objektu nezada set propert, tak se nastavi defaultni hodnoty (Name = null, Age = 0, Birth = 1.1.1900)

    public override string ToString()
    {
        return  Name + " " + Age + " " + Birth;
    }

}


public class Animal(int limbCount)
{
    public readonly string Name1; // TODO dovysvětlit backing field (nemel by byt public)
    public string Name { get; } // toto je dobra praxe, kdyz parametr nema getter / setter, tak by mel byt private.
                                // Odebrany setter = po vytvoreni objektu neni mozne propertu zmenit vubec
    public int Age { get; private set; } // Private setter = po vytvoreni objektu je mozne propertu zmenit pouze metodou uvnitr tridy
    public DateTime Birth { get; set; }



    private string _location;
    public string Location 
    { 
        get 
        { 
            return _location; 
        }
        
        set
        {
            _location = value;
        }
    }

    public int LimbCount;

 public Animal(string name, int age, DateTime birth) : this(0) // parametricky konstruktor vynucuje zadani propert
    {
        Name = name;
        Age = age;
        Birth = birth;
    }

    //public Animal(string name, int age = 4) // parametricky konstruktor vynucuje zadani property Name (parametr name)
    //                                        // property Age je optional (ma defaultni hodnotu, ktera se do Age vlozi, pokud neni do parametru age nic vlozene
    //{
    //    Name = name;
    //    Age = age;
    //}

    public Animal(string name, int count) : this(count) // vice konstruktoru: parametricky konstruktor vynucuje zadani propert
    {
        Name = name;
    }
    public Animal() : this(0) // vice konstruktoru: beparametricky konstruktor, pro deserializaci (od .net 8 by to fungovalo a populoval by i Name, i kdyz nema 'set')
    {
    }

    public void ChangeAge(int newAge)
    {
        Age = newAge;
    }
    //public void ChangeName(string newName) // nejde pouzit, protoze neni 'set'
    //{
    //    Name = newName;
    //}
}

public class Dog(string name)
{
    public string Name => name;
}