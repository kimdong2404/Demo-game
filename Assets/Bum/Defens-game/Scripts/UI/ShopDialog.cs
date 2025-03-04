using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bum.Demogame
{
    public class ShopDialog : Dialog, icomponentchecking
    {
        public Transform griRoot;
        public ShopItemUI itemUIPrefab;
        private ShopManager m_shopMng;
        private GameManager m_gm;

        public override void Show(bool isShow)
        {
            Pref.coins = 1000;
            base.Show(isShow);
            m_shopMng=FindObjectOfType<ShopManager>();
            m_gm=FindObjectOfType<GameManager>();

            UpdateUI();
        }
        public bool Iscomponentsnull()
        {
            return m_shopMng == null && m_gm == null||griRoot==null;
        }
        
        public void UpdateUI()
        {
            if (Iscomponentsnull()) return;
            ClearChilds();
            var items=m_shopMng.items;
            if (items == null || items.Length <= 0) return;

            for(int i = 0; i < items.Length; i++)
            {
                int idx = i;
                var item = items[idx];
                var itemUIClone = Instantiate(itemUIPrefab, Vector3.zero, Quaternion.identity);
                itemUIClone.transform.SetParent(griRoot);//gridroot là mục Content trong Viewport của Scrollview. code này để đưa sản phẩm bán đưa vào folder con của content
                itemUIClone.transform.localScale = Vector3.one;// chỉnh kích thước sản phẩm bán là (1,1,1) để không bị co giãn
                itemUIClone.transform.localPosition= Vector3.zero;//chỉnh vị trí sản phẩm bán ở vị trí (0,0,0)
                itemUIClone.UpdateUI(item, idx);
                if (itemUIClone.btn)
                {
                    itemUIClone.btn.onClick.RemoveAllListeners();
                    itemUIClone.btn.onClick.AddListener(()=>ItemEvent(item,idx));
                }
            }
        }   
        private void ItemEvent(ShopItem item, int itemIdx)
        {
            if (item == null) return;

            bool isUnclocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);
            if (isUnclocked)
            {
                if (itemIdx == Pref.curPlayerId) return;//nếu Player click vào đúng con hero đang chơi thì sẽ không xảy ra event gì
                Pref.curPlayerId = itemIdx;
         
                UpdateUI();
            }
            else if (Pref.coins >= item.price) //đặt yêu cầu coin của người chơi phải lớn hơn giá sp
            {
                Pref.coins -= item.price;//sau khi mua thì coin của player bị trừ đi tiền của giá sp
                Pref.SetBool(Const.PLAYER_PREFIX_PREF + itemIdx, true);
                Pref.curPlayerId=itemIdx;//hero hiện tại = item vừa mới mua
       
                UpdateUI();
                if (m_gm.guiMng)
                    m_gm.guiMng.UpdateMainCoins();
            }
            else
            {
                Debug.Log("Your coin is not enough!");
            }




        }
        public void ClearChilds()
        {
            if (griRoot == null || griRoot.childCount <= 0) return;

            for(int i=0;i<griRoot.childCount;i++)
            {
                var child=griRoot.GetChild(i);

                if (child)
                    Destroy(child.gameObject);
            }
        }
    }


}
