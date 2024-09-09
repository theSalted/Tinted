using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    // Glasses Object
    [SerializeField] private GameObject glasses;
    // Player obtained glasses
    public bool hasGlasses = false;
    
    public int state = 0;

    #region singleton
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogWarning("Instance already exists, destroying object!");
            Destroy(this.gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasGlasses)
        {
            glasses.SetActive(true);
        }
        else
        {
            glasses.SetActive(false);
        }
    }
}
