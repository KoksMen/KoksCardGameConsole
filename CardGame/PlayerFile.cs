using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_v3
{
    public class Player
    {
        public Player(string Name, MainCard [] AllCards) { PlayerName = Name; CardInventory = AllCards; }
        public string PlayerName { get; set; }
        public MainCard [] CardInventory { get; set; }
        public void ShowInventory(MainCard.Mode status)
        {
            //Console.Clear();
            Console.WriteLine($"{PlayerName} is your card inventory");
            foreach (var CurrentCard in CardInventory)
            {
                CurrentCard.ShowCard(status, MainCard.CardFrienlyStatus.PlayerCard);
            }
            if (status != MainCard.Mode.BattleMode)
            {
                Console.ResetColor();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void CardBattle(MainCard AttackerCard, MainCard DefenderCard)
        {
            DefenderCard.CurrentHP -= AttackerCard.DMG;
            AttackerCard.CurrentHP -= DefenderCard.DMG;
            if (DefenderCard.CurrentHP < 0) { DefenderCard.CurrentHP = 0; DefenderCard.AliveStatus = false; }
            if (AttackerCard.CurrentHP < 0) { AttackerCard.CurrentHP = 0; AttackerCard.AliveStatus = false; }
            if (AttackerCard.CurrentCardFriendlyStatus == MainCard.CardFrienlyStatus.PlayerCard)
            {
                Console.WriteLine("You got attack, and enemy got revers attack");
            }
            else if (AttackerCard.CurrentCardFriendlyStatus == MainCard.CardFrienlyStatus.EnemyCard)
            {
                Console.WriteLine("Enemy got attack, and your got revers attack");
            }
        }

        public MainCard SelectedCard()
        {
            int SelectedNumber;
            MainCard _SelectedCard;
            ShowInventory(MainCard.Mode.BattleMode);
            Console.Write("Enter number of selected card: ");
            SelectedNumber = Convert.ToInt32(Console.ReadLine());
            _SelectedCard = CardInventory[SelectedNumber - 1];
            if (_SelectedCard.AliveStatus == false)
            {
                Console.Clear();
                _SelectedCard = null;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You cant take this card, becouse this card is dead!");
                Console.ResetColor();
            }
            return _SelectedCard;
        }
    }
}
