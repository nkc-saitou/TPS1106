using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour {

    public GameObject enemyPre;

    [Range(1.0f,5.0f)]
    public float enemyWaitTime;

    int randomPattern;

    int enemyPosZ;

	void Start ()
    {
        StartCoroutine(EnemyCreateTime());
    }
	
	void Update ()
    {
	}

    void RandomSpawnEnemy()
    {
        switch(randomPattern = Random.Range(1,3))
        {
            case 1:
                enemyPosZ = 20;
                CreateEnemy(enemyPosZ);
                break;

            case 2:
                enemyPosZ = -20;
                CreateEnemy(enemyPosZ);
                break;
        }
    }

    void CreateEnemy(int PosZ)
    {
        Instantiate(enemyPre, new Vector3(Random.Range(-20,20),enemyPre.gameObject.transform.position.y, PosZ), Quaternion.identity);
    }

    IEnumerator EnemyCreateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyWaitTime);
            RandomSpawnEnemy();
        }
    }
}
