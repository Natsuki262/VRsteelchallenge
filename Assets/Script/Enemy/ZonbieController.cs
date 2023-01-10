using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZonbieContr : MonoBehaviour
{
    //アニメーターとAI
    [SerializeField]
    NavMeshAgent m_agent;
    [SerializeField]
    Animator m_animator;
    [SerializeField]
    float m_enemySpeed;
    //ステート
    enum STATE { IDLE, PATROL, ATTACK, DED }
    STATE state = STATE.IDLE;
    // Start is called before the first frame update

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Animationストップする関数
    public void AnimationStop()
        {
        m_animator.SetBool("waking", false);
        m_animator.SetBool("Atack", false);
        m_animator.SetBool("Run", false);
        m_animator.SetBool("Deth", false);
    }
}
