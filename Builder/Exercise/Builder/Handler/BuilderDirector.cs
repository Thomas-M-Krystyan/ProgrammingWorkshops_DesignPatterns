using Builder.Exercise.Builder.Interfaces;
using Builder.Exercise.Products.Interfaces;
using System;

namespace Builder.Exercise.Builder.Handler
{
    public class BuilderDirector  // NOTE: Singleton
    {
        public IBuilder<IProduct, Enum> Builder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderDirector"/> class.
        /// </summary>
        public BuilderDirector(IBuilder<IProduct, Enum> builder)
        {
            this.Builder = builder;
        }

        public IProduct Build(Enum type)
        {
            return this.Builder != null
                ? this.Builder.Build(type)
                : default;
        }
    }
}
