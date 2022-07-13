using Builder.Exercise.Builder.Interfaces;
using Builder.Exercise.Products.Interfaces;
using System;

namespace Builder.Exercise.Builder.Handler
{
    public class BuilderDirector  // NOTE: Singleton
    {
        public IBuilder<IProduct,Enum> Builder { get; set; }

        public BuilderDirector(IBuilder<IProduct,Enum> builder) { Builder = builder; }  
        public IProduct Build(Enum type)
        {
            return Builder.Build(type); 
        }
    }
}
