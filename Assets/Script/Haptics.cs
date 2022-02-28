using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//必須コンポーネント
[RequireComponent(typeof(XRGrabInteractable))]
public class Haptics : MonoBehaviour
{
    //inspectorから設定するパラメータ
    [Header("Trigger haptics Prameters")]
    [SerializeField] float triggerAmplitude;//振幅
    [SerializeField] float trigeerDuration = 0.2f;//持続時間

    //コンポーネントが有効化されたときに実行
    private void OnEnable()
    {
            //GameObjectに設定されてるXRGrabInteractableコンポーネントを取得
            XRGrabInteractable interactable=GetComponent<XRGrabInteractable>();
        //Activate Action発生時に実行する処理を追加
        interactable.activated.AddListener(PullTrigger);
    }
    //Activate Action(トリガー押下発生時に実行する処理
    private void PullTrigger(ActivateEventArgs arg)
    {
        //イベント発生元のXRbaceControllerに振動させる。
        arg.interactor.GetComponent<XRBaseController>().SendHapticImpulse(triggerAmplitude, trigeerDuration);
    }

}
