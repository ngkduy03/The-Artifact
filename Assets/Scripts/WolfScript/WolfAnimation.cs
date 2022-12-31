using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : MonoBehaviour
{
   [SerializeField]
   private Sprite[] wolfAnimSpr;
   [SerializeField]
   private float timeTreshold = 0.15f;
   private int state =0;
   private SpriteRenderer sr;
   private float timer;
   private WolfAI wolfAI;
   private void Awake() {
    sr= GetComponent<SpriteRenderer>();
    wolfAI = GetComponent<WolfAI>();

   }
   private void Update() {
    if(wolfAI.isMoving){
        if(Time.time > timer)
            {
                sr.sprite = wolfAnimSpr[state % wolfAnimSpr.Length];
                state++;
                timer = Time.time + timeTreshold;
            }
    }
    else{
        sr.sprite=wolfAnimSpr[0];
    }
    sr.flipX=wolfAI.left;
   }

}
