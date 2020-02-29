namespace ConsoleSharp.Module
{
    internal class Game
    {
        private delegate void Deal(Player enemy, int damage);

        public static void Fight(Player playerFirst, Player playerSecond)
        {
            Player tempPlayer = playerSecond;
            Deal DealEnemy;
            do
            {
                int damage = playerFirst.Attack(playerSecond);
                DealEnemy = playerSecond.HP > 0 ? new Deal(playerFirst.AttackShow) : new Deal(playerFirst.KillShow);
                DealEnemy(playerSecond, damage);
                playerSecond = playerFirst;
                playerFirst = tempPlayer;
                tempPlayer = playerSecond;
            } while (playerFirst.HP > 0);

            playerSecond.AddExp(1000);
        }
    }
}