using System.Collections.Generic;

namespace CSharpIntermediate.ExercisesWorkFlowEngine
{
    public interface IWorkflow
    {
        void AddActivity(IActivity activity);
        void RemoveActivity(IActivity activity);
        IEnumerable<IActivity> GetActivities();
    }
}