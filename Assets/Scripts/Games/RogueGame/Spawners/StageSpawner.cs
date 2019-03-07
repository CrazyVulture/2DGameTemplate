using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class StageSpawner : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min,int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    //Stage range
    public int cols = 8;
    public int rows = 8;
    //Wall and food counts
    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);
    //Prefabs
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;

    Transform boardHolder;
    List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();

        for (int x = 1; x < cols-1; x++)
        {
            for (int y = 1; y < rows-1; y++)
                gridPositions.Add(new Vector3(x, y, 0f));
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < cols+1; x++)
        {
            for (int y = -1; y < rows+1; y++)
            {
                GameObject backGround = floorTiles[Random.Range(0,floorTiles.Length)];
                if (x == -1 || x == cols || y == -1 || y == rows)
                    backGround = outerWallTiles[Random.Range(0,outerWallTiles.Length)];

                GameObject instance = Instantiate
                    (backGround, new Vector3(x,y,0), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutItemAtRandom(GameObject[] tileArray,int min,int max)
    {
        int objCount = Random.Range(min,max);

        for (int i = 0; i < objCount; i++)
        {
            Vector3 randomPos = RandomPosition();
            GameObject tileItem = tileArray[Random.Range(0,tileArray.Length)];
            Instantiate(tileItem, randomPos, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        LayoutItemAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutItemAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
        int enemyCount = (int)Mathf.Log(level,2f);
        LayoutItemAtRandom(enemyTiles, enemyCount, enemyCount);
        Instantiate(exit, new Vector3(cols - 1, rows - 1, 0), Quaternion.identity);
    }
}
