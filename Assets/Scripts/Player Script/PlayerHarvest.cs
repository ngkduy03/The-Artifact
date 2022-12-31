using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest :  MonoBehaviour
{
    [SerializeField]
    private float harvestTime = 0.4f;
    private PlayerMovement pMove;
    private BackPack backPack;
    private AudioSource audioSource;
    private Collider2D collideBush;
    private BushFruits hitBush;
    private bool canHarvest;
    private void Awake() {
        pMove = GetComponent<PlayerMovement>();
        backPack = GetComponent<BackPack>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TryToHarvest();
        }
    }
    void TryToHarvest(){
        if(!canHarvest)
            return;
        if(collideBush != null)
        {
            hitBush = collideBush.GetComponent<BushFruits>();
            if(hitBush.HasFruits())
            {
                // audioSource.Play();
                pMove.StopMoving(harvestTime);
                backPack.AddFuirts(hitBush.HarvestFruits()); 
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bush")){
            canHarvest = true;
            collideBush = other;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
         if(other.CompareTag("Bush")){
            canHarvest = false;
            collideBush = null;
        }
    }
}
