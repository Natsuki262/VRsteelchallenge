using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandgunController : MonoBehaviour
{
    /// <summary>
    /// 弾丸のPrefabオブジェクト
    /// </summary>
    [SerializeField]
    private GameObject m_bulletPrefab;
    /// <summary>
    /// 弾丸を生成する銃口の位置
    /// </summary>
    [SerializeField]
    private GameObject m_muzzle;
    /// <summary>
    /// マガジン挿入口のSocketInteractor
    /// SocketInteractorとはオブジェクトが、別のオブジェクトを
    /// 保持しておける、コンポーネントのこと
    /// </summary>
    [SerializeField]
    private XRSocketInteractor m_magazineSocket;
    /// <summary>
    /// マガジンを使用するために使うメンバー変数
    /// </summary>
    HandgunMagazine m_magazine = null;
    /// <summary>
    /// 射撃音のクリップ
    /// </summary>
    [SerializeField]
    private AudioClip m_AudioClip_Shot;
    /// <summary>
    /// 弾切れ時の音のクリップ
    /// </summary>
    [SerializeField]
    private AudioClip m_AudioClip_Enpty;
    /// <summary>
    /// オーディオクリップを流すための、オーディオソース
    /// </summary>
    [SerializeField]
    private AudioSource m_AudioSource;
    /// <summary>
    /// emptyMagazineのPrefab
    /// </summary>
    [SerializeField]
    private GameObject m_emptyMagazine;
    /// <summary>
    /// IAは InstantiateAreaの略
    ///空のマガジンの生成位置
    /// </summary>
    [SerializeField]
    private GameObject m_emptyMagazineIA;
    /// <summary>
    /// 銃に装着されてるダミーマガジンの、オブジェクト
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
    /// 銃口の位置から弾丸を生成
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
    /// マガジン挿入時
    /// </summary>
    public void MagazineSelected()
    {



        m_magazine = GetHandgunMagazineScript();

        if (m_magazine == null) return;


        m_magazine.gameObject.SetActive(false); //挿入したマガジンのオブジェクトを非アクティブにする


        m_magazineSocket.gameObject.SetActive(false); //ソケットの機能を非アクティブにする

        m_dummyMagazineObj.SetActive(true);  //ダミーのマガジンのモデルをアクティブ化する

    }
    /// <summary>
    /// 挿入されているハンドガンマガジンのスクリプト
    /// </summary>
    /// <returns>ハンドガンマガジンのスクリプト</returns>
    private HandgunMagazine GetHandgunMagazineScript()
    {
        ///マガジンについてるグラブのスクリプトを取得
        IXRSelectInteractable magazineInteractable = m_magazineSocket.interactablesSelected[0];

        return magazineInteractable.transform.GetComponent<HandgunMagazine>();
    }

    /// <summary>
    /// コントローラーのトリガーボタン押された時
    /// </summary>
    public void TriggerActivate()
    {
        //弾丸の生成条件のチェック
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
        //弾丸の生成をして音声を再生して終了
        BulletInstantiate();
        //m_AudioSource.clip = m_AudioClip_Shot;
        m_AudioSource.PlayOneShot(m_AudioClip_Shot);
        m_magazine.ConsumeOneShot();

    }


    /// <summary>
    /// 空のマガジンを射出する
    /// </summary>
    private void DropMagazine()
    {

        GameObject prefab = m_emptyMagazine;
        Vector3 position = m_emptyMagazineIA.transform.position;
        Quaternion rotation = m_emptyMagazineIA.transform.rotation;
        Instantiate(prefab, position, rotation);


    }
    /// <summary>
    /// コントローラーのボタンが押されたら、DropMagazine関数を呼び出す
    /// </summary>
    public void DropButtonPushed()
    {
        if (m_magazine == null) return;

        if (m_magazine.BulletCount >= 1)
        {
            //入ってるマガジンを射出
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
