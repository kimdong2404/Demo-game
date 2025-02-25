using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bum.Demogame
{
    public class GuiManager : MonoBehaviour
    {
        public GameObject homeGUI;
        public GameObject gameGUI;
        public Dialog gameoverDialog;
        public Text mainCoinTxt;
        public Text gameplayCoinTxt;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void ShowGameGUI(bool isShow)
        {
            if(gameGUI)
                gameGUI.SetActive(isShow);

            if (homeGUI)
                homeGUI.SetActive(!isShow);
        }
        
        public void UpdateMainCoins()
        {
            if (mainCoinTxt)
                mainCoinTxt.text = Pref.coins.ToString();
        }
        public void UpdateGameplayCoins()
        {
            if (gameplayCoinTxt)
                gameplayCoinTxt.text = Pref.coins.ToString();
        }
        void Update()
        {

        }
    }
}

