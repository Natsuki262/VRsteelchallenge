using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class HandButtonController : MonoBehaviour
{
    //IAはインプットアクションの略
    [SerializeField]
    private InputActionProperty m_PrimaryIA;
    /// <summary>
    /// 手のInteractor
    /// Interactorとは、握る、触るができるコンポーネントのこと
    /// </summary>
    [SerializeField]
   private XRBaseControllerInteractor m_handInteractor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (IsPrimaryButtonPressed())
        {
            SendPButtonPressed();

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
    /// <summary>
    /// 銃に、プライマリーボタンが押されたことを、伝える
    /// Ｐはプライマリーの略
    /// </summary>
    public void SendPButtonPressed()
    {

        ///銃についてるグラブのスクリプトを取得
        IXRSelectInteractable gunInteractable = 
            m_handInteractor.interactablesSelected[0];

        //ハンドガンについてるオブジェクトのスクリプトを取得
        HandgunController handgunController = 
            gunInteractable.transform.GetComponent<HandgunController>();
        //ハンドガンスクリプトについてる、ボタンが押されたときに呼び出す関数を、呼び出し。
        handgunController.DropButtonPushed();


    }



}
