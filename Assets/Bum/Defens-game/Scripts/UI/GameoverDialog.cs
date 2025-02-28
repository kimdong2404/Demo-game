using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Bum.Demogame
{
    public class GameoverDialog : Dialog
    {
        public Text BestscoretTxt;
        public override void Show(bool isShow)
        {
            base.Show(isShow);
            if (BestscoretTxt)
                BestscoretTxt.text =Pref.bestScore.ToString("0000");
        }
        public void Replay()
        {
            Close();
            SceneManager.LoadScene(Const.GAMEPLAY_SCENE);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }

}
