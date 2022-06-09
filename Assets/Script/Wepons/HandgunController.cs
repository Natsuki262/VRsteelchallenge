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
    /// <summary>
    /// emptyMagazine��Prefab
    /// </summary>
    [SerializeField]
    private GameObject m_emptyMagazine;
    /// <summary>
    /// IA�� InstantiateArea�̗�
    ///��̃}�K�W���̐����ʒu
    /// </summary>
    [SerializeField]
    private GameObject m_emptyMagazineIA;
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


        //�����o�[�ϐ��ɁA�}�K�W���̃X�N���v�g���� 
        m_magazine = GetHandgunMagazineScript();

        if (m_magazine == null) return;

        //�}�������}�K�W���̃I�u�W�F�N�g���A�N�e�B�u�ɂ���
        m_magazine.gameObject.SetActive(false);
        //�_�~�[�̃}�K�W���̃��f�����A�N�e�B�u������

        //�\�P�b�g�̋@�\���A�N�e�B�u�ɂ���

    }
    /// <summary>
    /// �}������Ă���n���h�K���}�K�W���̃X�N���v�g
    /// </summary>
    /// <returns>�n���h�K���}�K�W���̃X�N���v�g</returns>
    private HandgunMagazine GetHandgunMagazineScript()
    {
        ///�}�K�W���ɂ��Ă�O���u�̃X�N���v�g���擾
        IXRSelectInteractable magazineInteractable = m_magazineSocket.interactablesSelected[0];

        return magazineInteractable.transform.GetComponent<HandgunMagazine>();
    }

    /// <summary>
    /// �g���K�[
    /// </summary>
    public void TriggerActivate()
    {
        //�}�K�W�������U����ĂȂ����
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
        //���C�������������Ă鎞
        BulletInstantiate();
        //m_AudioSource.clip = m_AudioClip_Shot;
        m_AudioSource.PlayOneShot(m_AudioClip_Shot);
        m_magazine.ConsumeOneShot();

    }
    /// <summary>
    /// ��̃}�K�W�����ˏo����
    /// </summary>
    private void DropMagazine()
    {
        GameObject prefab = m_emptyMagazine;
        Vector3 position = m_emptyMagazineIA.transform.position;//��̃}�K�W���̐����ʒu���ꎞ�ϐ��ɑ��
        Quaternion rotation = m_emptyMagazineIA.transform.rotation;//��̃}�K�W���̐����p�x���ꎞ�ϐ��ɑ��
        Instantiate(prefab, position, rotation);//prefab���ƂɃC���X�^���X���쐬


    }
    public void DropButtonPushed()
    {

        DropMagazine();
    }
}
