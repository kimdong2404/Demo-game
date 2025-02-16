using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bum.Demogame
{
    public class ShopManager : MonoBehaviour
    {
        public ShopItem[] items;
        // Start is called before the first frame update
        void Start()
        {
            Init();
        }
        private void Init()
        {
            if (items == null || items.Length <= 0) return;
            for (int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                string dataKey = Const.PLAYER_PREFIX_PREF + i;//player 0, player 1, Player 2

                if (items != null)
                {
                    if (i == 0)
                        Pref.SetBool(dataKey, true);
                    else
                        if(!PlayerPrefs.HasKey(dataKey))
                        Pref.SetBool(dataKey, false);
                }
            }
        }
    }
}
    
