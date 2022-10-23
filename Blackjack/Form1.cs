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
        string LatestWinner = "Ingen har vunnit än!";
        List<Card> Deck = new List<Card>();
        Random rng = new Random();
        SoundPlayer Drawing_Cards = new SoundPlayer(Blackjack.Properties.Resource1.Drawing);
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
            Debug.WriteLine(Deck.Count);
            Start.Visible = false;
            //use task to be able to have windows controll while drawing cards
            //Draw 2 cards for the player and two for the dealer and show them
            Task.Run(() =>
            {
                PlayerValue = 0;
                DealerValue = 0;
                PlayerDrawnCards = 3;
                DealerDrawnCards = 3;
                Message.Invoke(new Action(() => Message.Visible = false));
                PlayerCard1.Invoke(new Action(() => PlayerCard1.Visible = false));
                PlayerCard2.Invoke(new Action(() => PlayerCard2.Visible = false));
                PlayerCard3.Invoke(new Action(() => PlayerCard3.Visible = false));
                PlayerCard4.Invoke(new Action(() => PlayerCard4.Visible = false));
                PlayerCard5.Invoke(new Action(() => PlayerCard5.Visible = false));
                PlayerCard6.Invoke(new Action(() => PlayerCard6.Visible = false));s
                PlayerCard7.Invoke(new Action(() => PlayerCard7.Visible = false));
                DealerCard1.Invoke(new Action(() => DealerCard1.Visible = false));
                DealerCard2.Invoke(new Action(() => DealerCard2.Visible = false));
                DealerCard3.Invoke(new Action(() => DealerCard3.Visible = false));
                DealerCard4.Invoke(new Action(() => DealerCard4.Visible = false));
                DealerCard5.Invoke(new Action(() => DealerCard5.Visible = false));
                DealerCard6.Invoke(new Action(() => DealerCard6.Visible = false));
                DealerCard7.Invoke(new Action(() => DealerCard7.Visible = false));
                NameInput.Invoke(new Action(() => NameInput.Visible = false));


                //Draw a random card from the deck to the player
                Drawing_Cards.Play();
                Thread.Sleep(600);
                PlayerCard1.Invoke(new Action(() => PlayerCard1.Visible = true));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                PlayerValue += Deck[Rand].Value;
                Debug.WriteLine("Player has: " + PlayerValue);
                PlayerCard1.Invoke(new Action(() => PlayerCard1.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));

                //Draw a random card from the deck to the dealer
                Drawing_Cards.Play();
                Thread.Sleep(600);
                DealerCard1.Invoke(new Action(() => DealerCard1.Visible = true));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                DealerValue += Deck[Rand].Value;
                Debug.WriteLine("Dealer has: " + DealerValue);
                DealerCard1.Invoke(new Action(() => DealerCard1.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));

                //Draw a random card from the deck to the player
                Drawing_Cards.Play();
                Thread.Sleep(600);
                PlayerCard2.Invoke(new Action(() => PlayerCard2.Visible = true));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                if (Deck[Rand].Value == 11 && DealerValue > 10)
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
                DealerCard2.Invoke(new Action(() => DealerCard2.Visible = true));
                Rand = rng.Next(0, rng.Next(0, Deck.Count));
                DealerCard2Hidden = Deck[Rand].Name;
                if (Deck[Rand].Value == 11 && DealerValue > 10)
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
                    Start.Invoke(new Action(() => Start.Visible = true));
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
                        if (Deck[Rand].Value == 11 && DealerValue > 10)
                        {
                            PlayerValue += 1;
                        }
                        else
                        {
                            PlayerValue += Deck[Rand].Value;
                        }
                        Debug.WriteLine("Player has: " + PlayerValue);
                        PlayerCard3.Invoke(new Action(() => PlayerCard3.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                        PlayerDrawnCards++;
                        break;
                    case 4:
                        //Draw a random card from the deck to the player
                        Drawing_Cards.Play();
                        Thread.Sleep(600);
                        PlayerCard4.Invoke(new Action(() => PlayerCard4.Visible = true));
                        Rand = rng.Next(0, rng.Next(0, Deck.Count));
                        if (Deck[Rand].Value == 11 && DealerValue > 10)
                        {
                            PlayerValue += 1;
                        }
                        else
                        {
                            PlayerValue += Deck[Rand].Value;
                        }
                        Debug.WriteLine("Player has: " + PlayerValue);
                        PlayerCard4.Invoke(new Action(() => PlayerCard4.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                        PlayerDrawnCards++;
                        break;
                    case 5:
                        //Draw a random card from the deck to the player
                        Drawing_Cards.Play();
                        Thread.Sleep(600);
                        PlayerCard5.Invoke(new Action(() => PlayerCard5.Visible = true));
                        Rand = rng.Next(0, rng.Next(0, Deck.Count));
                        if (Deck[Rand].Value == 11 && DealerValue > 10)
                        {
                            PlayerValue += 1;
                        }
                        else
                        {
                            PlayerValue += Deck[Rand].Value;
                        }
                        Debug.WriteLine("Player has: " + PlayerValue);
                        PlayerCard5.Invoke(new Action(() => PlayerCard5.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                        PlayerDrawnCards++;
                        break;
                    case 6:
                        //Draw a random card from the deck to the player
                        Drawing_Cards.Play();
                        Thread.Sleep(600);
                        PlayerCard6.Invoke(new Action(() => PlayerCard6.Visible = true));
                        Rand = rng.Next(0, rng.Next(0, Deck.Count));
                        if (Deck[Rand].Value == 11 && DealerValue > 10)
                        {
                            PlayerValue += 1;
                        }
                        else
                        {
                            PlayerValue += Deck[Rand].Value;
                        }
                        Debug.WriteLine("Player has: " + PlayerValue);
                        PlayerCard6.Invoke(new Action(() => PlayerCard6.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                        PlayerDrawnCards++;
                        break;
                    case 7:
                        //Draw a random card from the deck to the player
                        Drawing_Cards.Play();
                        Thread.Sleep(600);
                        PlayerCard7.Invoke(new Action(() => PlayerCard7.Visible = true));
                        Rand = rng.Next(0, rng.Next(0, Deck.Count));
                        if (Deck[Rand].Value == 11 && DealerValue > 10)
                        {
                            PlayerValue += 1;
                        }
                        else
                        {
                            PlayerValue += Deck[Rand].Value;
                        }
                        Debug.WriteLine("Player has: " + PlayerValue);
                        PlayerCard7.Invoke(new Action(() => PlayerCard7.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
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
                if (PlayerValue > 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));
                    DealerCard2.Invoke(new Action(() => DealerCard2.Image = Properties.Resource1.ResourceManager.GetObject(DealerCard2Hidden) as Image));
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du förlorade!"));
                    Start.Invoke(new Action(() => Start.Visible = true));
                }
                else if (DealerValue > 21 || PlayerValue == 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));
                    DealerCard2.Invoke(new Action(() => DealerCard2.Image = Properties.Resource1.ResourceManager.GetObject(DealerCard2Hidden) as Image));
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du vann!"));
                    Start.Invoke(new Action(() => Start.Visible = true));
                    NameInput.Invoke(new Action(() => NameInput.Visible = true));
                }
            });
        }
        private void PlayerStand_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));
                //Show the dealers hidden card
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
                            if (Deck[Rand].Value == 11 && DealerValue > 10)
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
                            if (Deck[Rand].Value == 11 && DealerValue > 10)
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
                            DealerCard5.Invoke(new Action(() => DealerCard5.Visible = true));
                            Rand = rng.Next(0, rng.Next(0, Deck.Count));
                            if (Deck[Rand].Value == 11 && DealerValue > 10)
                            {
                                DealerValue += 1;
                            }
                            else
                            {
                                DealerValue += Deck[Rand].Value;
                            }
                            Debug.WriteLine("Dealer has: " + DealerValue);
                            DealerCard5.Invoke(new Action(() => DealerCard5.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                            DealerDrawnCards++;
                            break;
                        case 6:
                            //Draw a random card from the deck to the dealer
                            Drawing_Cards.Play();
                            Thread.Sleep(600);
                            DealerCard6.Invoke(new Action(() => DealerCard6.Visible = true));
                            Rand = rng.Next(0, rng.Next(0, Deck.Count));
                            if (Deck[Rand].Value == 11 && DealerValue > 10)
                            {
                                DealerValue += 1;
                            }
                            else
                            {
                                DealerValue += Deck[Rand].Value;
                            }
                            Debug.WriteLine("Dealer has: " + DealerValue);
                            DealerCard6.Invoke(new Action(() => DealerCard6.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                            DealerDrawnCards++;
                            break;
                        case 7:
                            //Draw a random card from the deck to the dealer
                            Drawing_Cards.Play();
                            Thread.Sleep(600);
                            DealerCard7.Invoke(new Action(() => DealerCard7.Visible = true));
                            Rand = rng.Next(0, rng.Next(0, Deck.Count));
                            if (Deck[Rand].Value == 11 && DealerValue > 10)
                            {
                                DealerValue += 1;
                            }
                            else
                            {
                                DealerValue += Deck[Rand].Value;
                            }
                            Debug.WriteLine("Dealer has: " + DealerValue);
                            DealerCard7.Invoke(new Action(() => DealerCard7.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
                            DealerDrawnCards++;
                            break;
                    }
                }
                //find all winners and losers and write it out
                if (PlayerValue > 21 || DealerValue == 21 || DealerValue == PlayerValue || (DealerValue > PlayerValue && DealerValue < 22))
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du förlorade!"));
                    Start.Invoke(new Action(() => Start.Visible = true));
                }
                else if (DealerValue > 21 || PlayerValue == 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du vann!"));
                    Start.Invoke(new Action(() => Start.Visible = true));
                    NameInput.Invoke(new Action(() => NameInput.Visible = true));
                }
            });
        }

        private void Message_TextChanged(object sender, EventArgs e)
        {

        }

        private void Message_Click(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {
            LatestWinnerShow.Text = NameInput.Text + " är den senaste vinnare!";
        }
    }
    public class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}