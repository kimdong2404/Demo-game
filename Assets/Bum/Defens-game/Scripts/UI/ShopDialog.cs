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
