using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandButtonController : MonoBehaviour
{
    //IAはインプットアクションの略
    [SerializeField]
    private InputActionProperty m_PrimaryIA;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (IsPrimaryButtonPressed())
        {
            ;

        }

    }
    private bool IsPrimaryButtonPressed()
    {
        float button = m_PrimaryIA.action.ReadValue<float>();
        if (button >= InputSystem.settings.defaultButtonPressPoint)
        {
            Debug.Log(button + "hit");
            return true;
        }
        else
        {
            return false;
        }
    }
    public void GripSelected()
    {

        ///マガジンについてるグラブのスクリプトを取得
        IXRSelectInteractable magazineInteractable = m_magazineSocket.interactablesSelected[0];
        //ソケットに入れられたオブジェクトのスクリプトを取得
        m_magazine = magazineInteractable.transform.GetComponent<HandgunMagazine>();

    }



}
