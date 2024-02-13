using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerLbl;
    public float timer = 10;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            DisplayTime(timer);
        }
        else
        {
            Trainer.gameOver = true;
            timerLbl.text = "GAME OVVER";
        }
    }

    private void DisplayTime(float displayTime)
    {
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float second = Mathf.FloorToInt(displayTime % 60);
        timerLbl.text = $"{minutes} : {second}"; 
    }

}
