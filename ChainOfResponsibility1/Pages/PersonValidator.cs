using ChainOfResponsibility1.Entities;
using ChainOfResponsibility1.Handlers;

namespace ChainOfResponsibility1.Pages;

public class PersonValidator
{
    private readonly List<IHandler<Person>> _list;

    public PersonValidator()
    {
        _list = new List<IHandler<Person>>();

        _list.Add( new NameValidationHandler());
        _list.Add(new SurnameValidationHandler());
        _list.Add(new AdultValidationHandler());
        _list.Add(new NinoValidationHandler());
    }

    public PersonValidator(List<IHandler<Person>> list)
    {
        _list = list;
    }

    public bool Validate(Person person)
    {
        //IHandler<Person> chain = null;

        var nameHandler =new NameValidationHandler();
        nameHandler.SetNext(new SurnameValidationHandler()).SetNext(new AdultValidationHandler()).SetNext(new NinoValidationHandler());
        try
        {
            nameHandler.Handle(person);
            return true;
        }
        catch
        {
            return false;
        }
    }
}