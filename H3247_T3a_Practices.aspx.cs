using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3247_T3a_Practices : System.Web.UI.Page
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
        gridviewPractices.DataSource = this.user.practices;
        gridviewPractices.DataBind();

    }
}