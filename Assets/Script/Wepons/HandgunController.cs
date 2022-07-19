using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandgunController : MonoBehaviour
{
    /// <summary>
    /// �e�ۂ�Prefab�I�u�W�F�N�g
    /// </summary>
    [SerializeField]
    private GameObject m_bulletPrefab;
    /// <summary>
    /// �e�ۂ𐶐�����e���̈ʒu
    /// </summary>
    [SerializeField]
    private GameObject m_muzzle;
    /// <summary>
    /// �}�K�W���}������SocketInteractor
    /// SocketInteractor�Ƃ̓I�u�W�F�N�g���A�ʂ̃I�u�W�F�N�g��
    /// �ێ����Ă�����A�R���|�[�l���g�̂���
    /// </summary>
    [SerializeField]
    private XRSocketInteractor m_magazineSocket;
    /// <summary>
    /// �}�K�W�����g�p���邽�߂Ɏg�������o�[�ϐ�
    /// </summary>
    HandgunMagazine m_magazine = null;
    /// <summary>
    /// �ˌ����̃N���b�v
    /// </summary>
    [SerializeField]
    private AudioClip m_AudioClip_Shot;
    /// <summary>
    /// �e�؂ꎞ�̉��̃N���b�v
    /// </summary>
    [SerializeField]
    private AudioClip m_AudioClip_Enpty;
    /// <summary>
    /// �I�[�f�B�I�N���b�v�𗬂����߂́A�I�[�f�B�I�\�[�X
    /// </summary>
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
    /// <summary>
    /// �e�ɑ�������Ă�_�~�[�}�K�W���́A�I�u�W�F�N�g
    /// </summary>
    [SerializeField]
    private GameObject m_dummyMagazineObj;
    [SerializeField]
    private Animator m_animator;

    [SerializeField]
    private ObjPoolCtr m_objPoolCtr;
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
        GameObject obj = m_objPoolCtr.GetPoolObj();
        if (obj == null) { return; }
        obj.transform.position = m_muzzle.transform.position;
        obj.transform.rotation = m_muzzle.transform.rotation;
        obj.SetActive(true);
        BulletBace bulletBace = obj.GetComponent<BulletBace>();
        bulletBace.TrailClear();


        /*GameObject prefab = m_bulletPrefab;
        Vector3 position = m_muzzle.transform.position;
        Quaternion rotation = m_muzzle.transform.rotation;
        Instantiate(prefab, position, rotation);*/


    }
    /// <summary>
    /// �}�K�W���}����
    /// </summary>
    public void MagazineSelected()
    {



        m_magazine = GetHandgunMagazineScript();

        if (m_magazine == null) return;


        m_magazine.gameObject.SetActive(false); //�}�������}�K�W���̃I�u�W�F�N�g���A�N�e�B�u�ɂ���


        m_magazineSocket.gameObject.SetActive(false); //�\�P�b�g�̋@�\���A�N�e�B�u�ɂ���

        m_dummyMagazineObj.SetActive(true);  //�_�~�[�̃}�K�W���̃��f�����A�N�e�B�u������

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
    /// �R���g���[���[�̃g���K�[�{�^�������ꂽ��
    /// </summary>
    public void TriggerActivate()
    {
        //�e�ۂ̐��������̃`�F�b�N
        if (m_magazine == null)
        {
            m_AudioSource.PlayOneShot(m_AudioClip_Enpty);
            return;
        }
        if (m_magazine.BulletCount <= 0)
        {
            m_AudioSource.PlayOneShot(m_AudioClip_Enpty);
            return;
        }
        //�e�ۂ̐��������ĉ������Đ����ďI��
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
        Vector3 position = m_emptyMagazineIA.transform.position;
        Quaternion rotation = m_emptyMagazineIA.transform.rotation;
        Instantiate(prefab, position, rotation);


    }
    /// <summary>
    /// �R���g���[���[�̃{�^���������ꂽ��ADropMagazine�֐����Ăяo��
    /// </summary>
    public void DropButtonPushed()
    {
        if (m_magazine == null) return;

        if (m_magazine.BulletCount >= 1)
        {
            //�����Ă�}�K�W�����ˏo
            m_magazine.gameObject.SetActive(true);
        }
        else
        {
            Destroy(m_magazine.gameObject);
            DropMagazine();
        }

        m_magazineSocket.gameObject.SetActive(true);
        m_dummyMagazineObj.SetActive(false);
        m_magazine = null;
    }
    public void Animation()
    {
        m_animator.SetTrigger("Trigger");
    }


}
