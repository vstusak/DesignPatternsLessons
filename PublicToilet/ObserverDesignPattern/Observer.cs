namespace PublicToilet.ObserverDesignPattern;

public class Observer : IToiletObserver
{
    private readonly IObservableToilet _observableObject;
    private readonly TextBox textBox1;

    public Observer(IObservableToilet observableObject, TextBox textBox1)
    {
        _observableObject = observableObject;
        this.textBox1 = textBox1;
    }
    public void Update()
    {
        var state = _observableObject.GetState();
        textBox1.AppendText(state + Environment.NewLine);
    }
}