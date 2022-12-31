using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{
    public int health;
    public int maxHealth=150;
    public int bleed = 3;
    private float bleedTimer;
    private AudioSource audioSource;
    public BackPack pBackPack;
    [SerializeField]
    private Image image;
    // private WolfSpawner wolfSpawner;
    // private bool gameover;
    // [SerializeField]
    // private Transform[] spawnPoints;
    private void Awake() {
        // wolfSpawner = GetComponent<WolfSpawner>();
        pBackPack = GameObject.FindWithTag("Player").GetComponent<BackPack>();
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        bleedTimer = Time.time + 1f;
    }
    private void Update() {
        if(Time.time>bleedTimer){
            health-=bleed;
            bleedTimer = Time.time + 1f;
        }
        CheckHealth();
    }
    public void TakeDamage(int damageAmount){
        health -= damageAmount;
        CheckHealth();
    }   
    void CheckHealth(){
        if(health<=0){
            health =0;
            // gameover = true;
            //TODO Gameover UI
            Destroy(gameObject);
            // wolfSpawner.DestroyWolfSpawner(gameover);
            GameOverController.instance.GameOver("You Lose!",image);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
         if(other.CompareTag("Player")){
            // if(other.GetComponent<BackPack>().currentStorage != 0)
            //     audioSource.Play();
            // health += other.GetComponent<BackPack>().TakeFruit();
            if(pBackPack.currentStorage!=0){
                audioSource.Play();
            }
            health+= pBackPack.TakeFruit();
            if(health>maxHealth)
                health=maxHealth;
         }
    }
}
