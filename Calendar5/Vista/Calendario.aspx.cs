using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Calendar5.Vista
{
    public partial class Calendario : System.Web.UI.Page
    {
        public string JSArray
        {
            get
            {
                return string.Format("[{0}]", string.Join(",", list));
            }
        }
        public Calendar Calend
        {
            get
            {
                return GetCalendario();
            }
        }
        public List<Calendar> list = new List<Calendar>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //var myTextboxControl = (gener)Page.FindControl("calendar1");
            

            //HtmlControl control = (HtmlControl)Page.FindControl("calendar1");

            //HtmlControl control = (HtmlControl)pnl.FindControl("calendar1");


            //const event = {
            //title: title,
            //    start: startDate || '2020-12-22T02:30:00',
            //    end: endDate || '2020-12-12T14:30:00',
            //    color: color || '#7858d7'
            //}

            //List<Calendar> list = new List<Calendar>();
            //list.Add(new Calendar("PRUEBA", "2022-05-07T02:30:00", "2022-05-07T14:30:00", "#7858d7"));
            //control.Attributes.Add("addEvent", list.ToString());

            //List<Calendar> list = new List<Calendar>();
            //list.Add(new Calendar("PRUEBA", "2022-07-15T05:30:00.000Z", "2022-07-15T05:30:00.000Z", "#7858d7"));
            //calendar1.Attributes.Add("addEvent", list.ToString());



            //HtmlInputText tb1 = this.txt;
            //Response.Write(tb1.Value);
            //string theValue = Request.Form["calendar1"].ToString();

            
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "initializeCalendar", "addEventCalendar(" + JsonConvert.SerializeObject(Calend) + ")", true);
        }
        public Calendar GetCalendario()
        {
            return new Calendar("PRUEBA", "2022-07-15T05:30:00.000Z", "2022-07-15T05:30:00.000Z", "#7858d7");
        }
    }
    public class Calendar
    {
        string title = "title";
        string start = "2020-12-22T02:30:00";
        string end = "2020-12-12T14:30:00";
        string color = "#7858d7";
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Address { get; set; }
        public Calendar(){}

        public Calendar(string title, string start, string end, string color)
        {
            this.title = title;
            this.start = start;
            this.end = end;
            this.color = color;
        }
    }
}