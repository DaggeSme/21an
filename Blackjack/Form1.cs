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
        int PlayerValue = 15;
        int DealerValue = 0;
        string DealerCard2Hidden = "";
        List<Card> Deck = new List<Card>();
        Random rng = new Random();
        SoundPlayer Drawing_Cards = new SoundPlayer(Blackjack.Properties.Resource1.Drawing);
        public Form1()
        {
            InitializeComponent();
        }
        public void Shuffle()
        {
            //Get the card deck from the resource file and add it to the deck list with a value
            ResourceSet resourceSet =
                Properties.Resource1.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                switch (entry.Key.ToString())
                {
                    case string a when a.Contains('2'):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 2 });
                        break;
                    case string a when a.Contains('3'):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 3 });
                        break;
                    case string a when a.Contains('4'):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 4 });
                        break;
                    case string a when a.Contains('5'):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 5 });
                        break;
                    case string a when a.Contains('6'):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 6 });
                        break;
                    case string a when a.Contains('7'):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 7 });
                        break;
                    case string a when a.Contains('8'):
                        Deck.Add(new Card() { Name = entry.Key.ToString(), Value = 8 });
                        break;
                    case string a when a.Contains('9'):
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
        public void Clear()
        {
            Message.Invoke(new Action(() => Message.Visible = false));
            PlayerCard1.Invoke(new Action(() => PlayerCard1.Visible = false));
            PlayerCard2.Invoke(new Action(() => PlayerCard2.Visible = false));
            PlayerCard3.Invoke(new Action(() => PlayerCard3.Visible = false));
            PlayerCard4.Invoke(new Action(() => PlayerCard4.Visible = false));
            PlayerCard5.Invoke(new Action(() => PlayerCard5.Visible = false));
            PlayerCard6.Invoke(new Action(() => PlayerCard6.Visible = false));
            PlayerCard7.Invoke(new Action(() => PlayerCard7.Visible = false));
            DealerCard1.Invoke(new Action(() => DealerCard1.Visible = false));
            DealerCard2.Invoke(new Action(() => DealerCard2.Visible = false));
            DealerCard3.Invoke(new Action(() => DealerCard3.Visible = false));
            DealerCard4.Invoke(new Action(() => DealerCard4.Visible = false));
            DealerCard5.Invoke(new Action(() => DealerCard5.Visible = false));
            DealerCard6.Invoke(new Action(() => DealerCard6.Visible = false));
            DealerCard7.Invoke(new Action(() => DealerCard7.Visible = false));
            NameInput.Invoke(new Action(() => NameInput.Visible = false));
        }
        public void PlayerDrawCard(PictureBox Card)
        {
            //Draw a random card from the deck to the player
            Drawing_Cards.Play();
            Thread.Sleep(600);
            Card.Invoke(new Action(() => Card.Visible = true));
            Rand = rng.Next(0, rng.Next(0, Deck.Count));
            if (Deck[Rand].Value == 11 && PlayerValue > 10)
            {
                PlayerValue += 1;
            }
            else
            {
                PlayerValue += Deck[Rand].Value;
            }
            Card.Invoke(new Action(() => Card.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
            Deck.Remove(Deck[Rand]);
        }
        public void DealerDrawCard(PictureBox Card)
        {
            //Draw a random card from the deck to the player
            Drawing_Cards.Play();
            Thread.Sleep(600);
            Card.Invoke(new Action(() => Card.Visible = true));
            Rand = rng.Next(0, rng.Next(0, Deck.Count));
            if (Deck[Rand].Value == 11 && DealerValue > 10)
            {
                DealerValue += 1;
            }
            else
            {
                DealerValue += Deck[Rand].Value;
            }
            Card.Invoke(new Action(() => Card.Image = Properties.Resource1.ResourceManager.GetObject(Deck[Rand].Name) as Image));
            Deck.Remove(Deck[Rand]);
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (Deck.Count < 15)
            {
                Deck.Clear();
                Shuffle();
            }
            Debug.WriteLine(Deck.Count);
            Start.Visible = false;
            //use task to be able to have windows controll while drawing cards
            //Draw 2 cards for the player and two for the dealer and show them
            Task.Run(() =>
            {
                //Reset all needed values and clear the screen
                PlayerValue = 0;
                DealerValue = 0;
                PlayerDrawnCards = 3;
                DealerDrawnCards = 3;
                Clear();
                //Draw a random card from the deck to the player
                PlayerDrawCard(PlayerCard1);
                //Draw a random card from the deck to the dealer
                DealerDrawCard(DealerCard1);
                //Draw a random card from the deck to the player
                PlayerDrawCard(PlayerCard2);
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
                Deck.Remove(Deck[Rand]);

                //Check if the player has blackjack
                if (PlayerValue == 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du vann!"));
                    Start.Invoke(new Action(() => Start.Visible = true));
                    NameInput.Invoke(new Action(() => NameInput.Visible = true));
                }
                //Check to see if the player can continue is so show buttons
                if (PlayerValue < 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = true));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = true));
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
                        PlayerDrawCard(PlayerCard3);
                        PlayerDrawnCards++;
                        break;
                    case 4:
                        //Draw a random card from the deck to the player
                        PlayerDrawCard(PlayerCard4);
                        PlayerDrawnCards++;
                        break;
                    case 5:
                        //Draw a random card from the deck to the player
                        PlayerDrawCard(PlayerCard5);
                        PlayerDrawnCards++;
                        break;
                    case 6:
                        //Draw a random card from the deck to the player
                        PlayerDrawCard(PlayerCard6);
                        PlayerDrawnCards++;
                        break;
                    case 7:
                        //Draw a random card from the deck to the player
                        PlayerDrawCard(PlayerCard7);
                        PlayerDrawnCards++;
                        break;
                }
                //Check to see if the player can continue is so show buttons
                if (PlayerValue < 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = true));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = true));
                }
                //find all winners and losers and write it out
                if (PlayerValue > 21)
                {
                    PlayerDraw.Invoke(new Action(() => PlayerDraw.Visible = false));
                    PlayerStand.Invoke(new Action(() => PlayerStand.Visible = false));
                    DealerCard2.Invoke(new Action(() => DealerCard2.Image = Properties.Resource1.ResourceManager.GetObject(DealerCard2Hidden) as Image));
                    Message.Invoke(new Action(() => Message.Visible = true));
                    Message.Invoke(new Action(() => Message.Text = "Du förlorade!"));
                    LatestWinnerShow.Invoke(new Action(() => LatestWinnerShow.Text = "Datorn var den senaste vinnare!"));
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
                Debug.WriteLine("Dealer has: " + DealerValue);
                while (DealerValue < 19) //&& DealerValue < PlayerValue
                {
                    switch (DealerDrawnCards)
                    {
                        case 3:
                            //Draw a random card from the deck to the dealer
                            DealerDrawCard(DealerCard3);
                            DealerDrawnCards++;
                            break;
                        case 4:
                            //Draw a random card from the deck to the dealer
                            DealerDrawCard(DealerCard4);
                            DealerDrawnCards++;
                            break;
                        case 5:
                            //Draw a random card from the deck to the dealer
                            DealerDrawCard(DealerCard5);
                            DealerDrawnCards++;
                            break;
                        case 6:
                            //Draw a random card from the deck to the dealer
                            DealerDrawCard(DealerCard6);
                            DealerDrawnCards++;
                            break;
                        case 7:
                            //Draw a random card from the deck to the dealer
                            DealerDrawCard(DealerCard7);
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
                    LatestWinnerShow.Invoke(new Action(() => LatestWinnerShow.Text = "Datorn var den senaste vinnare!"));
                    Start.Invoke(new Action(() => Start.Visible = true));
                }
                else if (DealerValue > 21 || PlayerValue == 21 || (DealerValue < PlayerValue && PlayerValue < 21))
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

        private void Name_TextChanged(object sender, EventArgs e)
        {
            LatestWinnerShow.Text = NameInput.Text + " var den senaste vinnare!";
        }
    }
    public class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}