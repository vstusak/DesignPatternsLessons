public class OneClickBuyCommand : ICommand
{
    private int _productId;
    private int _count;

    public OneClickBuyCommand(int productId, int count)
    {
        _productId = productId;
        _count = count;
    }

    public void Invoke()
    {
        //here some work will happen
        throw new NotImplementedException();
    }
}
