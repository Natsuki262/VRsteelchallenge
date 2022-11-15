using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterNavigation :EnemyBase
{
    [SerializeField]
    Transform[] m_points;
    private int destPoint = 0;
    private NavMeshAgent m_agent;

    // Start is called before the first frame update
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.autoBraking = false;
        GoNextPoint();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(!m_agent.pathPending&&m_agent.remainingDistance<0.5f)
        {
            GoNextPoint();
        }
    }
    void GoNextPoint()
    {
        if (m_points.Length == 0)
            return;
        //エージェントが現在地点に設定された目標地点に行くようにする
        m_agent.destination = m_points[destPoint].position;

        //配列内の次の位置を目標地点を設定し、
        //次の目標ならば出発地点に戻ります。
        destPoint=(destPoint+1)%m_points.Length;
    }
}
