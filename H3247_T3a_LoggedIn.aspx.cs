using System;
using System.Linq;
using System.Web.Configuration;
using System.Xml.Serialization;

public partial class H3247_T3a_LoggedIn : System.Web.UI.Page
{

    private T3XMLdata XMLdata {
        get { return (T3XMLdata)Session["XMLdata"]; }
        set { Session["XMLdata"] = value; }
    }
    private T3User user {
        get { return (T3User)Session["user"]; }
        set { Session["user"] = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.user == null) Response.Redirect("H3247_T3A.aspx");
        // lasketaan kaikkien harjoituksien määrä
        this.labelTotalPractices.Text = this.XMLdata.users.Sum(x => x.practices.Count).ToString();
    }


}