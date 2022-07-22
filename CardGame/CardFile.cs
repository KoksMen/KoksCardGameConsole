using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_v3
{
    interface ICardFunction
    {
        void ResetCurrentHP();
    }
    public abstract class MainCard:ICardFunction
    {
        public enum CardFrienlyStatus
        {
            PlayerCard, EnemyCard
        }
        private string CardName; 
        private int CardHP; 
        private int CardDMG;
        private bool CardAliveStatus;
        public MainCard(string name, int hp, int dmg, CardFrienlyStatus status) 
        {
            CardName = name; CardHP = hp; CardDMG = dmg;
            CurrentHP = hp; AliveStatus = true;
        }
        public CardFrienlyStatus CurrentCardFriendlyStatus { get; }
        public string Name { get { return CardName; } }
        public int HP { get { return CardHP; } }
        public int DMG { get { return CardDMG; } }
        public bool AliveStatus { get { return CardAliveStatus; } set { CardAliveStatus = value; } }
        public int CurrentHP { get; set; }

        public void ResetCurrentHP()
        {
            CurrentHP = CardHP;
        }
        public enum Mode
        {
            BattleMode, StandartMode
        }

        public virtual void ShowCard(Mode mode, CardFrienlyStatus status)
        {
            if (mode == Mode.StandartMode)
            {
                if (status == CardFrienlyStatus.PlayerCard) Console.ForegroundColor = ConsoleColor.DarkBlue;
                else if (status == CardFrienlyStatus.EnemyCard) Console.ForegroundColor = ConsoleColor.DarkRed;
                string AliveMessage = "Wrong alive status";
                if (AliveStatus == true) 
                {
                    if (status == CardFrienlyStatus.EnemyCard) Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (status == CardFrienlyStatus.PlayerCard) Console.ForegroundColor = ConsoleColor.Blue; 
                    AliveMessage = "Card is alive"; 
                }
                if (AliveStatus == false) { Console.ForegroundColor = ConsoleColor.Red; AliveMessage = "Card is dead"; }
                Console.WriteLine($"----------\nCard information:\n Card name: {Name} | Card HP: {HP} | Card DMG: {DMG}\n Card alive status: {AliveMessage}\n----------");
                Console.ResetColor();
            }
            else if (mode == Mode.BattleMode)
            {
                if (status == CardFrienlyStatus.PlayerCard) Console.ForegroundColor = ConsoleColor.DarkBlue;
                else if (status == CardFrienlyStatus.EnemyCard) Console.ForegroundColor = ConsoleColor.DarkRed;
                if (status == CardFrienlyStatus.PlayerCard) Console.ForegroundColor = ConsoleColor.DarkBlue;
                else if (status == CardFrienlyStatus.EnemyCard) Console.ForegroundColor = ConsoleColor.DarkRed;
                string AliveMessage = "Wrong alive status";
                if (AliveStatus == true) 
                {
                    if (status == CardFrienlyStatus.EnemyCard) Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (status == CardFrienlyStatus.PlayerCard) Console.ForegroundColor = ConsoleColor.Blue;
                    AliveMessage = "Card is alive";
                }
                if (AliveStatus == false) { Console.ForegroundColor = ConsoleColor.Red; AliveMessage = "Card is dead"; }
                Console.WriteLine($"----------\nCard information:\n Card name: {Name} | Card HP: {CurrentHP} | Card DMG: {DMG}\n Card alive status: {AliveMessage}\n----------");
                Console.ResetColor();
            }
        }
    }

    class FatyiCard : MainCard
    {
        public FatyiCard(string name, int hp, int dmg, MainCard.CardFrienlyStatus status) : base(name, hp, dmg, status) { }
    }
}
