using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3247_T3a_AddNew : System.Web.UI.Page
{
    private T3XMLdata XMLdata
    {
        get { return (T3XMLdata)Session["XMLdata"]; }
        set { Session["XMLdata"] = value; }
    }
    private T3User user
    {
        get { return (T3User)Session["user"]; }
        set { Session["user"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.user == null) Response.Redirect("H3247_T3A.aspx");
        this.textboxName.Text = this.user.username;
    }


    protected void buttonSave_Click(object sender, EventArgs e)
    {

        // haetaan formin tiedot ja tallennetaan se sekä instanssimuuttujaan
        // ja xml tiedostoon
        try {
            IFormatProvider culture = new System.Globalization.CultureInfo("fi-FI", true);

            T3Practice newPractice = new T3Practice();

            string username = textboxName.Text.ToString();
            newPractice.starttime = DateTime.ParseExact(textboxDate.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);

            double tempDouble;
            double.TryParse(textboxHours.Text.ToString(), out tempDouble);
            newPractice.endtime = newPractice.starttime.AddHours(tempDouble);
            double.TryParse(textboxMinutes.Text.ToString(), out tempDouble);
            newPractice.endtime = newPractice.endtime.AddHours(tempDouble);

            int tempInt;
            int.TryParse(textboxKilometers.Text.ToString(), out tempInt);
            newPractice.travel = tempInt;

            var useri = this.XMLdata.users.Where(x => x.username == username).SingleOrDefault();
            useri.practices.Add(newPractice);


            var XMLwriter = new System.Xml.Serialization.XmlSerializer(typeof(T3XMLdata));

            string path = Server.MapPath(WebConfigurationManager.AppSettings["T3filePath"]);
            System.IO.FileStream file = System.IO.File.Create(path);

            XMLwriter.Serialize(file, this.XMLdata);
            file.Close();
        } catch (Exception ex)
        {

        }

    }
}