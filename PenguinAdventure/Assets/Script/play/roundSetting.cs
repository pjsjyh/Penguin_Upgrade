using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundSettingScript
{
    [System.Serializable]
    public class roundSetting
    {
        public string roundType;
        public string[] monsterList;
        public int monsterNum;
    }
    [System.Serializable]
    public class roundWrapper
    {
        public roundSetting[] rounds;
    }
}
