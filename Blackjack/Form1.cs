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
        int PlayerDrawnCards = 3;
        int DealerDrawnCards = 3;
        int PlayerValue = 0;
        int DealerValue = 0;
        String DealerCard2Hidden = "";
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

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Visible = false;
            //use task to be able to have windows controll while drawing cards
            //Draw 2 cards for the player and two for the dealer and show them
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
                PlayerValue += Deck[Rand].Value;
                Debug.WriteLine("Player has: " + PlayerValue);
                PlayerCard1.Invoke(new Action(() => PlayerCard1.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));

                //Draw a random card from the deck to the dealer
                Drawing_Cards.Play();
                Thread.Sleep(600);
                DealerCard1.Invoke(new Action(() => DealerCard1.Visible = true));
                DealerCard2.Invoke(new Action(() => DealerCard2.Visible = false));
                DealerCard3.Invoke(new Action(() => DealerCard3.Visible = false));
                DealerCard4.Invoke(new Action(() => DealerCard4.Visible = false));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                DealerValue += Deck[Rand].Value;
                Debug.WriteLine("Dealer has: " + DealerValue);
                DealerCard1.Invoke(new Action(() => DealerCard1.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));

                //Draw a random card from the deck to the player
                Drawing_Cards.Play();
                Thread.Sleep(600);
                PlayerCard1.Invoke(new Action(() => PlayerCard1.Visible = true));
                PlayerCard2.Invoke(new Action(() => PlayerCard2.Visible = true));
                PlayerCard3.Invoke(new Action(() => PlayerCard3.Visible = false));
                PlayerCard4.Invoke(new Action(() => PlayerCard4.Visible = false));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                if (Deck[Rand].Value == 11 && (PlayerValue += 11) < 21)
                {
                    PlayerValue += 1;
                }
                else
                {
                    PlayerValue += Deck[Rand].Value;
                }
                Debug.WriteLine("Player has: " + PlayerValue);
                PlayerCard2.Invoke(new Action(() => PlayerCard2.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                
                //Draw a random card from the deck to the dealer but not showing it
                Drawing_Cards.Play();
                Thread.Sleep(600);
                DealerCard1.Invoke(new Action(() => DealerCard1.Visible = true));
                DealerCard2.Invoke(new Action(() => DealerCard2.Visible = true));
                DealerCard3.Invoke(new Action(() => DealerCard3.Visible = false));
                DealerCard4.Invoke(new Action(() => DealerCard4.Visible = false));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                DealerCard2Hidden = Deck[Rand].Name;
                if (Deck[Rand].Value == 11 && (DealerValue += 11) < 21)
                {
                    DealerValue += 1;
                }
                else
                {
                    DealerValue += Deck[Rand].Value;
                }
                Debug.WriteLine("Dealer has: " + DealerValue);
                DealerCard2.Invoke(new Action(() => DealerCard2.Image = Properties.Resource1.ResourceManager.GetObject("back") as Image));


                //Check if the player has blackjack
                if (PlayerValue == 21)
                {
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du vann!"));
                }
                if (PlayerValue < 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = true));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = true));
                }
                else
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));

                }
            });
        }

        private void PlayerDraw_Click_1(object sender, EventArgs e)
        {
            Task.Run(() =>
            { 
                switch (PlayerDrawnCards)
            {
                case 3:
                    //Draw a random card from the deck to the player
                    Drawing_Cards.Play();
                    Thread.Sleep(600);
                    PlayerCard3.Invoke(new Action(() => PlayerCard3.Visible = true));
                    PlayerCard4.Invoke(new Action(() => PlayerCard4.Visible = false));
                    Rand = rng.Next(0, rng.Next(0, Deck.Count));
                    if (Deck[Rand].Value == 11 && (PlayerValue += 11) < 21)
                    {
                        PlayerValue += 1;
                    }
                    else
                    {
                        PlayerValue += Deck[Rand].Value;
                    }
                    Debug.WriteLine(PlayerValue);
                    PlayerCard3.Invoke(new Action(() => PlayerCard3.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                    PlayerDrawnCards++;
                    break;
                case 4:
                    //Draw a random card from the deck to the player
                    Drawing_Cards.Play();
                    Thread.Sleep(600);
                    PlayerCard4.Invoke(new Action(() => PlayerCard4.Visible = true));
                    Rand = rng.Next(0, rng.Next(0, Deck.Count));
                    if (Deck[Rand].Value == 11 && (PlayerValue += 11) < 21)
                    {
                        PlayerValue += 1;
                    }
                    else
                    {
                        PlayerValue += Deck[Rand].Value;
                    }
                    Debug.WriteLine(PlayerValue);
                    PlayerCard4.Invoke(new Action(() => PlayerCard4.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                    PlayerDrawnCards++;
                    break;
            }
                if (PlayerValue < 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = true));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = true));
                }
                else
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));

                }
                //find all winners and losers and write it out
                if (PlayerValue > 21 || DealerValue == 21)
                {
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du förlorade!"));
                }
                else if (DealerValue > 21 || PlayerValue == 21)
                {
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du vann!"));
                }
                else if (DealerValue == PlayerValue && DealerValue == 21)
                {
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du förlorade!"));
                }
            });
        }

        private void PlayerStand_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                DealerCard2.Invoke(new Action(() => DealerCard2.Image = Properties.Resource1.ResourceManager.GetObject(DealerCard2Hidden) as Image));
                while (DealerValue < 19) //&& DealerValue < PlayerValue
                {
                    switch (DealerDrawnCards)
                    {
                        case 3:
                            //Draw a random card from the deck to the dealer
                            Drawing_Cards.Play();
                            Thread.Sleep(600);
                            DealerCard3.Invoke(new Action(() => DealerCard3.Visible = true));
                            DealerCard4.Invoke(new Action(() => DealerCard4.Visible = false));
                            Rand = rng.Next(0, rng.Next(0, Deck.Count));
                            if (Deck[Rand].Value == 11 && (DealerValue += 11) < 21)
                            {
                                DealerValue += 1;
                            }
                            else
                            {
                                DealerValue += Deck[Rand].Value;
                            }
                            Debug.WriteLine("Dealer has: " + DealerValue);
                            DealerCard3.Invoke(new Action(() => DealerCard3.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                            DealerDrawnCards++;
                            break;
                        case 4:
                            //Draw a random card from the deck to the dealer
                            Drawing_Cards.Play();
                            Thread.Sleep(600);
                            DealerCard3.Invoke(new Action(() => DealerCard3.Visible = true));
                            DealerCard4.Invoke(new Action(() => DealerCard4.Visible = true));
                            Rand = rng.Next(0, rng.Next(0, Deck.Count));
                            if (Deck[Rand].Value == 11 && (DealerValue += 11) < 21)
                            {
                                DealerValue += 1;
                            }
                            else
                            {
                                DealerValue += Deck[Rand].Value;
                            }
                            Debug.WriteLine("Dealer has: " + DealerValue);
                            DealerCard4.Invoke(new Action(() => DealerCard4.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                            DealerDrawnCards++;
                            break;
                        case 5:
                            //Draw a random card from the deck to the dealer
                            Drawing_Cards.Play();
                            Thread.Sleep(600);
                            Rand = rng.Next(0, rng.Next(0, Deck.Count));
                            if (Deck[Rand].Value == 11 && (DealerValue += 11) < 21)
                            {
                                DealerValue += 1;
                            }
                            else
                            {
                                DealerValue += Deck[Rand].Value;
                            }
                            Debug.WriteLine("Dealer has: " + DealerValue);
                            var DealerCard5 = new PictureBox
                            {
                                Name = "DealerCard5",
                                Size = new Size(150, 218),
                                Location = new Point(DealerCard4.Location.X + 100, 100),
                                Image = (Image)Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name),
                            };
                            DealerCard4.Invoke(new Action(() => Controls.Add(DealerCard5)));
                            DealerCard4.Invoke(new Action(() => DealerCard5.BringToFront()));
                            break;
                    }
                }
                //find all winners and losers and write it out
                if (PlayerValue > 21 || DealerValue == 21)
                {
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du förlorade!"));
                }
                else if (DealerValue > 21 || PlayerValue == 21)
                {
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du vann!"));
                }
                else if (DealerValue == PlayerValue && DealerValue == 21)
                {
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du förlorade!"));
                }
            });
        }
    }
    public class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}