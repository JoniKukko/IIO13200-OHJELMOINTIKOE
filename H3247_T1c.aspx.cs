using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public partial class H3247_T1c : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void buttonCalculate_Click(object sender, EventArgs e)
    {
        LetterCalculator calculator = new LetterCalculator();

        // stringin filtteröinti tehdään ennen kuin se annetaan LetterCalculatorille
        // näin ollen letterCalculator on huomattavasti monikäyttöisempi kun sillä voi
        // tarvittaessa laskea myös kaikki merkit eikä vain a-z
        string phrase = Regex.Replace(textboxString.Text, "[^a-z]", "");
        calculator.preparePhrase(phrase);

        if (calculator.calculate())
        {
            // haetaan kirjaimet ja muodostetaan niistä lista.
            List<KeyValuePair<char, int>> list = new List<KeyValuePair<char, int>>();
            list.AddRange(calculator.getLetters());

            // bindataan lista
            gridviewLetters.DataSource = list;
            gridviewLetters.DataBind();

            // kerrotaan kooste
            labelMessages.Text = "Yhteensä " + phrase.Length + " merkkiä ja " + list.Count + " eri kirjainta";

        }
        else
        {
            labelMessages.Text = "Laskeminen ei onnistunut!";
        }
    }


}