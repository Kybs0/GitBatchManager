using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3C.Log;

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
