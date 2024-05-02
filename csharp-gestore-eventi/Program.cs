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

            int numeroEventi;
            bool inputValido = false;
            while (!inputValido)
            {
                Console.Write("Indica il numero di eventi da inserire: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out numeroEventi))
                {
                    inputValido = true;
                    for (int i = 0; i < numeroEventi; i++)
                    {
                        try
                        {
                            Console.Write($"\nInserisci il titolo del {i + 1}° evento: ");
                            string titolo = Console.ReadLine().Trim();

                            Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                            DateTime data;
                            while (!DateTime.TryParse(Console.ReadLine(), out data))
                            {
                                Console.Write("\nAttenzione!!! Formato data non valido, inserisci la data nel formato gg/mm/yyyy: ");
                            }

                            Console.Write("Inserisci la capienza massima dell'evento: ");
                            int capienza;
                            while (!int.TryParse(Console.ReadLine(), out capienza))
                            {
                                Console.Write("\nAttenzione!!! Dato inserito non valido, inserisci numero intero: ");
                            }

                            Evento nuovoEvento = new Evento(titolo, data, capienza);
                            programmaEventi.AggiungiEvento(nuovoEvento);
                            Console.WriteLine("Evento aggiunto con successo!");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine($"Attenzione!!! {e.Message}");
                            i--;
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine($"Attenzione!!! {e.Message}");
                            i--;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nAttenzione!! Dato incorretto, inserisci un numero valido.");
                }
            }

            Console.WriteLine($"\nIl numero di eventi nel programma è: {programmaEventi.ContaEventi()}");
            Console.WriteLine("Ecco il tuo programma eventi:");
            Console.WriteLine(programmaEventi);
            Console.Write(ProgrammaEventi.StampaEventi(programmaEventi.Eventi));

            Console.Write("\nInserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
            DateTime dataSpecificata;
            while (!DateTime.TryParse(Console.ReadLine(), out dataSpecificata))
            {
                Console.Write("\nAttenzione!!! Formato data non valido, inserisci la data nel formato gg/mm/yyyy: ");
            }
            var eventiInData = programmaEventi.TrovaEventiPerData(dataSpecificata);
            Console.Write(ProgrammaEventi.StampaEventi(eventiInData));

            Console.WriteLine("\n----- BONUS -----");
            Console.WriteLine("\nAggiungiamo anche una conferenza!");

            try
            {
                Console.Write("Inserisci il nome della conferenza: ");
                string titoloConferenza = Console.ReadLine().Trim();

                Console.Write("Inserisci la data della conferenza (gg/mm/yyyy): ");
                DateTime dataConferenza;
                while (!DateTime.TryParse(Console.ReadLine(), out dataConferenza))
                {
                    Console.Write("\nAttenzione!!! Formato data non valido, inserisci la data nel formato gg/mm/yyyy: ");
                }

                Console.Write("Inserisci il numero di posti per la conferenza: ");
                int capienzaConferenza;
                while (!int.TryParse(Console.ReadLine(), out capienzaConferenza))
                {
                    Console.Write("\nAttenzione!!! Dato inserito non valido, inserisci numero intero: ");
                }

                Console.Write("Inserisci il relatore della conferenza: ");
                string relatore = Console.ReadLine().Trim();

                Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
                double prezzo;
                while (!double.TryParse(Console.ReadLine(), out prezzo))
                {
                    Console.Write("\nAttenzione!!! Dato inserito non valido, inserisci un prezzo valido: ");
                }

                Conferenza nuovaConferenza = new Conferenza(titoloConferenza, dataConferenza, capienzaConferenza, relatore, prezzo);
                programmaEventi.AggiungiEvento(nuovaConferenza);
                Console.WriteLine("Conferenza aggiunta con successo!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Attenzione!!! {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Attenzione!!! {e.Message}");
            }

            Console.WriteLine("\nEcco il tuo programma eventi con anche le Conferenze: ");
            Console.WriteLine(ProgrammaEventi.StampaEventi(programmaEventi.Eventi));

            programmaEventi.SvuotaEventi();
            Console.WriteLine("Tutti gli eventi sono stati rimossi.");
        }
    }
}
