using System;

public partial class T3LoggedIn : System.Web.UI.MasterPage
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
        this.labelUsername.Text = this.user.username;
    }
    


    protected void buttonLogout_Click(object sender, EventArgs e)
    {
        this.user = null;
        this.XMLdata = null;
        Response.Redirect("H3247_T3A.aspx");
    }
}
