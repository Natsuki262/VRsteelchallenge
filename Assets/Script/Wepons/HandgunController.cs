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
    HandgunMagazine m_magazine = null;
    [SerializeField]
    private AudioClip m_AudioClip_Shot;
    [SerializeField]
    private AudioClip m_AudioClip_Enpty;
    [SerializeField]
    private AudioSource m_AudioSource;
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
    private void BulletInstantiate()
    {
        GameObject prefab = m_bulletPrefab;//prefab���ꎞ�ϐ��ɑ��
        Vector3 position = m_muzzle.transform.position;//�e���̈ʒu���ꎞ�ϐ��ɑ��
        Quaternion rotation = m_muzzle.transform.rotation;//�e���̊p�x���ꎞ�ϐ��ɑ��
        Instantiate(prefab, position, rotation);//prefab���ƂɃC���X�^���X����
    }
    /// <summary>
    /// �}�K�W���}����
    /// </summary>
    public void MagazineSelected()
    {

        ///�}�K�W���ɂ��Ă�O���u�̃X�N���v�g���擾
        IXRSelectInteractable magazineInteractable = m_magazineSocket.interactablesSelected[0];
        //�\�P�b�g�ɓ����ꂽ�I�u�W�F�N�g�̃X�N���v�g���擾
        m_magazine = magazineInteractable.transform.GetComponent<HandgunMagazine>();

    }
    /// <summary>
    /// �g���K�[
    /// </summary>
    public void TriggerActivate()
    {
        if (m_magazine == null)
        {
            m_AudioSource.PlayOneShot(m_AudioClip_Enpty);
            return;
        }
        //�c�e������Ȃ甭�C�����Ȃ�
        if (m_magazine.BulletCount <= 0)
        {
            m_AudioSource.PlayOneShot(m_AudioClip_Enpty);
            return;
        }
        BulletInstantiate();
        m_AudioSource.clip = m_AudioClip_Shot;
        m_AudioSource.PlayOneShot(m_AudioClip_Shot);
        m_magazine.ConsumeOneShot();

    }
}
