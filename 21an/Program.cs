using System.ComponentModel.Design;
using System.Media;



//TODO lägg till komentarer
//Ändra svågighetsgrad mer
//Flera variabler?
//Skriva om reglerna
//Snyggare kod eller enklare?
//Snyggare utskiving och mera ljud
//C# forms?
//Fixa datorns dra efter spelarens dra med svårighetsgrader!

//Half Done
//Riktiga deck resetas när det är x kort kvar avnvänd en list för att hålla koll på vilka kort som inte är använda
//Riktigt blackjack på normal?

//DONE!
//S'et är värt 11 om inte poängen blir över 21 då är det värt 1





SoundPlayer Drawing_Cards = new SoundPlayer(_21an.Properties.Resources.Drawing);
SoundPlayer Drawing_Cards_4 = new SoundPlayer(_21an.Properties.Resources.Drawing4);

List<int> Cards = new List<int>();
for (int i = 1; i <= 40; i++)
{
    Cards.Add(2);
    Cards.Add(3);
    Cards.Add(4);
    Cards.Add(5);
    Cards.Add(6);
    Cards.Add(7);
    Cards.Add(8);
    Cards.Add(9);
    Cards.Add(10);
    Cards.Add(10);
    Cards.Add(10);
    Cards.Add(10);
    Cards.Add(11);
}
Random rng = new Random();
var ShuffledCards = Cards.OrderBy(a => rng.Next()).ToList();


int Svarighet = 2;
bool Avsluta = false;
String Vinnare = "ingen har vinnit än!";
while (Avsluta == false) {
    int SpelarPoang = 0;
    int DatorPoang = 0;
    int DragnaKort = 0;
    int rand = 0;
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
    if (Svarighet == 1)
    {
        Console.WriteLine("Svårighetsgrad: Lätt");
    }
    else if (Svarighet == 2)
    {
        Console.WriteLine("Svårighetsgrad: Normal");
    }
    else if (Svarighet == 3)
    {
        Console.WriteLine("Svårighetsgrad: Svår");
    }
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
            Console.WriteLine("Den senaste vinnaren är: " + Vinnare);
            Console.ReadLine();
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
            if (Svarighet == 2)
            {
                Console.WriteLine("Nu kommer två kort dras per spelare!");
                Drawing_Cards_4.Play();
                Thread.Sleep(250);
                for(int i = 1; i < 2; i++)
                {
                    rand = ShuffledCards[rnd.Next(0, ShuffledCards.Count())];
                    ShuffledCards.Remove(rand);
                    if (rand == 11 && (SpelarPoang += rand) < 21)
                    {
                        SpelarPoang += 1;
                    }
                    else
                    {
                        SpelarPoang += rand;
                    }

                    rand = ShuffledCards[rnd.Next(0, ShuffledCards.Count())];
                    ShuffledCards.Remove(rand);
                    if (rand == 11 && (DatorPoang += rand) < 21)
                    {
                        DatorPoang += 1;
                    }
                    else
                    {
                        DatorPoang += rand;
                    }
                }
                Console.WriteLine("Din poäng: " + SpelarPoang);
                Console.WriteLine("Datorns poäng: " + DatorPoang);
                DragnaKort++;
            }
            else
            {
                Console.WriteLine("Nu kommer två kort dras per spelare!");
                Drawing_Cards_4.Play();
                Thread.Sleep(250);
                SpelarPoang += rnd.Next(1, 10) + rnd.Next(1, 10);
                DatorPoang += rnd.Next(1, 10) + rnd.Next(1, 10);
                Console.WriteLine("Din poäng: " + SpelarPoang);
                Console.WriteLine("Datorns poäng: " + DatorPoang);
                DragnaKort++;
            }

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
                else if (Svarighet == 2)
                {
                    Drawing_Cards.Play();
                    Thread.Sleep(125);
                    rand = ShuffledCards[rnd.Next(0, ShuffledCards.Count())];
                    ShuffledCards.Remove(rand);
                    if (rand == 11 && (SpelarPoang += rand) < 21)
                    {
                        SpelarPoang += 1;
                    }
                    else
                    {
                        SpelarPoang += rand;
                    }
                    Console.WriteLine("Ditt nya kort är värt " + rand + " poäng");
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
                    rand = ShuffledCards[rnd.Next(0, ShuffledCards.Count())];
                    ShuffledCards.Remove(rand);
                    if (rand == 11 && (DatorPoang += rand) < 21)
                    {
                        DatorPoang += 1;
                    }
                    else
                    {
                        DatorPoang += rand;
                    }
                    Console.WriteLine("Datorn drog ett kort och har nu: " + DatorPoang + " poäng");
                }
                if (DatorPoang > SpelarPoang && DatorPoang < 21)
                {
                    Console.WriteLine("Du förlorade!");
                    Spela = false;
                    Thread.Sleep(3000);
                    break;
                }
                else if (SpelarPoang > DatorPoang && SpelarPoang < 21)
                {
                    Console.WriteLine("Du vann!");
                    Spela = false;
                    Console.WriteLine("Skriv in ditt namn: ");
                    Vinnare = Console.ReadLine();
                    break;
                }
                else if (SpelarPoang == DatorPoang)
                {
                    Console.WriteLine("Du förlorade!");
                    Spela = false;
                    Thread.Sleep(3000);
                    break;
                }
            }
        }
        //Alla olicka vinnare och förlorare
        if (SpelarPoang > 21 || DatorPoang == 21)
        {
            Console.WriteLine("Du förlorade!");
            Spela = false;
            Thread.Sleep(3000);
        }
        else if (DatorPoang > 21 || SpelarPoang == 21)
        {
            Console.WriteLine("Du vann!");
            Spela = false;
            Console.WriteLine("Skriv in ditt namn: ");
            Vinnare = Console.ReadLine();
        }
        else if (DatorPoang == SpelarPoang && DatorPoang == 21)
        {
            Console.WriteLine("Du förlorade!");
            Spela = false;
            Thread.Sleep(3000);
        }
    }
}