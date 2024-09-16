using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensesController : MonoBehaviour
{
    // Animator
    public Animator monocleAnimator;
    public Animator magnifierAnimator;
    public GameObject monocleUI;
    public GameObject magnifierUI;

    private int monocleState = 0;
    private int magnifierState = 0;
    bool hasMonocle = false;
    bool hasMagnifier = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hasMonocle = PlayerManager.instance.inventory.Contains("Monocle");
        hasMagnifier = PlayerManager.instance.inventory.Contains("Magnifier");
        // Hold right click to use monocle (State = 2)
        // Hold left click to use magnifier (State = 2)
        // Hold both right and left click to use both (State = 1)
        // Release both right and left click to stop using both (State = 0)
        if (hasMonocle && Input.GetMouseButton(1) && hasMagnifier && Input.GetMouseButton(0))
        {
            monocleState = 1;
            magnifierState = 1;
        }
        else if (hasMonocle && Input.GetMouseButton(1))
        {
            monocleState = 2;
            magnifierState = 0;
        }
        else if (hasMagnifier && Input.GetMouseButton(0))
        {
            monocleState = 0;
            magnifierState = 2;
        }
        else
        {
            monocleState = 0;
            magnifierState = 0;
        }

        if (hasMonocle)
        {
            monocleUI.SetActive(true);
        }
        else
        {
            monocleUI.SetActive(false);
        }

        if (hasMagnifier)
        {
            magnifierUI.SetActive(true);
        }
        else
        {
            magnifierUI.SetActive(false);
        }

        monocleAnimator.SetInteger("State", monocleState);
        magnifierAnimator.SetInteger("State", magnifierState);
    }
}
