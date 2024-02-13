using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Trainer : MonoBehaviour
{
    public float num1 = -5;
    public float num2 = 5;
    public GameObject targetPrefab;
    public static Trainer instance;
    public static bool gameOver;
    public static int targetHit = 1, targetMissed = 1, accuaracy;
    public Slider accuarencySlider;

    public TextMeshProUGUI targetHitLbl, targetMissdeLbl, accuaryLbl;
    private void Start()
    {
        SpawnTarget();
        gameOver = false;
        instance = this;

    }

    private void Update()
    {
        int sum = targetHit + targetMissed;
        accuarencySlider.value = targetHit * 1 / sum;

        targetHitLbl.text = "Targets Hit " + targetHit;
        targetMissdeLbl.text = "targets Missed " + targetMissed;
        accuaryLbl.text = "Accuaracy " + accuarencySlider.value + "%";

        if (gameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }

    }

    public void SpawnTarget()
    {

  
        Vector3 randomSpawn = new Vector3(Random.Range(num1, num2), 5, Random.Range(num1, num2));
        Instantiate(targetPrefab, randomSpawn, Quaternion.identity);
    }



}
