using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
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

    CapsuleCollider m_collider=null;
    Transform m_defaultTarget;



    // Start is called before the first frame update
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.autoBraking = false;
        //���񂷂���W�|�C���g���ݒ肳��Ă���ꍇ�́A
        //���̖ڕW�n�_�ֈړ�����
        //if (m_points.Length > 0) GoNextPoint();
        m_defaultTarget = m_player;
        m_player = GameObject.FindGameObjectWithTag("Player").transform;

    // Update is called once per frame
    void Update()
    {
        /*float ditance=Vector3.Distance(transform.position, m_player.position);
        if (ditance<=m_followRange)
        {

            //�v���C���[�ւ̒ǐՒ��t���O��ݒ肷��
            m_isChasing = true;

            // ���݂̖ڕW�n�_�����̖ڕW�n�_�ɍX�V����
            m_agent.destination = m_player.position;


        }
        else if (m_isChasing)
        {
            //�v���C���[�ǐՒ��t���O������
            m_isChasing = false;
            //���̖ڕW�n�_�ֈړ�����
            GoNextPoint();
            
            
        }*/

        Move();
    }
    /*void GoNextPoint()
    {
        //���W�|�C���g���ݒ肳��Ă��Ȃ��ꍇ�Ȃɂ����Ȃ�
        if (m_points.Length == 0)return;

        //���݂̖ڕW�n�_�̈ړ��n�_����̎��̖ڕW�n�_���v�Z����
        m_destPoint = (m_destPoint + 1) % m_points.Length;

        //���݂̖ڕW�n�_���X�V����
        m_agent.destination = m_points[m_destPoint].position;
        Debug.Log("�X�V");
    }*/
    private void Move()
    {
        m_agent.SetDestination(m_player.position);
    }

}

