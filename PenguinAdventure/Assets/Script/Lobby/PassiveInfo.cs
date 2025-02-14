using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PassiceInfoScript
{
    [System.Serializable]
    public class PassiveInfo
    {
        public string title;
        public string discription;
        public int nowLevel;
        public int limitLevel;
        public string imgSource;
        public string GimgSource;
        public List<AbilityInfo> abilities;
    }
    [System.Serializable]
    public class AbilityInfo
    {
        public float duration;
        public float cooldown;
    }
}
