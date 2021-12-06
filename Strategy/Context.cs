using Strategy.Exercise.Result;
using Strategy.Exercise.TraverseStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
   public class Context
    {
        private IStrategy _strategy;
        public Context(IStrategy strategyName)
        {
            SetStrategy(strategyName);
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public TraverseResult Find(bool isLefthand, string value)
        {
            return _strategy.Find(value, isLefthand);
        }
    }
}
