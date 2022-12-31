using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    public float timeToWin = 300f;
    private bool gameover;
    private GameObject artifact;
    private StringBuilder stringBuilder;
    [SerializeField]
    private Image image;
    // private WolfSpawner wolfSpawner;
    // [SerializeField]
    // private Transform[] spawnPoints;

    private void Awake() {
        // wolfSpawner = GetComponent<WolfSpawner>();
        artifact=GameObject.FindWithTag("Artifact");
        stringBuilder = new StringBuilder();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameover || !artifact)
            return;
        timeToWin -= Time.deltaTime;
        if(timeToWin<=0)
        {
            timeToWin = 0;
            gameover = true;
            Destroy(artifact);
            // wolfSpawner.DestroyWolfSpawner(gameover);
            //TODO show win panel
            GameOverController.instance.GameOver("You Win!",image);

        }
        // timerText.text="Time Remaining: "+(int)timeToWin;
        DisplayTime((int)timeToWin);
    }
    void DisplayTime(int time){

        //* reset string builder
        stringBuilder.Length=0; 
        stringBuilder.Append("Time Remaining: ").Append(time);
        timerText.text = stringBuilder.ToString();    
    }
}
