using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{

    public class Evento
    {
        public string Titolo { get; set; }
        public DateTime Data { get; set; }
        private int capienzaMax;
        private int postiPrenotati;

        public int CapienzaMax { get => capienzaMax; }
        public int PostiPrenotati { get => postiPrenotati; }

        public Evento(string titolo, DateTime data, int capienza)
        {
            SetTitolo(titolo);
            SetData(data);
            SetCapienzaMax(capienza);
            postiPrenotati = 0;
        }

        public void SetTitolo(string titolo)
        {
            if (string.IsNullOrWhiteSpace(titolo))
                throw new ArgumentException("Il titolo non può essere vuoto.");
            Titolo = titolo;
        }

        public void SetData(DateTime data)
        {
            if (data < DateTime.Now.Date)
                throw new ArgumentException("La data dell'evento non può essere nel passato.");
            Data = data;
        }

        private void SetCapienzaMax(int capienza)
        {
            if (capienza <= 0)
                throw new ArgumentException("La capienza massima deve essere maggiore di zero.");
            capienzaMax = capienza;
        }

        public void PrenotaPosti(int posti)
        {
            if (Data < DateTime.Now.Date)
                throw new InvalidOperationException("Non è possibile prenotare posti per un evento passato.");
            if (postiPrenotati + posti > capienzaMax)
                throw new InvalidOperationException("Non ci sono abbastanza posti disponibili.");
            postiPrenotati += posti;
        }

        public void DisdiciPosti(int posti)
        {
            if (Data < DateTime.Now.Date)
                throw new InvalidOperationException("Non è possibile disdire posti per un evento passato.");
            if (posti > postiPrenotati)
                throw new InvalidOperationException("Non ci sono abbastanza posti prenotati da disdire.");
            postiPrenotati -= posti;
        }

        public override string ToString()
        {
            string titoloCapitalized = char.ToUpper(Titolo[0]) + Titolo.Substring(1);
            return Data.ToString("dd/MM/yyyy") + " - " + titoloCapitalized;
        }

    }


}
