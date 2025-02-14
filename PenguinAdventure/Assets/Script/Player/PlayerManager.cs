using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PassiceInfoScript;
namespace PlayerInfoManager
{
    public struct PlayerInfo
    {
        public string _name;
        public int _hp;
        public int _damage;
        public int _defense;
        public float _moveSpeed;
        public int _money;
    }
    public class PlayerManager
    {
        public static PlayerManager instance;
        public PassiveInfo SelectedPassive { get; set; }
        public List<PassiveInfo> passiveList { get; set; }
        public PlayerInfo myPlayer;
        // Start is called before the first frame update
        public static PlayerManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PlayerManager();
                    Instance.passiveList = new List<PassiveInfo>();

                }
                return instance;
            }
        }
        private PlayerManager()
        {
            SelectedPassive = new PassiveInfo();
            myPlayer = new PlayerInfo();
        }
        public void InitializePlayer()
        {
            myPlayer._hp = 50;
            myPlayer._damage = 10;
            myPlayer._defense = 10;
            myPlayer._moveSpeed = 10;
            myPlayer._money = 0;
        }
        public void InitializePassive()
        {
            SelectedPassive.imgSource = "";
            SelectedPassive.GimgSource = "";
        }

    }

}
