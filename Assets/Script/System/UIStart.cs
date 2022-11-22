using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIStart : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void OnPushbutton()
    {
        SceneManager.LoadScene("CyberHero");
    }
}
