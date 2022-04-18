using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunController : MonoBehaviour
{
    /// <summary>�e�ۂ�Prefab</summary>
    [SerializeField]
    private GameObject m_bulletPrefab;
    /// <summary>�e���̈ʒu</summary>
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
    /// �e���̈ʒu����e�ۂ𐶐�
    /// </summary>
    public void BulletInstantiate()
    {
        GameObject prefab = m_bulletPrefab;//prefab���ꎞ�ϐ��ɑ��
        Vector3 position=m_muzzle.transform.position;//�e���̈ʒu���ꎞ�ϐ��ɑ��
        Quaternion rotation=m_muzzle.transform.rotation;//�e���̊p�x���ꎞ�ϐ��ɑ��
        Instantiate(prefab, position, rotation);//prefab���ƂɃC���X�^���X����
    }
    
}
