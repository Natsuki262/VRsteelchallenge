using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiotest : MonoBehaviour
{

    [SerializeField]
   private AudioSource m_audiosource;
   
    //AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        //m_audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_audiosource.Play();
        }
    }
}
