// See https://aka.ms/new-console-template for more information

using VisitorPattern.Products;
using VisitorPattern.Visitors;
using System;

namespace VisitorPattern
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello, World!");

            var cartCollector = new CartCollector();
            var statisticsVisitor = new StatisticsVisitor();
            var discountVisitor = new DiscountVisitor();

            var cart = new Cart();

            cart.AddItem(new Toy("RC Car", 100));
            cart.AddItem(new Book("Cooking 101 for SW devs", 20));
            cart.AddItem(new Electronics("Toaster", 50));

            cart.ApplyVisitor(statisticsVisitor);
            cart.Order();

            cartCollector.Collect(cart);

            var cart2 = new Cart();


            cart2.AddItem(new Toy("RC Car", 100));
            cart2.AddItem(new Book("Cooking 101 for SW devs", 20));
            cart2.AddItem(new Electronics("Toaster", 50));

            cart2.ApplyVisitor(statisticsVisitor);
            cart2.Order();
            cartCollector.Collect(cart2);

            cartCollector.Report();

            Console.WriteLine("With Visitor:");
            statisticsVisitor.Report();
        }
    }
}

