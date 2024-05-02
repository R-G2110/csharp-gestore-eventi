using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        public string TitoloProgramma { get; private set; }
        public List<Evento> Eventi { get; private set; }

        public ProgrammaEventi(string titoloProgramma)
        {
            TitoloProgramma = titoloProgramma;
            Eventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento evento)
        {
            Eventi.Add(evento);
        }

        public List<Evento> TrovaEventiPerData(DateTime data)
        {
            return Eventi.Where(e => e.Data.Date == data.Date).ToList();
        }

        public static string StampaEventi(List<Evento> eventi)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var evento in eventi)
            {
                sb.AppendLine($"         {evento}");
            }
            return sb.ToString();
        }

        public int ContaEventi()
        {
            return Eventi.Count;
        }

        public void SvuotaEventi()
        {
            Eventi.Clear();
        }

        public override string ToString()
        {
            string titoloProgrammaCapitalized = char.ToUpper(TitoloProgramma[0]) + TitoloProgramma.Substring(1);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\n{titoloProgrammaCapitalized}");
            return sb.ToString();
        }

    }


}
