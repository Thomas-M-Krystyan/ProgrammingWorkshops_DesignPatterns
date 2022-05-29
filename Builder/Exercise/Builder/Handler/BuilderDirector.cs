using Builder.Exercise.Builder.Interfaces;
using Builder.Exercise.Products.Interfaces;
using System;

namespace Builder.Exercise.Builder.Handler
{
    public class BuilderDirector  // NOTE: Singleton
    {
        public IProduct Build(Enum type)
        {
            throw new NotImplementedException();
        }
    }
}
