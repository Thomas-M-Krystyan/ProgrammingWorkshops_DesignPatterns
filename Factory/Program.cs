using Factory.Exercise.Factories;
using Factory.Exercise.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Factory
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            var wishList = new Wishlist();
            var productMilk = FoodFactory.CreateFoodProduct(Foodtype.Milk, "Low-Fat");
            var productcheese = FoodFactory.CreateFoodProduct(Foodtype.Chease, "Gouda");
            var productBread = FoodFactory.CreateFoodProduct(Foodtype.Bread, "Toast");
            wishList.AddProduct(productMilk);
            wishList.AddProduct(productBread);
            wishList.AddProduct(productcheese);

            Console.WriteLine("---------------Welcome to Penny-------------------------------------------------");
            var shppingCart = new ShoppingCart();
            shppingCart.AddProduct(productMilk);
            Console.WriteLine($"Product: {productMilk.GetName()} is in Cart now, weight is {productMilk.GetWeight()}, Price is {productMilk.GetPrice()}");
            shppingCart.AddProduct(productcheese);
            Console.WriteLine($"Product: {productcheese.GetName()} is in Cart now, weight is {productcheese.GetWeight()}, Price is {productcheese.GetPrice()}");
            shppingCart.AddProduct(productBread);
            Console.WriteLine($"Product: {productBread.GetName()} is in Cart now, weight is {productBread.GetWeight()}, Price is {productBread.GetPrice()}");
        }
        private static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
        }
    }
}
