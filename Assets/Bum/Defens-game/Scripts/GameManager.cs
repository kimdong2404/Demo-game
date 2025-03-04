using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bum.Demogame
{
    public class GameManager : MonoBehaviour, icomponentchecking
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        public GuiManager guiMng;
        public ShopManager shopMng;
        public bool m_IsGameover;
        private int m_score;
        private Player m_curPlayer;

        public int Score { get => m_score; set => m_score = value; }
       

        // Start is called before the first frame update
        void Start()
        {
            
            if (Iscomponentsnull()) return;
            guiMng.ShowGameGUI(false);
            guiMng.UpdateMainCoins();

        }
        public bool Iscomponentsnull()
        {
            return guiMng == null||shopMng==null;
        }
        public void PlayGame()
        {
            ActivePlayer();
            StartCoroutine(SpawnEnemy());
            guiMng.ShowGameGUI(true);
            guiMng.UpdateGameplayCoins();

        }
        public void ActivePlayer()
        {
            if (Iscomponentsnull()) return;
            if(m_curPlayer)
                Destroy(m_curPlayer.gameObject);
            var shopItems = shopMng.items;
            if(shopItems==null|| shopItems.Length<=0) return;
            var newPlayerPb=shopItems[Pref.curPlayerId].playerPrefab;
            if(newPlayerPb)
                m_curPlayer=Instantiate(newPlayerPb, new Vector3(-7f,-1f,0f),Quaternion.identity);//lấy ra hero vừa mua
        }

        


        public void Gameover() //khi game ket thuc thi khong thuc hien cau lenh ben duoi nua
        {
            if(m_IsGameover) return;
            m_IsGameover = true;
            Pref.bestScore= m_score;
            if(guiMng.gameoverDialog)
                guiMng.gameoverDialog.Show(true);
        }

        void Update()
        {

        }
        IEnumerator SpawnEnemy()
        {
            while (!m_IsGameover)
            {
                if (enemyPrefabs != null && enemyPrefabs.Length > 0)
                {
                    int randIdx = Random.Range(0, enemyPrefabs.Length);
                    Enemy enemyPrefab= enemyPrefabs[randIdx];
               
                        if (enemyPrefab)
                        {
                            Instantiate(enemyPrefab, new Vector3(8,0,0), Quaternion.identity);
                        }
                }
                    yield return new WaitForSeconds(spawnTime);
            }
        }

    }


}

