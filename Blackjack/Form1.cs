using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        int Rand = 0;
        int PlayerDrawnCards = 1;
        List<Card> Deck = new List<Card>();
        Random rng = new Random();
        public Form1()
        {
            InitializeComponent();

            //Get the card deck from the resource file and add it to the deck list with a value
            ResourceSet resourceSet =
                Properties.Resource1.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                switch (entry.Key.ToString())
                {
                    case string a when a.Contains("2"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 2 });
                        break;
                    case string a when a.Contains("3"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 3 });
                        break;
                    case string a when a.Contains("4"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 4 });
                        break;
                    case string a when a.Contains("5"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 5 });
                        break;
                    case string a when a.Contains("6"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 6 });
                        break;
                    case string a when a.Contains("7"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 7 });
                        break;
                    case string a when a.Contains("8"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 8 });
                        break;
                    case string a when a.Contains("9"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 9 });
                        break;
                    case string a when a.Contains("10"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 10 });
                        break;
                    case string a when a.Contains("jack"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 10 });
                        break;
                    case string a when a.Contains("queen"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 10 });
                        break;
                    case string a when a.Contains("king"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 10 });
                        break;
                    case string a when a.Contains("ace"):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 11 });
                        break;
                }
            }
        }

        private void PlayerDraw_Click(object sender, EventArgs e)
        {
            if (PlayerDrawnCards == 1)
            {
                PlayerCard1.Visible = true;
                PlayerCard2.Visible = false;
                PlayerCard3.Visible = false;
                PlayerCard4.Visible = false;
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                Debug.WriteLine(Deck[Rand].Value);
                PlayerCard1.Image = (Bitmap)Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name);
                Deck.RemoveAt(Rand);
                PlayerDrawnCards++;
            }
            else if (PlayerDrawnCards == 2)
            {
                PlayerCard2.Visible = true;
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                Debug.WriteLine(Deck[Rand].Value);
                PlayerCard2.Image = (Bitmap)Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name);
                Deck.RemoveAt(Rand);
                PlayerDrawnCards++;
            }
            else if (PlayerDrawnCards == 3)
            {

                PlayerCard3.Visible = true;
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                Debug.WriteLine(Deck[Rand].Value);
                PlayerCard3.Image = (Bitmap)Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name);
                Deck.RemoveAt(Rand);
                PlayerDrawnCards++;
            }
            else if (PlayerDrawnCards == 4)
            {
                PlayerCard4.Visible = true;
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                Debug.WriteLine(Deck[Rand].Value);
                PlayerCard4.Image = (Bitmap)Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name);
                Deck.RemoveAt(Rand);
                //PlayerDrawnCards++;
            }
        }
    }
    public class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}