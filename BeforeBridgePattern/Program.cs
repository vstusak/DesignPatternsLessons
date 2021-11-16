using BeforeBridgePattern.Models;
using System;

namespace BeforeBridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public interface IView
    {
        public IProduct Product { get; set; }
        public void Render();
    }

    public class PromotionView : IView
    {
        public IProduct Product { get; set; }

        public void Render()
        {
            Console.WriteLine("PromotionView");
            Console.WriteLine(Product.GetDescription());
        }
    }

    public class MainView : IView
    {
        public IProduct Product { get; set; }

        public void Render()
        {
            Console.WriteLine("MainView");
            Console.WriteLine(Product.GetDescription());
        }
    }

    public class DetailView : IView
    {
        public IProduct Product { get; set; }

        public void Render()
        {
            Console.WriteLine("DetailView");
            Console.WriteLine(Product.GetDescription());
        }
    }

    public class AccessoriesView : IView
    {
        public IProduct Product { get; set; }

        public void Render()
        {
            Console.WriteLine("AccessoriesView");
            Console.WriteLine(Product.GetDescription());
        }
    }
}
