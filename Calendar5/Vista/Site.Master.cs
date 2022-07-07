using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calendar5.Vista
{
    public partial class Site : System.Web.UI.MasterPage
    {
        //public Calendar Calend
        //{
        //    get
        //    {
        //        return GetCalendario();
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void Page_PreRender(object sender, EventArgs e)
        //{

        //    //FiltrarListaSimpleCita(new CitaSimple.Criterio(CManejoSesion.CUsuario.CEmpresa.UIDEmpresa, Guid.Empty, CModulo.UIDModulo, TxtFolio.Text, uidssucursal, uidsespecialidad, uidsconsultorio, uidsturno, uidsdoctores, Guid.Empty, fecha1, fecha2, TxtNombres.Text, TxtPrimerApe.Text, TxtSegundoApe.Text, uidstipocita, uidsstatus, int.MinValue, int.MinValue, false, false));
        //    //FiltrarListaSimpleCita(new CitaSimple.Criterio(new Guid("ed0ff78d-f09d-41f1-8a75-80204feddf18"), Guid.Empty, new Guid("7dc31f3d-eb64-47cd-9056-3b926ec4a549"), "", "", "", "", "", "", Guid.Empty, DateTime.MinValue, DateTime.MinValue, "", "", "", "", "", int.MinValue, int.MinValue, false, false));
        //    //ScriptManager.RegisterStartupScript(this, typeof(Page), "initializeCalendar", "addEventCalendar(" + JsonConvert.SerializeObject(Calend) + ")", true);
        //    //Register script if you are using ScriptManager
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "JSScript", "addEventCalendar(" + JsonConvert.SerializeObject(Calend) + ");", true);
        //}
        //public Calendar GetCalendario()
        //{
        //    return new Calendar("PRUEBA", "2022-07-15T05:30:00.000Z", "2022-07-15T05:30:00.000Z", "#7858d7");
        //}
    }
}