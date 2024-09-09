using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    // game object
    [SerializeField] private GameObject glasses;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.instance.state == 1)
        {
            glasses.SetActive(false);
        } else
        {
            glasses.SetActive(true);
        }
    }
}
