using Builder.Exercise.Products.Interfaces;
using System;

namespace Builder.Exercise.Builder.Interfaces
{
    public interface IBuilder<TProduct, TEnum>
        where TProduct : IProduct
        where TEnum : Enum
    {
        TProduct Build(TEnum type);

        void ResetComponents();
    }
}
