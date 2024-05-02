using System;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il nome del tuo programma Eventi: ");
            string titoloProgramma = Console.ReadLine().Trim();
            ProgrammaEventi programmaEventi = new ProgrammaEventi(titoloProgramma);

            Console.Write("Indica il numero di eventi da inserire: ");
            int numeroEventi = int.Parse(Console.ReadLine());

            for (int i = 0; i < numeroEventi; i++)
            {
                try
                {
                    Console.Write($"\nInserisci il titolo del {i + 1}° evento: ");
                    string titolo = Console.ReadLine().Trim();

                    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                    DateTime data = DateTime.Parse(Console.ReadLine());

                    Console.Write("Inserisci la capienza massima dell'evento: ");
                    int capienza = int.Parse(Console.ReadLine());

                    Evento nuovoEvento = new Evento(titolo, data, capienza);
                    programmaEventi.AggiungiEvento(nuovoEvento);
                    Console.WriteLine("Evento aggiunto con successo!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Errore: {e.Message}");
                    i--;
                }
            }

            Console.WriteLine($"\nIl numero di eventi nel programma è: {programmaEventi.ContaEventi()}");
            Console.WriteLine("Ecco il tuo programma eventi:");
            Console.Write(programmaEventi);
            Console.Write(ProgrammaEventi.StampaEventi(programmaEventi.Eventi));

            Console.Write("\nInserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
            DateTime dataSpecificata = DateTime.Parse(Console.ReadLine());
            var eventiInData = programmaEventi.TrovaEventiPerData(dataSpecificata);
            Console.Write(ProgrammaEventi.StampaEventi(eventiInData));

            Console.WriteLine("\n----- BONUS -----");
            Console.WriteLine("\nAggiungiamo anche una conferenza!");

            try
            {
                Console.Write("Inserisci il nome della conferenza: ");
                string titoloConferenza = Console.ReadLine().Trim();

                Console.Write("Inserisci la data della conferenza (gg/mm/yyyy): ");
                DateTime dataConferenza = DateTime.Parse(Console.ReadLine());

                Console.Write("Inserisci il numero di posti per la conferenza: ");
                int capienzaConferenza = int.Parse(Console.ReadLine());

                Console.Write("Inserisci il relatore della conferenza: ");
                string relatore = Console.ReadLine().Trim();

                Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
                double prezzo = double.Parse(Console.ReadLine());

                Conferenza nuovaConferenza = new Conferenza(titoloConferenza, dataConferenza, capienzaConferenza, relatore, prezzo);
                programmaEventi.AggiungiEvento(nuovaConferenza);
                Console.WriteLine("Conferenza aggiunta con successo!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errore: {e.Message}");
            }

            Console.WriteLine("\nEcco la lista completa degli eventi:");
            Console.WriteLine(ProgrammaEventi.StampaEventi(programmaEventi.Eventi));

            programmaEventi.SvuotaEventi();
            Console.WriteLine("Tutti gli eventi sono stati rimossi.");
        }
    }
}
