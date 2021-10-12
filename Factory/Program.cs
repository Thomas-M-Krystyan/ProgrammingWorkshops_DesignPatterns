using System;
using Factory.Exercise.Factories;
using Factory.Exercise.Models;
using Factory.Exercise.Services;

namespace Factory
{
    public static class Program
    {
        public static void Main()
        {
            var shppingCart = new ShoppingCart();
            var productMilk = ProductsFactory.Creat<Milk>();
            shppingCart.AddProduct(productMilk);
            Console.WriteLine($"Product: {productMilk.GetProductName()} is in Cart now, weight is {productMilk.GetWeight()}, Price is {productMilk.GetPrice()}");
            //var productCheese = ProductsFactory.Creat<Chease>(CheaseType.Camembert);
            //shppingCart.AddProduct(productCheese);
            var productBread = ProductsFactory.Creat<Bread>();
            shppingCart.AddProduct(productBread);
            Console.WriteLine($"Product: {productBread.GetProductName()} is in Cart now, weight is {productBread.GetWeight()}, Price is {productBread.GetPrice()}");

        }
    }
}
