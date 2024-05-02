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

        public override string ToString()
        {
            return $"{Data.ToString("dd/MM/yyyy")} - {char.ToUpper(Titolo[0]) + Titolo.Substring(1)} - {char.ToUpper(Relatore[0]) + Relatore.Substring(1)} - {Prezzo.ToString("0.00")} euro";
        }
    }
}