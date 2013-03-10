using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data.Linq;
using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.DataAccess;
using AjaxControlToolkit;
namespace RestaurantWebReservation.Application.Service
{
    /// <summary>
    /// AutoCompleteWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class AutoCompleteWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string[] LoginAutoCommplete(string prefixText, int count)
        {
            List<string> tempStrList = new List<string>();


            string[] nameArray = new string[10];

            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<login_autocompleteResult> rs = dc.login_autocomplete(prefixText);


            foreach (login_autocompleteResult r in rs)
            {
                tempStrList.Add(r.name);
            }
            int num = tempStrList.Count<string>();
            string[] final = new string[num];
            for (int i = 0; i <= num - 1; i++)
            {
                final[i] = tempStrList.ElementAt(i);
            }
            return final;
        }

        [WebMethod]
        public static AjaxControlToolkit.Slide[] GetNewsSlides()
        {
            List<News> newsList = PublicService.GetNews();
            int num = newsList.Count >= 5 ? 5 : newsList.Count;
            Slide[] slideArray = new Slide[num];
            for (int i = 0; i <= num - 1; i++)
            {
                News news = newsList.ElementAt(i);
                slideArray[i] = new Slide(news.pictPath, news.title, news.content);
            }
            return slideArray;
        }

        public string[] SearchUnfinishedReservationAutoComplete(string prefixText, int count)
        {
            List<string> tempStrList = new List<string>();


            string[] nameArray = new string[10];

            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<search_reservation_autocompleteResult> rs = dc.search_reservation_autocomplete(prefixText);


            foreach (search_reservation_autocompleteResult r in rs)
            {
                tempStrList.Add(r.customer_name);
            }
            int num = tempStrList.Count<string>();
            string[] final = new string[num];
            for (int i = 0; i <= num - 1; i++)
            {
                final[i] = tempStrList.ElementAt(i);
            }
            return final;
        }
    }
}
