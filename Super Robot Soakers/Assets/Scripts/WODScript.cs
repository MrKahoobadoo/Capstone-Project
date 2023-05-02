using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WODScript : MonoBehaviour
{
    public PostProcessProfile postProcessProfile;
    public float bloomThreshold = 0f;

    private Bloom bloom;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Bloom settings from the profile
        if (!postProcessProfile.TryGetSettings(out bloom))
        {
            Debug.LogError("Bloom settings not found!");
            enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Modify the threshold value
        bloom.threshold.value = bloomThreshold;

        // Assign the updated profile back to the post-processing volume or layer
        postProcessProfile.TryGetSettings(out bloom);
    }
}
