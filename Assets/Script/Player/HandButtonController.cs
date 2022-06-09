using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class HandButtonController : MonoBehaviour
{
    //IA�̓C���v�b�g�A�N�V�����̗�
    [SerializeField]
    private InputActionProperty m_PrimaryIA;
    /// <summary>
    /// ���Interactor
    /// Interactor�Ƃ́A����A�G�邪�ł���R���|�[�l���g�̂���
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
    /// �e�ɁA�v���C�}���[�{�^���������ꂽ���Ƃ��A�`����
    /// �o�̓v���C�}���[�̗�
    /// </summary>
    public void SendPButtonPressed()
    {

        ///�e�ɂ��Ă�O���u�̃X�N���v�g���擾
        IXRSelectInteractable gunInteractable = 
            m_handInteractor.interactablesSelected[0];

        //�n���h�K���ɂ��Ă�I�u�W�F�N�g�̃X�N���v�g���擾
        HandgunController handgunController = 
            gunInteractable.transform.GetComponent<HandgunController>();
        //�n���h�K���X�N���v�g�ɂ��Ă�A�{�^���������ꂽ�Ƃ��ɌĂяo���֐����A�Ăяo���B
        handgunController.DropButtonPushed();


    }



}
