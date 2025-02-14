using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LoginM {
    public class LoginManager : MonoBehaviour
    {
        public static LoginManager Instance { get; private set; }
        public string nowScene = "Login";
        public AudioSource startsong;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (Instance != this)
                {
                    Destroy(this.gameObject);


                }
            }

        }
    }
}


