using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bum.Demogame
{
    public class Player : MonoBehaviour, icomponentchecking
    {
        public float atkRate;
        private Animator m_anim;
        private float m_curAtkRate;
        private bool m_IsAttacked;
        private bool m_IsDead;
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = atkRate;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public bool Iscomponentsnull()
        {
            return m_anim == null;
        }

        // Update is called once per frame
        void Update()
        {
            if (Iscomponentsnull()) return;
            if (Input.GetMouseButtonDown(0))
            {
                m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_IsAttacked = true;
                if (m_IsAttacked)
                {
                    m_curAtkRate = Time.deltaTime;
                    if (m_curAtkRate <= 0)
                    {
                        m_IsAttacked = false;
                        m_curAtkRate = atkRate;
                    }
                }
            }
        }
        public void ResetatkAnim()
        {
            if (Iscomponentsnull()) return;
            m_anim.SetBool(Const.ATTACK_ANIM, false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (Iscomponentsnull()) return;

            if (col.CompareTag(Const.ENEMY_WEAPON_TAG)&&!m_IsDead)
            {
                m_anim.SetTrigger(Const.DEAD_ANIM);
                m_IsDead = true;
                gameObject.layer=LayerMask.NameToLayer(Const.DEAD_LAYER);
            }
        }
    }
}