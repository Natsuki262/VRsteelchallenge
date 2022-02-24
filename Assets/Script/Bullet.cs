using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float m_speed;
    Rigidbody m_rb;
    [SerializeField]
    float m_deleateTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        AddForceBullet();
        Destroy(gameObject, m_deleateTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>èeíeÇâ¡ë¨Ç≥ÇπÇÈ</summary>
    public void AddForceBullet()
    {
        m_rb = GetComponent<Rigidbody>();
        Vector3 vector = transform.forward * m_speed;
        m_rb.AddForce(vector, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
    }
}
