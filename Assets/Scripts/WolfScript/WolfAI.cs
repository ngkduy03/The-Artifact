using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour
{
    [SerializeField]
    private bool isEarter;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private int atkDamage = 5;
    [SerializeField]
    private float atkTimeTreshold = 1f;
    [SerializeField]
    private float eatTimeTreshold = 2f;
    [SerializeField]
    private LayerMask bushMask;
    [HideInInspector]
    public bool isMoving, left;
    private Artifact artifact;
    private BushFruits bushFruitsTarget;
    private float atkTimer;
    private float eatTimer;
    private bool eatingBush;
    private bool isAttacking;
    private void Awake() {
        artifact=GameObject.FindWithTag("Artifact").GetComponent<Artifact>();     
        moveSpeed = Random.Range(0.8f,1.6f);   
    }
    private void Start() {
        if(isEarter )
        {
            SearchForTarget();
            eatingBush = false;
        }
        else{
           isAttacking = false;
        }
        
    }
    private void Update() {
        if(!artifact)
            return;
        if(isEarter){
            if(eatingBush)
            {
                if(Time.time > eatTimer){
                    bushFruitsTarget.HarvestFruits();
                    bushFruitsTarget.EatBushFruits();
                    eatTimer = Time.time + eatTimeTreshold;
                    eatingBush = false;
                }
            } 
            else 
            {
                SearchForTarget();
                if(
                    bushFruitsTarget && 
                    bushFruitsTarget.enabled && 
                    bushFruitsTarget.HasFruits() && 
                    !eatingBush 
                ){

                    if(Vector2.Distance(transform.position,bushFruitsTarget.transform.position)>0.5f){
                        isMoving=true;
                        if(transform.position.x>bushFruitsTarget.transform.position.x)
                            left = true;
                        else
                            left = false;

                        float step = moveSpeed*Time.deltaTime;
                        transform.position = Vector2.MoveTowards(transform.position,
                        bushFruitsTarget.transform.position,step);
                        
                    }  
                    else {//if(Vector2.Distance(transform.position,bushFruitsTarget.transform.position)<=0.5f){
                            eatingBush = true;
                            isMoving = false;
                    }  
                }
                else
                    isMoving = false;
            }
            }
            else{
                if(Vector2.Distance(transform.position,artifact.transform.position)>1.5f){
                    isMoving = true;
                    if(transform.position.x>artifact.transform.position.x)
                        left = true;
                    else
                        left = false;
                        

                    float step = moveSpeed*Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position,
                    artifact.transform.position,step);

                }
                else if(isAttacking){
                    if(Time.time>atkTimer){
                        atkTimer = Time.time +atkTimeTreshold;
                        Attack();
                    }
                }
                if(Vector2.Distance(transform.position,artifact.transform.position)<=1.5f){
                    isAttacking = true;
                    isMoving = false;
                }
        }
    }
    private void SearchForTarget(){
        Collider2D[] hits;
        bushFruitsTarget = null;
        for(int i = 0; i < 50; i++){
            hits = Physics2D.OverlapCircleAll(transform.position, Mathf.Exp(i), bushMask);
            foreach(Collider2D hit in hits){
                if(hit && hit.GetComponent<BushFruits>().enabled 
                && hit.GetComponent<BushFruits>().HasFruits()){
                    bushFruitsTarget = hit.GetComponent <BushFruits>();
                    break;
                }
            }
            if(bushFruitsTarget)
                break;
        }
    }
    void Attack(){
        artifact.TakeDamage(atkDamage); 
    }
}
