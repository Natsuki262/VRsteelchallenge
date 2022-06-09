using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandgunController : MonoBehaviour
{
    /// <summary>弾丸のPrefab</summary>
    [SerializeField]
    private GameObject m_bulletPrefab;
    /// <summary>銃口の位置</summary>
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
        GameObject prefab = m_bulletPrefab;//prefabを一時変数に代入
        Vector3 position = m_muzzle.transform.position;//銃口の位置を一時変数に代入
        Quaternion rotation = m_muzzle.transform.rotation;//銃口の角度を一時変数に代入
        Instantiate(prefab, position, rotation);//prefabもとにインスタンス生成

    }
    /// <summary>
    /// マガジン挿入時
    /// </summary>
    public void MagazineSelected()
    {


        //メンバー変数に、マガジンのスクリプトを代入 
        m_magazine = GetHandgunMagazineScript();

        if (m_magazine == null) return;

        //挿入したマガジンのオブジェクトを非アクティブにする
        m_magazine.gameObject.SetActive(false);
        //ダミーのマガジンのモデルをアクティブ化する

        //ソケットの機能を非アクティブにする

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
    /// トリガー
    /// </summary>
    public void TriggerActivate()
    {
        //マガジンが装填されてなければ
        if (m_magazine == null)
        {
            m_AudioSource.PlayOneShot(m_AudioClip_Enpty);
            return;
        }
        //残弾数が零なら発砲させない
        if (m_magazine.BulletCount <= 0)
        {
            m_AudioSource.PlayOneShot(m_AudioClip_Enpty);
            return;
        }
        //発砲条件が満たしてる時
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
        Vector3 position = m_emptyMagazineIA.transform.position;//空のマガジンの生成位置を一時変数に代入
        Quaternion rotation = m_emptyMagazineIA.transform.rotation;//空のマガジンの生成角度を一時変数に代入
        Instantiate(prefab, position, rotation);//prefabもとにインスタンスを作成


    }
    public void DropButtonPushed()
    {

        DropMagazine();
    }
}
