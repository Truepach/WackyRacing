using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject[] _powerUps;
    private int[] _randomSpawn = { 6, 7, 8, 9, 10, 11, 12 };




    public int[] randomSpawn //ENCAPSULATION
    {
        get { return _randomSpawn; }
        set { _randomSpawn = value; }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPowerUp(Vector3 platformPosition)
    {
        Quaternion rotation = Quaternion.Euler(90, 0, 0);
        int randomIndex = Random.Range(0, 2);
        Instantiate(_powerUps[randomIndex], platformPosition, rotation);
 
    }
}
