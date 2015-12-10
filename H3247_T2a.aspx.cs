using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class H3247_T2a : System.Web.UI.Page
{

    private DataSet dataset {
        get { return (DataSet)Session["dataset"]; }
        set { Session["dataset"] = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        // parsitaan ja lasketaan laskut vain kerran
        if (!this.IsPostBack && this.loadXML())
        {
            // tänne tullaan vain jos ei ole postback ja loadxml onnistuu
            this.gridCalculations();
        }

    }
    

    private bool loadXML()
    {
        try
        {
            // ei parsita dataa kuitenkaan turhaan eli
            // vain silloin kun sitä ei sessionissa ole
            if (this.dataset == null)
            {
                this.dataset = new DataSet();
                this.dataset.ReadXml(Server.MapPath(WebConfigurationManager.AppSettings["T2FilePath"]));
            }

            // bindataan tauluun
            gridviewWorkers.DataSource = this.dataset;
            gridviewWorkers.DataBind();

        }
        catch (Exception ex)
        {
            // poikkeuksesta ilmoitetaan käyttäjälle
            labelMessages.Text = "Virhe ladattaessa tiedostoa!";
            return false;
        }
        return true;
    }



    private bool filterXML(string filterBy)
    {
        // taulun filtteröinti
        try
        {
            // luodaan uusi datasetti
            // ja haetaan siihen vain vanhan datasetin sisällöstä
            // ne mitä pyydettiin
            DataSet newdataset = new DataSet();
            newdataset.Merge(this.dataset.Tables[0].Select("tyosuhde = '"+ filterBy + "'"));

            // ja bindataan tauluun
            gridviewWorkers.DataSource = newdataset;
            gridviewWorkers.DataBind();

        }
        catch (Exception ex)
        {
            // poikkeuksesta ilmoitetaan käyttäjälle
            labelMessages.Text = "Virhe filtteröitäessä! " + ex.Message;
            return false;
        }
        return true;
    }




    private bool gridCalculations()
    {
        // lasketaan dataa
        try
        {
            // vaihdetaan teksti
            labelMessages.Text 
                = "<strong>Työntekijät</strong><br>"
                + "Kaikki: " + this.calculateByTyosuhde(null).ToString() + "<br>"
                + "Vakituiset: " + this.calculateByTyosuhde("vakituinen").ToString() + "<br>"
                + "Määräaikaiset: " + this.calculateByTyosuhde("määräaikainen").ToString() + "<br>"
                + "Muut: " + this.calculateByTyosuhde("vierailija").ToString() + "<br><br>"
                + "<strong>Palkat</strong><br>"
                + "Kaikki: " + this.calcuteByPalkka(null).ToString() + "<br>"
                + "Vakituiset: " + this.calcuteByPalkka("vakituinen").ToString() + "<br>"
                + "Määräaikaiset: " + this.calcuteByPalkka("määräaikainen").ToString() + "<br>"
                + "Muut: " + this.calcuteByPalkka("vierailija").ToString();

        }
        catch (Exception ex)
        {
            // napataan virheet yhtenäisesti täällä
            labelMessages.Text = "Laskut epäonnistuivat!";
            return false;
        }
        return true;
    }



    private int calculateByTyosuhde(string tyosuhde)
    {
        // lasketaan työsuhteiden määrät
        var table = this.dataset.Tables[0].AsEnumerable();
        // jos ei ole annettua nullia niin haetaan työsuhteen mukaan (where..)
        // jos nulli on annettu niin lasketaan kaikki työsuhteet yhteen
        return (tyosuhde != null)
            ? table.Where(x => x["tyosuhde"].ToString() == tyosuhde).ToList().Count
            : table.Count();
    }



    private int calcuteByPalkka(string tyosuhde)
    {
        // lasketaan palkka
        var table = this.dataset.Tables[0].AsEnumerable();
        // jos ei ole annettua nullia niin haetaan työsuhteen mukaan (where...)
        // jos null niin sitten lasketaan kaikkien palkat
        return (tyosuhde != null)
            ? table.Where(x => x["tyosuhde"].ToString() == tyosuhde).Sum(x => int.Parse(x.Field<string>("palkka")))
            : table.Sum(x => int.Parse(x.Field<string>("palkka")));
    }



    protected void filterVakituset_Click(object sender, EventArgs e)
    {
        this.filterXML("vakituinen");
    }

    protected void filterMaaraaikaiset_Click(object sender, EventArgs e)
    {
        this.filterXML("määräaikainen");
    }

    protected void filterMuut_Click(object sender, EventArgs e)
    {
        this.filterXML("vierailija");
    }
}