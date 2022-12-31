using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAnim : MonoBehaviour
{
    [SerializeField]
    private Sprite[] shootSprite;
    [SerializeField]
    private float timeTreshold = 0.06f;
    [SerializeField]
    private int atkDamage = 80;
    private float timer;
    private int state =0;
    private SpriteRenderer sr;
    public AudioSource audioSource;
    public static ShootAnim instance;
    private void Awake() {
         if(instance==null)
            instance = this;
        sr=GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>timer){
            if(state==shootSprite.Length){
                Destroy(gameObject);
                return;
            }
            else{
                sr.sprite = shootSprite[state];
                state++;
                timer = Time.time + timeTreshold;
            }
        }
    }
    public void PlaySound(){
       audioSource.Play();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Wolf"))
        {
            other.GetComponent<WoflHealth>().TakeDamage(atkDamage);
        }
    }
}
