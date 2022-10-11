using System.Media;

int SpelarPoang = 0;
int DatorPoang = 0;
int DragnaKort = 0;
bool Spela = false;
Random rnd = new Random();

Console.WriteLine(Environment.CurrentDirectory);
SoundPlayer typewriter = new SoundPlayer();
typewriter.SoundLocation = Environment.CurrentDirectory + "/Drawing-Cards.wav";
typewriter.Play();

Console.WriteLine("Välkommen till 21an!");
Console.WriteLine("Välj ett alternativ");
Console.WriteLine("1. Spela");
Console.WriteLine("2. Visa senaste vinnaren");
Console.WriteLine("3. Spelets regler");
Console.WriteLine("4. Avsluta");
switch (Console.ReadLine())
{
    case "1":
        Console.WriteLine();
        Console.WriteLine("Du valde att spela");
        Spela = true;
        break;
    case "2":
        Console.WriteLine("Du valde att visa senaste vinnaren");
        break;
    case "3":
        Console.WriteLine("Du valde att visa spelets regler");
        Console.WriteLine("I 21:an kommer du att spela mot datorn och försöka tvinga datorn att få över 21 poäng. Både du och datorn får poäng genom att dra kort, varje kort är värt 1 – 10 poäng. När spelet börjar dras två kort till både dig och datorn. Därefter får du dra hur många kort som du vill tills du är nöjd med din totalpoäng, du vill komma så nära 21 som möjligt utan att få mer än 21 poäng. När du inte vill dra fler kort så kommer datorn att dra kort tills den har mer eller lika många poäng som dig.\r\n\r\nDu vinner om datorn får mer än totalt 21 poäng när den håller på att dra kort. Datorn vinner om den har mer poäng än dig när spelet är slut så länge som datorn inte har mer än 21 poäng. Om det skulle bli lika i poäng så vinner datorn. Om du får mer än 21 poäng när du drar kort så har du förlorat.");
        break;
    case "4":
        Console.WriteLine("Du valde att avsluta");
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
        if (Dra == "j" && SpelarPoang < 21)
        {
            int Slump = rnd.Next(1, 10);
            SpelarPoang += Slump;
            Console.WriteLine("Ditt nya kort är värt " + Slump + " poäng");
            Console.WriteLine("Din poäng: " + SpelarPoang);
            Console.WriteLine("Datorns poäng: " + DatorPoang);
        }
        else if (Dra == "n")
        {
            while (DatorPoang < SpelarPoang)
            {
                DatorPoang += rnd.Next(1, 10);
                Console.WriteLine("Datorn drog ett kort och har nu: " + DatorPoang + " poäng");
            }
            Spela = false;
        }
    }
    if (SpelarPoang > 21 || DatorPoang == 21)
    {
        Console.WriteLine("Du förlorade!");
        Spela = false;
    }
    if (DatorPoang > 21 || SpelarPoang == 21)
    {
        Console.WriteLine("Du vann!");
        Spela = false;
    }
}


