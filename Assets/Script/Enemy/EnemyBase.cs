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
    /// �_���[�W���󂯎��
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
    /// ����������
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
