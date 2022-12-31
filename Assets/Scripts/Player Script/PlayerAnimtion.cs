using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimtion : MonoBehaviour
{
    [SerializeField]
    private Sprite[] animSprites;
    public float timeTreshold = 0.1f;
    private uint state = 0;
    private float timer ;
    private SpriteRenderer sr;
    private bool isMoving;
    
    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update() 
    {
        if(isMoving)
        {
            if(Time.time > timer)
            {
                sr.sprite = animSprites[state % animSprites.Length];
                state++;
                timer = Time.time + timeTreshold;
            }
        }
    }
    public void setAnim(bool i_isMoving){
        isMoving = i_isMoving;  
    }
}
