using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float maxX;

    public GameObject[] candies;

    public float spawnInterval;

    public static CandySpawner instance;

    private void Awake()
    {
        if(instance == null)
         instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawningCandies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCandy() { 

        int rand = Random.Range(0, candies.Length);

        float randomX = Random.Range(-maxX, maxX);

        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(candies[rand], randomPos, transform.rotation);
    }

    IEnumerator SpawnCandies() { 
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnCandy();
            spawnInterval -= 0.005f;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }
    public void StopSpawningCandies()
    {
        print("STOP");
        StopCoroutine("SpawnCandies");
    }
}
