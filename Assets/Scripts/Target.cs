using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyTarget());
    }

    IEnumerator DestroyTarget()
    {
        yield return new WaitForSeconds(2);
        Trainer.targetMissed = Trainer.targetMissed + 1;
        if (Trainer.gameOver == false)
        {
            Trainer.instance.SpawnTarget();
        }
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Trainer.targetHit = Trainer.targetHit + 1;
        Destroy(gameObject);
        if(Trainer.gameOver == false)
        {
            Trainer.instance.SpawnTarget();
        }
    }

}
