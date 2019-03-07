using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    public GameObject[] spawnObjects;

    protected Vector3 spawnPosition;
    protected Quaternion spawnRotation;

    //Spawn target time interval
    public float spawnInterval;
}
