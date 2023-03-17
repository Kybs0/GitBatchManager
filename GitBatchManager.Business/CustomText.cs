using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kybs0.Log;

namespace GitBatchManager.Business
{
    public static class CustomText
    {
        public static UserPath Path { get; } = new UserPath();
        public static Logger Log { get; set; }
        public static INotificationProvider Notification { get; set; } = new NotificationProvider();

        public const string ProjectName = "GitBatchManager";
    }
}
