using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoflHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject healthUI;
    private float scale;
    [SerializeField]
    private int maxHealth;
    private int currentHealth; 
     private void Awake() {
        maxHealth = Random.Range(50,250);
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount){
        currentHealth -= amount;
        scale = (float)currentHealth/maxHealth;
        healthUI.transform.localScale = new Vector3(scale,healthUI.transform.localScale.y,1f);
        if(currentHealth <= 0)
            Destroy(gameObject);
    }
    
}
