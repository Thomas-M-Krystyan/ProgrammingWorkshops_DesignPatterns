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

        public Context(string strategyName)
        {
            SetStrategy(strategyName);
        }

        private void SetStrategy(string strategyName)
        {
            if(strategyName == "BFS")
            {
                _strategy = new BFS_Strategy();
            }
            else
            {
                _strategy = new DFS_Strategy();
            }
        }

        public TraverseResult Find(bool isLefthand, string value)
        {
            return _strategy.Find(value, isLefthand);
        }
    }
}
