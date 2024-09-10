using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlassesController : MonoBehaviour
{
    // animator
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // get the animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the input 1, 2, 3
        if (Keyboard.current[Key.Digit1].wasPressedThisFrame)
        {
            animator.SetInteger("State", 1);
            PlayerManager.instance.state = 1;
        }
        if (Keyboard.current[Key.Digit2].wasPressedThisFrame)
        {
            animator.SetInteger("State", 2);
            PlayerManager.instance.state = 2;
        }
        if (Keyboard.current[Key.Digit3].wasPressedThisFrame)
        {
            animator.SetInteger("State", 3);
            PlayerManager.instance.state = 3;
        }
        if (Keyboard.current[Key.Tab].wasPressedThisFrame)
        {
            animator.SetInteger("State", 0);
            PlayerManager.instance.state = 0;
        }
    }
}
