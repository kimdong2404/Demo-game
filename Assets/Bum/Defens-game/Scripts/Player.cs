using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bum.Demogame
{
    public class Player : MonoBehaviour
    {
        public float atkRate;
        private Animator m_anim;
        private float m_curAtkRate;
        private bool m_IsAttacked;
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = atkRate;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (m_anim)
                {
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                    m_IsAttacked = true;
                }
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
            if (m_anim)
                m_anim.SetBool(Const.ATTACK_ANIM, false);
        }
    }


}       
