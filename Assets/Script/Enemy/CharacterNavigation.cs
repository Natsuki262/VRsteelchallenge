using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
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

    CapsuleCollider m_collider=null;
    Transform m_defaultTarget;



    // Start is called before the first frame update
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.autoBraking = false;
        //巡回する座標ポイントが設定されている場合は、
        //次の目標地点へ移動する
        //if (m_points.Length > 0) GoNextPoint();
        m_defaultTarget = m_player;
        m_player = GameObject.FindGameObjectWithTag("Player").transform;

    // Update is called once per frame
    void Update()
    {
        /*float ditance=Vector3.Distance(transform.position, m_player.position);
        if (ditance<=m_followRange)
        {

            //プレイヤーへの追跡中フラグを設定する
            m_isChasing = true;

            // 現在の目標地点を次の目標地点に更新する
            m_agent.destination = m_player.position;


        }
        else if (m_isChasing)
        {
            //プレイヤー追跡中フラグを解除
            m_isChasing = false;
            //次の目標地点へ移動する
            GoNextPoint();
            
            
        }*/

        Move();
    }
    /*void GoNextPoint()
    {
        //座標ポイントが設定されていない場合なにもしない
        if (m_points.Length == 0)return;

        //現在の目標地点の移動地点からの次の目標地点を計算する
        m_destPoint = (m_destPoint + 1) % m_points.Length;

        //現在の目標地点を更新する
        m_agent.destination = m_points[m_destPoint].position;
        Debug.Log("更新");
    }*/
    private void Move()
    {
        m_agent.SetDestination(m_player.position);
    }

}

