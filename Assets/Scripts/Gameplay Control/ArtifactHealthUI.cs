using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactHealthUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Artifact artifact;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = artifact.maxHealth;
        healthSlider.value = artifact.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = artifact.health;
    }
}
