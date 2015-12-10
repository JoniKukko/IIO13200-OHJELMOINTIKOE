using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LetterCalculator
{
    private string phrase;
    private Dictionary<char, int> letters;
    

    public void preparePhrase(string phrase)
    {
        // otetaan lause vastaan
        this.phrase = phrase;
    }



    public bool calculate()
    {
        // aloitetaan laskemiset
        try
        {
            // luodaan kirjaimista kätevä dictionary
            this.letters = new Dictionary<char, int>();

            // käydään kirjaimet läpi
            foreach (char c in this.phrase)
            {
                // jos kirjain löytyy jo dictionarystä niin 
                // lisätään yksi
                // jos ei löydy niin lisätään kirjain
                if (this.letters.ContainsKey(c))
                    this.letters[c]++;
                else
                    this.letters.Add(c, 1);
            }

        } catch (Exception ex)
        {
            // virheellinen toiminta palauttaa falsen
            // tähän kohtaan laittaisi debuggerille tietoja
            return false;
        }
        return true;
    }



    public Dictionary<char, int> getLetters()
    {
        // palautetaan kirjaimet järjestyksessä
        // orderby vasta täällä
        return this.letters.OrderBy(key => key.Key).ToDictionary(t => t.Key, t => t.Value); ;
    }

}