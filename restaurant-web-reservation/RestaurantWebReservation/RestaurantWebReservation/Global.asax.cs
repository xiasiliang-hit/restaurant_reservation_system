using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using RestaurantWebReservation.Application.Service;
using RestaurantWebReservation.Application.BasicDataStractrue;


namespace RestaurantWebReservation
{
    public class Global : System.Web.HttpApplication
    {
        DateTime now = new DateTime();
        System.Timers.Timer myTimer = new System.Timers.Timer();

        void Application_Start(object sender, EventArgs e)
        {
            Restaurant.InitAllDish();
            Restaurant.InitAllTable();

            //int nextMinute = 59 - now.Minute;
            //int nextSecond = 60 - now.Second;
            //int nextMillisecond = 1000 - now.Millisecond;
            //int nextInterval = nextMillisecond + nextSecond * 1000 + nextMinute * 60 * 1000;
            
            //myTimer.Interval = nextInterval; 
            //myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            //myTimer.Start();

            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            //CheckService.CheckTableReserved();
            //CheckService.CheckTableTimeOut();
            //CheckService.CheckDeliveryTimeOut();

            //now = new DateTime();
            //int nextMinute = 59 - now.Minute;
            //int nextSecond = 60 - now.Second;
            //int nextMillisecond = 1000 - now.Millisecond;
            //myTimer.Interval = nextMillisecond + nextSecond * 1000 + nextMinute * 60 * 1000;
            //myTimer.Start();
        }
    }
}
