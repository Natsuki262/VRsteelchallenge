using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int m_HP;
    [SerializeField]
    private GameObject m_effectPrefab;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        m_HP = m_HP - damage;
        DestroyMyself();

    }
    private void DestroyMyself()
    {
        if (m_effectPrefab != null)
        {

            Instantiate(m_effectPrefab);
        }

        Destroy(gameObject);
    }
}
