using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    private float m_HP;
    [SerializeField]
    private GameObject m_effectPrefab;
    
    
   
    /// <summary>
    /// ƒ_ƒ[ƒW‚ğó‚¯æ‚é
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        //Debug.Log(damage);
        m_HP = m_HP - damage;
        if (m_HP<=0)
        {
            DestroyMyself();
        }

    }
    /// <summary>
    /// ©•ª‚ğÁ‚·
    /// </summary>
    private void DestroyMyself()
    {
        if (m_effectPrefab != null)
        {
            GameObject prefab = m_effectPrefab;
            Vector3 position = this.gameObject.transform.position;
           Quaternion rotation = new Quaternion();
            Instantiate(prefab,position,rotation);
            
        }

        Destroy(gameObject);
    }
}
