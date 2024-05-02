using System;

namespace csharp_gestore_eventi
{
    public class Conferenza : Evento
    {
        public string Relatore { get; set; }
        public double Prezzo { get; set; }

        public Conferenza(string titolo, DateTime data, int capienza, string relatore, double prezzo)
            : base(titolo, data, capienza)
        {
            Relatore = relatore;
            Prezzo = prezzo;
        }

        public string GetDataOraFormattata()
        {
            return Data.ToString("dd/MM/yyyy");
        }

        public string GetPrezzoFormattato()
        {
            return Prezzo.ToString("0.00") + " euro";
        }

        public override string ToString()
        {
            string titoloCapitalized = char.ToUpper(Titolo[0]) + Titolo.Substring(1);
            string relatoreCapitalized = char.ToUpper(Relatore[0]) + Relatore.Substring(1);
            return $"{GetDataOraFormattata()} - {titoloCapitalized} - {relatoreCapitalized} - {GetPrezzoFormattato()}";
        }
    }
}
