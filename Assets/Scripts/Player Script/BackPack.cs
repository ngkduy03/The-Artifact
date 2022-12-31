using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPack : MonoBehaviour
{
    [SerializeField]
    private Text bpackInfotxt;
    public int maxStorage = 100;
    public int currentStorage;
    private StringBuilder stringBuilder;
    private void Awake() {
        stringBuilder = new StringBuilder();
    }
    public void AddFuirts(int ammount){
        currentStorage += ammount;
        if(currentStorage>maxStorage)
            currentStorage = maxStorage;
        SetbpackInfoText(currentStorage);
    }
    public int TakeFruit(){
        int takenFruits = currentStorage;
        currentStorage = 0;
        SetbpackInfoText(currentStorage);
        return takenFruits;
    }
    void SetbpackInfoText(int ammount){
        // stringBuilder.Length=0; 
        // stringBuilder.Append("Backpack: ");
        // stringBuilder.Append(ammount);
        // stringBuilder.Append("/100");
        // bpackInfotxt.text = stringBuilder.ToString();
        bpackInfotxt.text = "Backpack: "+currentStorage+"/"+maxStorage;
        
    }
}
