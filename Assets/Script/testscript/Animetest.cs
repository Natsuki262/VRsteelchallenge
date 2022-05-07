using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animetest : MonoBehaviour
{
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        anime=gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            anime.SetBool("HandControler",true);
        }
    }
}
