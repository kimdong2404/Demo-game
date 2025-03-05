using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bum.Demogame
{
    public class Enemy : MonoBehaviour, icomponentchecking
    {
        private Animator m_anim;
        private Rigidbody2D m_rb;
        private Player m_player;
        public float speed;
        public float atkDistance;
        private bool m_IsDead;
        public int minCoinBonus;
        public int maxCoinBonus;

        private GameManager m_gm;
             private void Awake()
             {
                m_anim = GetComponent<Animator>();
                m_rb = GetComponent<Rigidbody2D>();
                m_player=FindObjectOfType<Player>();
                m_gm =FindObjectOfType<GameManager>();

             }
        // Start is called before the first frame update
            void Start()
            {

            }
            public bool Iscomponentsnull() 
            {
                return m_anim == null || m_rb == null || m_player == null || m_gm == null;
            }
            // Update is called once per frame
            void Update()
            {
                if (Iscomponentsnull()) return;
                float DistToPlayer = Vector2.Distance(m_player.transform.position, transform.position);
                if (DistToPlayer <= atkDistance)
                {
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                    m_rb.velocity = Vector2.zero;
                }
                else
                {
                    m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
                }

            }
            public void Die()
            {
                if (Iscomponentsnull()|| m_IsDead) return;
                m_IsDead = true;
                m_anim.SetTrigger(Const.DEAD_ANIM); 
                m_rb.velocity = Vector2.zero;
                gameObject.layer = LayerMask.NameToLayer(Const.DEAD_ANIM);
                m_gm.Score++;
                int CoinBonus = Random.Range(minCoinBonus, maxCoinBonus);
            
                Pref.coins += CoinBonus;    
                if(m_gm.guiMng)
                    m_gm.guiMng.UpdateGameplayCoins();

                if(m_gm.auCtr)
                    m_gm.auCtr.PlaySound(m_gm.auCtr.enemyDead);
               

                
                Destroy(gameObject,2f); 
            
           
            }

    }
}
