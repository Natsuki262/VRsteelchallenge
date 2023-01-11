using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZonbieController : MonoBehaviour
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
        SwichState();
    }

    //Animationストップする関数
    public void AnimationStop()
    {
        m_animator.SetBool("waking", false);
        m_animator.SetBool("Atack", false);
        m_animator.SetBool("Run", false);
        m_animator.SetBool("Deth", false);
    }
    void SwichState()
    {
        switch (state)
        {
            case STATE.IDLE:
                AnimationStop();
                if (Random.Range(0, 5000) < 5)
                {
                    state = STATE.PATROL;
                }
                break;
            case STATE.PATROL:
                if (!m_agent.hasPath)
                {
                    float x = transform.position.x + Random.Range(-5, 5);
                    float z = transform.position.z + Random.Range(-5, 5);

                    Vector3 NextPos=new Vector3(x,transform.position.y,z);

                    m_agent.SetDestination(NextPos);
                    m_agent.stoppingDistance = 0;
                    AnimationStop();

                    m_agent.speed = m_enemySpeed;
                    m_animator.SetBool("waking", true);
                }
                if(Random.Range(0,5000)<5)
                {
                    state=STATE.IDLE;
                    m_agent.ResetPath();
                }
                break;
            case STATE.ATTACK:
                break;
            case STATE.DED:
                break;
            default:
                break;
        }
    }
}
