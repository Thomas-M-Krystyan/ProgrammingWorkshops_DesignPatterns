using Factory.Exercise.Factories;
using Factory.Exercise.Services;
using System;
using System.Threading.Channels;

namespace Factory
{
    public static class Program
    {
        public static void Main()
        {
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
    }
}

//8.Why using Factory in "ShoppingCart" ?

//    Good, you noticed hidden dependency. There is no need to use it there, because ShoppingCart should not create new
//products.Only add an already existing ones to itself (shopping cart's internal list of IProduct-s).

//Of course, still the main requirement was to support a selected variety of products, which means, they should be
//always created => which means, we need to use Factory somewhere and create all 6 of them, so the created products
//could be used by the actual business logic. You are using for this purpose Program class and Main method which is
//good and enough in this case. :)

//However:

//-this is Abstract Factory design pattern, and your ProductsFactory concrete implementation does not have an
//abstract parent.There should be something like IFactory with method Create<T>, and your ProductsFactory should
//implement this interface. Also...
//-you should take care about clean design / resources management. There is no reason (in the current case) to have
//multiple ProductsFactories (so, also no reason to able to create many instances of them) because all of them would
//do the same. Of course, you can have multiple factories, but different factories, e.g. "UsersFactory : IFactory"
//and "ProductsFactory : IFactory".

//Do you see the possibility to implement something (hint: some design patter) which you already know to keep?

//- And, when you already create IFactory interface, then there is a clear go to use AddSingleton method from
//.NET Core => services.AddSingleton<IFactory, ProductsFactory>();
