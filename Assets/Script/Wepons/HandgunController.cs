using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunController : MonoBehaviour
{
    /// <summary>’eŠÛ‚ÌPrefab</summary>
    [SerializeField]
    private GameObject m_bulletPrefab;
    /// <summary>eŒû‚ÌˆÊ’u</summary>
    [SerializeField]
    private GameObject m_muzzle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// eŒû‚ÌˆÊ’u‚©‚ç’eŠÛ‚ğ¶¬
    /// </summary>
    public void BulletInstantiate()
    {
        GameObject prefab = m_bulletPrefab;//prefab‚ğˆê•Ï”‚É‘ã“ü
        Vector3 position=m_muzzle.transform.position;//eŒû‚ÌˆÊ’u‚ğˆê•Ï”‚É‘ã“ü
        Quaternion rotation=m_muzzle.transform.rotation;//eŒû‚ÌŠp“x‚ğˆê•Ï”‚É‘ã“ü
        Instantiate(prefab, position, rotation);//prefab‚à‚Æ‚ÉƒCƒ“ƒXƒ^ƒ“ƒX¶¬
    }
    
}
