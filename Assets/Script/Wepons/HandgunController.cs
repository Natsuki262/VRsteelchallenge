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
    public void BulletInstantiate()
    {
        GameObject prefab = m_bulletPrefab;//prefabを一時変数に代入
        Vector3 position=m_muzzle.transform.position;//銃口の位置を一時変数に代入
        Quaternion rotation=m_muzzle.transform.rotation;//銃口の角度を一時変数に代入
        Instantiate(prefab, position, rotation);//prefabもとにインスタンス生成
    }
    public void MagazineSelected()
    {
        HandgunMagazine magazine = null;
        ///マガジンについてるグラブのスクリプトを取得
        IXRSelectInteractable magazineInteractable = m_magazineSocket.interactablesSelected[0];
        //ソケットに入れられたオブジェクトソケットに入れられたオブジェクトのスクリプトを取得
        magazine = magazineInteractable.transform.GetComponent<HandgunMagazine>();
        

    }

}
