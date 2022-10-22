using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Reflection.Emit;
using System.Resources;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        int Rand = 0;
        int PlayerDrawnCards = 1;
        List<Card> Deck = new List<Card>();
        Random rng = new Random();
        SoundPlayer Drawing_Cards = new SoundPlayer(Blackjack.Properties.Resource1.Drawing);
        SoundPlayer Drawing_Cards_4 = new SoundPlayer(Blackjack.Properties.Resource1.Drawingfour);
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
            Task.Run(() =>
            {
                //Draw a random card from the deck to the player
                Drawing_Cards.Play();
                Thread.Sleep(600);
                PlayerCard1.Invoke(new Action(() => PlayerCard1.Visible = true));
                PlayerCard2.Invoke(new Action(() => PlayerCard2.Visible = false));
                PlayerCard3.Invoke(new Action(() => PlayerCard3.Visible = false));
                PlayerCard4.Invoke(new Action(() => PlayerCard4.Visible = false));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                Debug.WriteLine(Deck[Rand].Value);
                PlayerCard1.Invoke(new Action(() => PlayerCard1.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));

                //Draw a random card from the deck to the dealer
                Drawing_Cards.Play();
                Thread.Sleep(600);
                DealerCard1.Invoke(new Action(() => PlayerCard1.Visible = true));
                DealerCard2.Invoke(new Action(() => PlayerCard2.Visible = false));
                DealerCard3.Invoke(new Action(() => PlayerCard3.Visible = false));
                DealerCard4.Invoke(new Action(() => PlayerCard4.Visible = false));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                Debug.WriteLine(Deck[Rand].Value);
                DealerCard1.Invoke(new Action(() => DealerCard1.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));

                //Draw a random card from the deck to the player
                Drawing_Cards.Play();
                Thread.Sleep(600);
                PlayerCard1.Invoke(new Action(() => PlayerCard1.Visible = true));
                PlayerCard2.Invoke(new Action(() => PlayerCard2.Visible = true));
                PlayerCard3.Invoke(new Action(() => PlayerCard3.Visible = false));
                PlayerCard4.Invoke(new Action(() => PlayerCard4.Visible = false));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                Debug.WriteLine(Deck[Rand].Value);
                PlayerCard2.Invoke(new Action(() => PlayerCard2.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                
                //Draw a random card from the deck to the dealer
                Drawing_Cards.Play();
                Thread.Sleep(600);
                DealerCard1.Invoke(new Action(() => PlayerCard1.Visible = true));
                DealerCard2.Invoke(new Action(() => PlayerCard2.Visible = true));
                DealerCard3.Invoke(new Action(() => PlayerCard3.Visible = false));
                DealerCard4.Invoke(new Action(() => PlayerCard4.Visible = false));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                Debug.WriteLine(Deck[Rand].Value);
                DealerCard2.Invoke(new Action(() => DealerCard2.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
            });
            
        }

        private void PlayerDraw_Click_1(object sender, EventArgs e)
        {

        }
    }
    public class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}