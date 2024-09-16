using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // Animator
    private Animator animator;
    public GameObject player;
    public float delectionDistance = 7.0f;
    public float collectDistance = 1.0f;
    public string collectibleName;
    private bool isFloat = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the animator to the animator component of the collectible
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is close enough to the collectible, make it float
        if (Vector3.Distance(player.transform.position, transform.position) < delectionDistance)
        {
            isFloat = true;
        }
        else
        {
            isFloat = false;
        }
        animator.SetBool("Float", isFloat);

        if (Vector3.Distance(player.transform.position, transform.position) < collectDistance)
        {
            PlayerManager.instance.inventory.Add(collectibleName);
            // Collect the collectible
            Destroy(gameObject);
        }
    }
}
