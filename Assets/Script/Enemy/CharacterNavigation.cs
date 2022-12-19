using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterNavigation : EnemyBase
{
    /// <summary>
    /// 巡回する目標ポイントの配列
    /// </summary>
    [SerializeField]
    Transform[] m_points;
    /// <summary>
    /// 現在の目標地点のインデックス
    /// </summary>
    private int m_destPoint = 0;
    /// <summary>
    /// ナビメッシュエージェント
    /// </summary>
    [SerializeField]
    private NavMeshAgent m_agent;
    /// <summary>
    /// プレイヤーを表す変数
    /// </summary>
    [SerializeField]
    private Transform m_player;
    /// <summary>
    /// プレイヤーを検知する距離
    /// </summary>
    public float m_followRange = 5f;
    /// <summary>
    /// プレイヤーへの追跡中かどうかを表すフラグ
    /// </summary>
    private bool m_isChasing = false;

   


    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        float distance=Vector3.Distance(transform.position, m_player.position);
        if(distance < m_followRange)
        {
            FollowPlayer();
        }
        else
        {
            Patrol();   
        }
    }
    void FollowPlayer()
    {
        m_agent.destination = m_player.position;
        if(m_agent.isStopped)
        {
            m_agent.isStopped = false;
        }

    }
    void Patrol()

    {
        if (Vector3.Distance(transform.position,
                m_points[m_destPoint].position) < m_followRange)
        {
            m_destPoint++;
            if (m_destPoint >= m_points.Length)
            {
                m_destPoint = 0;
            }

        }
        m_agent.destination = m_points[m_destPoint].position;
        if (m_agent.isStopped)
        {
            m_agent.isStopped = false;
        }
    }
}