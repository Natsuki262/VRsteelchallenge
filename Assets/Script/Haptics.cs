using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//�K�{�R���|�[�l���g
[RequireComponent(typeof(XRGrabInteractable))]
public class Haptics : MonoBehaviour
{
    //inspector����ݒ肷��p�����[�^
    [Header("Trigger haptics Prameters")]
    [SerializeField] float triggerAmplitude;//�U��
    [SerializeField] float trigeerDuration = 0.2f;//��������

    //�R���|�[�l���g���L�������ꂽ�Ƃ��Ɏ��s
    private void OnEnable()
    {
            //GameObject�ɐݒ肳��Ă�XRGrabInteractable�R���|�[�l���g���擾
            XRGrabInteractable interactable=GetComponent<XRGrabInteractable>();
        //Activate Action�������Ɏ��s���鏈����ǉ�
        interactable.activated.AddListener(PullTrigger);
    }
    //Activate Action(�g���K�[�����������Ɏ��s���鏈��
    private void PullTrigger(ActivateEventArgs arg)
    {
        //�C�x���g��������XRbaceController�ɐU��������B
        arg.interactor.GetComponent<XRBaseController>().SendHapticImpulse(triggerAmplitude, trigeerDuration);
    }

}
