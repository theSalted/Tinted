using UnityEngine;

public class LensController : MonoBehaviour
{
    public Material lensMaterial; // Material with the LensColorFilter shader
    public Color redFilterColor = new Color(1f, 0f, 0f, 1f);  // Red filter color
    public Color blueFilterColor = new Color(0f, 0f, 1f, 1f); // Blue filter color
    public float transitionSpeed = 2.0f; // Speed of transition between colors
    // public float maxBlendAmount = 0.5f; // Maximum blend amount
    private bool isRedFilter = true; // Start with the red filter
    private float blendAmount = 0.5f; // Blend amount for smooth transition
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Switch filters with the space key
        {
            isRedFilter = !isRedFilter; // Toggle filter
            Debug.Log("Switching to " + (isRedFilter ? "Red" : "Blue") + " filter");
        }

        // Smooth transition between filters
        Color targetColor = isRedFilter ? redFilterColor : blueFilterColor;
        lensMaterial.SetColor("_FilterColor", targetColor);

        // // Adjust blend amount smoothly
        // if (isRedFilter && blendAmount < maxBlendAmount)
        // {
        //     blendAmount += Time.deltaTime * transitionSpeed;
        // }
        // else if (!isRedFilter && blendAmount > 0f)
        // {
        //     blendAmount -= Time.deltaTime * transitionSpeed;
        // }

        // Clamp blendAmount between 0 and 1
        blendAmount = Mathf.Clamp01(blendAmount);
        lensMaterial.SetFloat("_BlendAmount", blendAmount);
    }
}
