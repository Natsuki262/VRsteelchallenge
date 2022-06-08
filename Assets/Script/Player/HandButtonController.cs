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
        IsPrimaryButtonPressed();
    }
    private bool IsPrimaryButtonPressed()
    {
        float button = m_PrimaryIA.action.ReadValue<float>();
        Debug.Log(button);
        if (button >= InputSystem.settings.defaultButtonPressPoint)
        {
            Debug.Log("hit");
            return true;
        }
        else
        {
            Debug.Log("ぬるぽ");
            return false;

        }
    }

}
