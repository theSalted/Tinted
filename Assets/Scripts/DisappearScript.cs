using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    // game object
    [SerializeField] private GameObject blockObject;
    [SerializeField] private int stencilRef = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.instance.state == stencilRef)
        {
            StartCoroutine(DoorOff(1.0f));
        } else
        {
            blockObject.SetActive(true);
        }
    }

    IEnumerator DoorOff(float delay)
    {
        // loop over 10 tmes
        for (int i = 0; i < 10; i++)
        {
            if (PlayerManager.instance.state != stencilRef)
            {
                break;
            }
            yield return new WaitForSeconds(delay/10);
        }
        if (PlayerManager.instance.state == stencilRef)
        {
            blockObject.SetActive(false);
        }
    }
}
