using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Trainer : MonoBehaviour
{
    public GameObject targetPrefab;
    public List<GameObject> targets = new List<GameObject>();
    public static Trainer instance;
    public static bool gameOver;
    public static int targetHit = 1, targetMissed = 1, accuaracy;
    public Slider accuarencySlider;

    public Vector3 spawnAreaCenter;
    public Vector2 spawnAreaSize;


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
        accuarencySlider.value = targetHit * 100 / sum;

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
        if (targets.Count > 0)
        {
            int index = Random.Range(0, targets.Count);
            GameObject newTarget = Instantiate(targets[index], RandomSpawnPosition(), Quaternion.identity);
        }
    }

    Vector3 RandomSpawnPosition()
    {
        float x = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float z = Random.Range(spawnAreaCenter.z - spawnAreaSize.y / 2, spawnAreaCenter.z + spawnAreaSize.y / 2);
        return new Vector3(x, spawnAreaCenter.y, z);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnAreaCenter, new Vector3(spawnAreaSize.x, 0.1f, spawnAreaSize.y));
    }



}
