using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSharp.Module
{
    public class Gamble : BasicGamble
    {
        /// <summary>
        /// 填充一个赌局
        /// </summary>
        /// <param name="player">用户</param>
        /// <param name="addPlayerCount">玩家数量</param>

        public void FillGamble(User player,int addPlayerCount = 6)
        {
            //最多加入九人
            if (addPlayerCount > 9) addPlayerCount = 9;

            List<String> gamer = User.UserDictionary.Keys.ToList();
            gamer.Remove(player.UserID);
            Random rand = new Random();
            for (int i = 0; i < addPlayerCount; i++)
            {
                String selected = gamer[rand.Next(gamer.Count)];
                int choose = rand.Next(0, 2);
                float money = rand.Next((int)(User.FindUser(selected).UserMoney * 0.1),
                    (int)(User.FindUser(selected).UserMoney * 0.7));
                this.AddGambler(User.FindUser(selected), money,(GambleChoose)choose);
                gamer.Remove(selected);
            }
        }
    }
}