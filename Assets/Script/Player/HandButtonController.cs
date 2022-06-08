using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandButtonController : MonoBehaviour
{
    //IA�̓C���v�b�g�A�N�V�����̗�
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

        ///�}�K�W���ɂ��Ă�O���u�̃X�N���v�g���擾
        IXRSelectInteractable magazineInteractable = m_magazineSocket.interactablesSelected[0];
        //�\�P�b�g�ɓ����ꂽ�I�u�W�F�N�g�̃X�N���v�g���擾
        m_magazine = magazineInteractable.transform.GetComponent<HandgunMagazine>();

    }



}
