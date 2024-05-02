namespace csharp_gestore_eventi
{
    public class Evento
    {
        public string Titolo { get; private set; }
        public DateTime Data { get; private set; }
        public int CapienzaMax { get; private set; }
        public int PostiPrenotati { get; private set; }

        public Evento(string titolo, DateTime data, int capienza)
        {
            SetTitolo(titolo);
            SetData(data);
            SetCapienzaMax(capienza);
            PostiPrenotati = 0;
        }

        private void SetTitolo(string titolo)
        {
            if (string.IsNullOrWhiteSpace(titolo))
                throw new ArgumentException("Il titolo non può essere vuoto.");
            Titolo = titolo;
        }

        private void SetData(DateTime data)
        {
            if (data < DateTime.Now.Date)
                throw new ArgumentException("La data dell'evento non può essere nel passato.");
            Data = data;
        }

        private void SetCapienzaMax(int capienza)
        {
            if (capienza <= 0)
                throw new ArgumentException("La capienza massima deve essere maggiore di zero.");
            CapienzaMax = capienza;
        }

        public void PrenotaPosti(int posti)
        {
            if (Data < DateTime.Now.Date)
                throw new InvalidOperationException("Non è possibile prenotare posti per un evento passato.");
            if (PostiPrenotati + posti > CapienzaMax)
                throw new InvalidOperationException("Non ci sono abbastanza posti disponibili.");
            PostiPrenotati += posti;
        }

        public void DisdiciPosti(int posti)
        {
            if (Data < DateTime.Now.Date)
                throw new InvalidOperationException("Non è possibile disdire posti per un evento passato.");
            if (posti > PostiPrenotati)
                throw new InvalidOperationException("Non ci sono abbastanza posti prenotati da disdire.");
            PostiPrenotati -= posti;
        }

        public override string ToString()
        {
            return $"{Data.ToString("dd/MM/yyyy")} - {char.ToUpper(Titolo[0]) + Titolo.Substring(1)}";
        }
    }


}