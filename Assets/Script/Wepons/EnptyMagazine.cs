using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnptyMagazine : MonoBehaviour
{
    const float MAGAZINE_DESTROY_TIME = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,MAGAZINE_DESTROY_TIME);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
