using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisual : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bushSpr,fruitSpr,drySpr;
    [SerializeField]
    private SpriteRenderer[] fruitsRenderer;
    public enum BushVariant {Green,Cyan,Yellow}
    private BushVariant bushVariant;
    public float hideTimePerFruit = 0.2f;
    public SpriteRenderer sr;
    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();
        bushVariant = (BushVariant)Random.Range(0,bushSpr.Length);
        sr.sprite = bushSpr[(int)bushVariant];    
        if(Random.Range(0,2) == 1)
        sr.flipX=true;
        for(int i =0; i < fruitsRenderer.Length;i++)
        {
            fruitsRenderer[i].sprite = fruitSpr[(int)bushVariant];
            fruitsRenderer[i].enabled = false; 
        }
   }
    public BushVariant GetBushVariant(){
        return bushVariant;
    }
    public void SetToDry()
    {
        sr.sprite = drySpr[(int)bushVariant];
    }
    IEnumerator _HideFruits(float time, int index)
    {
        yield return new WaitForSeconds(time);
        fruitsRenderer[index].enabled=false;
    }
    public void HideFruits(){
        float waitTime = hideTimePerFruit;
        for(int i =0; i < fruitsRenderer.Length; i++)
        {
            StartCoroutine(_HideFruits(waitTime,i));
            waitTime+=hideTimePerFruit;
        }
    }
    public void ShowFruits(){
        for(int i = 0; i<fruitsRenderer.Length;i++){
            fruitsRenderer[i].enabled=true;
        }
    }
    
}
