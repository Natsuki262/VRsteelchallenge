using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandgunController : MonoBehaviour
{
    /// <summary>�e�ۂ�Prefab</summary>
    [SerializeField]
    private GameObject m_bulletPrefab;
    /// <summary>�e���̈ʒu</summary>
    [SerializeField]
    private GameObject m_muzzle;
    [SerializeField]
    XRSocketInteractor m_magazineSocket;
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
    public void MagazineSelected()
    {
        HandgunMagazine magazine = null;
        ///�}�K�W���ɂ��Ă�O���u�̃X�N���v�g���擾
        IXRSelectInteractable magazineInteractable = m_magazineSocket.interactablesSelected[0];
        //�\�P�b�g�ɓ����ꂽ�I�u�W�F�N�g�\�P�b�g�ɓ����ꂽ�I�u�W�F�N�g�̃X�N���v�g���擾
        magazine = magazineInteractable.transform.GetComponent<HandgunMagazine>();
        

    }

}
