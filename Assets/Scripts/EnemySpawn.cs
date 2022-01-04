using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_2 : MonoBehaviour
{
    private void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            GameObject asteroidObj = ObjectPooler.singleTon.GetSpawnObj("Enemy");
            if (asteroidObj != null)
            {
                asteroidObj.transform.position = this.transform.position + new Vector3(Random.Range(-7.0f, 7.0f), 3f, 0);
                asteroidObj.SetActive(true);
            }

        }
    }

}


