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
        public bool m_IsGameover;
        private int m_score;

        public int Score { get => m_score; set => m_score = value; }
       

        // Start is called before the first frame update
        void Start()
        {
            
            if (Iscomponentsnull()) return;

            guiMng.ShowGameGUI(false);
            guiMng.UpdateMainCoins();

        }
        public void PlayGame()
        {
            StartCoroutine(SpawnEnemy());
            guiMng.ShowGameGUI(true);
            guiMng.UpdateGameplayCoins();

        }

        
        public bool Iscomponentsnull()
        {
            return guiMng == null;
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

