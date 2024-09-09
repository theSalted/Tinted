using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Detect input 'e'
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerManager.instance.hasGlasses = true;
            // disable this object
            gameObject.SetActive(false);
        }
    }
}
