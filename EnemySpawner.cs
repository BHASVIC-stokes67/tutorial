using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyRef;
    private GameObject enemy;

    [SerializeField]
    private Transform left, right;

    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy ()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, enemyRef.Length);
            randomSide = Random.Range(0, 2);

            enemy = Instantiate(enemyRef[randomIndex]);
            if (randomSide == 0)
            {
                enemy.transform.position = left.position;
                enemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }
            else
            {
                enemy.transform.position = right.position;
                enemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
