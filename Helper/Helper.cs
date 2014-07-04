using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.ApplicationModel.Background;

namespace Vapps
{
    public sealed class Helper
    {
        // RegisterBackgroundTask()
        // referenece : http://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj553413.aspx
        public static BackgroundTaskRegistration RegisterBackgroundTask(
                                                string taskEntryPoint,
                                                string name,
                                                IBackgroundTrigger trigger,
                                                IBackgroundCondition condition)
        {
            //
            // Check for existing registrations of this background task.
            //
            //

            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {

                if (cur.Value.Name == name)
                {
                    // 
                    // The task is already registered.
                    // 


                    return (BackgroundTaskRegistration)(cur.Value);
                }
            }

            // Register the background task.

            var builder = new BackgroundTaskBuilder();

            builder.Name = name;
            builder.TaskEntryPoint = taskEntryPoint;
            builder.SetTrigger(trigger);

            if (condition != null)
            {
                builder.AddCondition(condition);
            }

            BackgroundTaskRegistration task = builder.Register();

            return task;

        }
    }
}
