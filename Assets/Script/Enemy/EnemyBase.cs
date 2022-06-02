using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    private int m_HP;
    [SerializeField]
    private GameObject m_effectPrefab;   
   
    /// <summary>
    /// ダメージを受け取る
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        m_HP = m_HP - damage;
        if (m_HP<=0)
        {
            DestroyMyself();
        }

    }
    /// <summary>
    /// 自分を消す
    /// </summary>
    private void DestroyMyself()
    {
        if (m_effectPrefab != null)
        {

            Instantiate(m_effectPrefab);
        }

        Destroy(gameObject);
    }
}
