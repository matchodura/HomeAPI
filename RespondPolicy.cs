using System;

namespace HomeAPI.Helpers
{
    public class RespondPolicy

    public static bool TrackFunction(TimeSpan timeSpan, Action codeBlock)
    {
        try
        {
            Task task = Task.Factory.StartNew(() => codeBlock());
            task.Wait(timeSpan);

            return task.IsCompleted;
        }
        catch (AggregateException ae)
        {
            throw ae.InnerExceptions[0];
        }
    }
}




