using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bum.Demogame
{
    public class ShopItemUI : MonoBehaviour
    {
        public Text pricetxt;
        public Image hud;
        public Button btn;

        public void UpdateUI(ShopItem item, int itemIdx)
        {
            if (item == null) return;

            if (hud)
                hud.sprite = item.previewImg;//đa khai bao cai nay trong Datastruct
            bool isUnclocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);

            if (isUnclocked)
            {
                if (Pref.curPlayerId == itemIdx)
                {
                    if (pricetxt)
                        pricetxt.text = "Acive";//đã mua và đang sử dụng thì chuyển sang chữ này
                }
                else if(pricetxt)
                {
                    pricetxt.text = "Owned";//đã mua và đang không sử dụng thì chuyển sang chữ này
                }
            }
            else
            {
                if (pricetxt)
                    pricetxt.text = item.price.ToString();
            }
        }
    }


}
