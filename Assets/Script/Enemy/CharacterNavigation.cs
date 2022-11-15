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
        //�G�[�W�F���g�����ݒn�_�ɐݒ肳�ꂽ�ڕW�n�_�ɍs���悤�ɂ���
        m_agent.destination = m_points[destPoint].position;

        //�z����̎��̈ʒu��ڕW�n�_��ݒ肵�A
        //���̖ڕW�Ȃ�Ώo���n�_�ɖ߂�܂��B
        destPoint=(destPoint+1)%m_points.Length;
    }
}
