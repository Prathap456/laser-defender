using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            GameObject asteroid = ObjectPooler.singleTon.GetSpawnObj("Enemy");
            if (asteroid != null)
            {
                asteroid.transform.position = this.transform.position + new Vector3(Random.Range(-7.0f, 7.0f), 3f, 0);
                asteroid.SetActive(true);
            }

        }
    }

}


