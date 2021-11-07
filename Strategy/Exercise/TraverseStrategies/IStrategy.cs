using Strategy.Exercise.Result;

namespace Strategy.Exercise.TraverseStrategies
{
    public interface IStrategy
    {
        TraverseResult Find(string value, bool isLeftHanded);
        string GetName();
    }
}
