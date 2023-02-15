using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platform;
    public Transform lastPlatform;
    Vector3 lastPos;
    Vector3 newPos;

    bool stop;

    public PowerUps powerUps;

    private int platformCounter;
    private int powerUpSpawnTime;
    // Start is called before the first frame update
    void Start()
    {

        lastPos = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePosition()
    {
        newPos = lastPos;

        int rand = Random.Range(0, 2);
        if (rand > 0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }
    }

    private void SpawnPowerUp()
    {
        int randomIndex = Random.Range(0, powerUps.randomSpawn.Length);
        powerUpSpawnTime = powerUps.randomSpawn[randomIndex];
        if(platformCounter % powerUpSpawnTime == 0)
        {
            Vector3 powerPos = new Vector3(newPos.x, newPos.y + 1f, newPos.z);
            powerUps.SpawnPowerUp(powerPos);
        }
    }



    IEnumerator SpawnPlatforms()
    {
        while(!stop)
        {
            GeneratePosition();
            Instantiate(platform, newPos, Quaternion.identity);
            platformCounter++;
            SpawnPowerUp();
            lastPos = newPos;
            yield return new WaitForSeconds(0.1f);
        }

    }
}
