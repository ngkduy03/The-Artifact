using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    private Rigidbody2D myBody;
    private Vector2 moveVector;
    private SpriteRenderer sr;
    private float harvestTimer;
    private bool isHarvesting = false;
    private GameObject artifact;
    private PlayerAnimtion pAnimationClass;
    
    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pAnimationClass = GetComponent<PlayerAnimtion>();
        
    }
    private void FixedUpdate() 
    {
        Moving();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > harvestTimer)
            isHarvesting = false;
        FlipSprite();
        isMoving();

    }

    void FlipSprite(){
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
    }
    void Moving()
    {
     if(isHarvesting)
        myBody.velocity = Vector2.zero;
     else
     {
        moveVector = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if(moveVector.sqrMagnitude > 1)
            moveVector = moveVector.normalized;
        myBody.velocity = new Vector2(moveVector.x*moveSpeed,moveVector.y*moveSpeed);        
     } 
    }
    public void isMoving()
    {
        if(moveVector.sqrMagnitude != 0)
            pAnimationClass.setAnim(true);
        else
            pAnimationClass.setAnim(false);
    }
    public void StopMoving(float time){
        isHarvesting=true;
        harvestTimer = Time.time +time;
    }
    public bool IsHarvesting(){
        return isHarvesting;
    }
}
