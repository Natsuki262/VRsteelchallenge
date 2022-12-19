using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterNavigation : EnemyBase
{
    /// <summary>
    /// ���񂷂�ڕW�|�C���g�̔z��
    /// </summary>
    [SerializeField]
    Transform[] m_points;
    /// <summary>
    /// ���݂̖ڕW�n�_�̃C���f�b�N�X
    /// </summary>
    private int m_destPoint = 0;
    /// <summary>
    /// �i�r���b�V���G�[�W�F���g
    /// </summary>
    [SerializeField]
    private NavMeshAgent m_agent;
    /// <summary>
    /// �v���C���[��\���ϐ�
    /// </summary>
    [SerializeField]
    private Transform m_player;
    /// <summary>
    /// �v���C���[�����m���鋗��
    /// </summary>
    public float m_followRange = 5f;
    /// <summary>
    /// �v���C���[�ւ̒ǐՒ����ǂ�����\���t���O
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