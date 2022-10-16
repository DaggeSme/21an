using System.Media;



//TODO lägg till komentarer
//Ändra svågighetsgrad mer
//Flera variabler?
//Skriva om reglerna
//Riktigt blackjack på normal?
//Snyggare kod eller enklare?
//Snyggare utskiving och mera ljud
//Riktiga deck resetas när det är x kort kvar avnvänd en list för att hålla koll på vilka kort som inte är använda
//S'et är värt 11 om inte poängen blir över 21 då är det värt 1
//C# forms?



//SoundPlayer Drawing_Cards = new SoundPlayer(_21an.Properties.Resources.Drawing);
//SoundPlayer Drawing_Cards_4 = new SoundPlayer(_21an.Properties.Resources.Drawing4);

SoundPlayer Drawing_Cards_4 = new SoundPlayer();
Drawing_Cards_4.SoundLocation = Environment.CurrentDirectory + "/Drawing-Cards-4.wav";
SoundPlayer Drawing_Cards = new SoundPlayer();
Drawing_Cards.SoundLocation = Environment.CurrentDirectory + "/Drawing-Cards.wav";

int Svarighet = 2;
bool Avsluta = false;

while (Avsluta == false) {
    int SpelarPoang = 0;
    int DatorPoang = 0;
    int DragnaKort = 0;
    int SpelarTur = 1;
    int DatorTur = 1;
    
    bool Spela = false;
    Random rnd = new Random();
    Console.Clear();
    Console.WriteLine("Välkommen till 21an!");
    Console.WriteLine("Välj ett alternativ");
    Console.WriteLine("1. Spela");
    Console.WriteLine("2. Svårighets grad");
    Console.WriteLine("3. Visa senaste vinnaren");
    Console.WriteLine("4. Spelets regler");
    Console.WriteLine("5. Avsluta");
    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine();
            Console.WriteLine("Du valde att spela");
            Spela = true;
            break;
        case "2":
            Console.WriteLine("Välj mellan svårighets graderna: ");
            Console.WriteLine("1. Lätt");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Svår");
            
            Svarighet = Int32.Parse(Console.ReadLine());
            break;
        case "3":
            Console.WriteLine("Du valde att visa senaste vinnaren");
            break;
        case "4":
            Console.WriteLine("Du valde att visa spelets regler");
            Console.WriteLine("I 21:an kommer du att spela mot datorn och försöka tvinga datorn att få över 21 poäng. Både du och datorn får poäng genom att dra kort, varje kort är värt 1 – 10 poäng. När spelet börjar dras två kort till både dig och datorn. Därefter får du dra hur många kort som du vill tills du är nöjd med din totalpoäng, du vill komma så nära 21 som möjligt utan att få mer än 21 poäng. När du inte vill dra fler kort så kommer datorn att dra kort tills den har mer eller lika många poäng som dig.\r\n\r\nDu vinner om datorn får mer än totalt 21 poäng när den håller på att dra kort. Datorn vinner om den har mer poäng än dig när spelet är slut så länge som datorn inte har mer än 21 poäng. Om det skulle bli lika i poäng så vinner datorn. Om du får mer än 21 poäng när du drar kort så har du förlorat.");
            break;
        case "5":
            Console.WriteLine("Du valde att avsluta");
            Avsluta = true;
            break;
        default:
            Console.WriteLine("Du valde ett ogiltigt alternativ");
            break;
    }

    while (Spela == true)
    {
        if (DragnaKort == 0)
        {
            //kod som körs första gången spelest spelas

            Console.WriteLine("Nu kommer två kort dras per spelare!");
            Drawing_Cards_4.Play();
            Thread.Sleep(250);
            SpelarPoang += rnd.Next(1, 10) + rnd.Next(1, 10);
            DatorPoang += rnd.Next(1, 10) + rnd.Next(1, 10);
            Console.WriteLine("Din poäng: " + SpelarPoang);
            Console.WriteLine("Datorns poäng: " + DatorPoang);
            DragnaKort++;
        }
        else
        {
            //kod som körs alla andra gånger efter första
            Console.WriteLine("Vill du dra ett till kort? (j/n)");
            String Dra = Console.ReadLine();
            while (Dra == "j" && SpelarPoang < 21)
            {
                if (SpelarPoang >= 17 && Svarighet == 1)
                {
                    Drawing_Cards.Play();
                    Thread.Sleep(125);
                    int Slump = rnd.Next(1, 5);
                    SpelarPoang += Slump;
                    Console.WriteLine("Ditt nya kort är värt " + Slump + " poäng");
                    Console.WriteLine("Din poäng: " + SpelarPoang);
                    Console.WriteLine("Datorns poäng: " + DatorPoang);
                }
                else if (SpelarPoang >= 17 && Svarighet == 3)
                {
                    Drawing_Cards.Play();
                    Thread.Sleep(125);
                    int Slump = rnd.Next(3, 10);
                    SpelarPoang += Slump;
                    Console.WriteLine("Ditt nya kort är värt " + Slump + " poäng");
                    Console.WriteLine("Din poäng: " + SpelarPoang);
                    Console.WriteLine("Datorns poäng: " + DatorPoang);
                }
                else
                {
                    Drawing_Cards.Play();
                    Thread.Sleep(125);
                    int Slump = rnd.Next(1, 10);
                    SpelarPoang += Slump;
                    Console.WriteLine("Ditt nya kort är värt " + Slump + " poäng");
                    Console.WriteLine("Din poäng: " + SpelarPoang);
                    Console.WriteLine("Datorns poäng: " + DatorPoang);
                }
                if (SpelarPoang < 21)
                {
                    Console.WriteLine("Vill du dra ett till kort? (j/n)");
                    Dra = Console.ReadLine();
                }
                

            }
            if (Dra == "n")
            {
                while (DatorPoang < 19 && DatorPoang < SpelarPoang)
                {
                        DatorPoang += rnd.Next(1, 10);
                        Console.WriteLine("Datorn drog ett kort och har nu: " + DatorPoang + " poäng");
                }
                if (DatorPoang > SpelarPoang && DatorPoang < 21)
                {
                    Console.WriteLine("Du förlorade!");
                    Spela = false;
                    Thread.Sleep(5000);
                    break;
                }
                else if (SpelarPoang > DatorPoang && SpelarPoang < 21)
                {
                    Console.WriteLine("Du vann!");
                    Spela = false;
                    Thread.Sleep(5000);
                    break;
                }
                else if (SpelarPoang == DatorPoang)
                {
                    Console.WriteLine("Du förlorade!");
                    Spela = false;
                    Thread.Sleep(5000);
                    break;
                }
            }
        }
        //Alla olicka vinnare och förlorare
        if (SpelarPoang > 21 || DatorPoang == 21)
        {
            Console.WriteLine("Du förlorade!");
            Spela = false;
            Thread.Sleep(5000);
        }
        else if (DatorPoang > 21 || SpelarPoang == 21)
        {
            Console.WriteLine("Du vann!");
            Spela = false;
            Thread.Sleep(5000);
        }
        else if (DatorPoang == SpelarPoang && DatorPoang == 21)
        {
            Console.WriteLine("Du förlorade!");
            Spela = false;
            Thread.Sleep(5000);
        }
    }
}