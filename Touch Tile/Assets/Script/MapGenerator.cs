using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    private int[,] tiles;
    private int maxValue = 10000;
    public int mapLength;
    public float blockPercent;
    public GameObject blackTile, whiteTile, skyblueTile;
    public GameObject playerTile, startTile, endTile;

    private Transform boardHolder;
    public void mapSetUp()
    {
        GameObject instance;

        tiles = new int[mapLength, mapLength];
        System.Random r = new System.Random();
        boardHolder = new GameObject("Board").transform;

        for (int i = 0; i < mapLength; i++)
        {
            for (int j = 0; j < mapLength; j++)
            {
                GameObject toInstantiate;

                if ( i == 0 || i == mapLength - 1 || j == 0 || j == mapLength - 1 )
                {
                    tiles[i, j] = 0;
                    toInstantiate = blackTile;
                }
                else
                {
                    int temp = r.Next(0, maxValue);
                    if (temp < maxValue * blockPercent / 100)
                    {
                        tiles[i, j] = 0;
                        toInstantiate = blackTile;
                    }
                    else
                    {
                        tiles[i, j] = 1;
                        toInstantiate = whiteTile;
                    }
                }
                
                instance = Instantiate(toInstantiate, new Vector3(i, j, 0.0f), Quaternion.identity);

            }
        }

        int x1 = r.Next(1, mapLength - 1);
        int y1 = r.Next(1, mapLength - 1);

        tiles[x1, y1] = 2;
        instance = Instantiate(startTile, new Vector3(x1, y1, 0.0f), Quaternion.identity);

        tiles[x1, y1] = -1;
        instance = Instantiate(playerTile, new Vector3(x1, y1, 0.0f), Quaternion.identity);

        int x2 = r.Next(1, mapLength - 1);
        int y2 = r.Next(1, mapLength - 1);

        tiles[x2, y2] = 3;
        instance = Instantiate(endTile, new Vector3(x2, y2, 0.0f), Quaternion.identity);
        instance.transform.SetParent(boardHolder);

        /* < First Code >
         for (int i = -(int)(mapLength / 2); i < (int)(mapLength / 2); i++)
        {
            for (int j = -(int)(mapLength / 2); j < (int)(mapLength / 2); j++)
            {
                GameObject toInstantiate;
                int temp = r.Next(0, maxValue);
                if (temp < maxValue * blockPercent)
                {
                    tiles[i + (int)(mapLength / 2), j + (int)(mapLength / 2)] = 0;
                    toInstantiate = blackTile;
                }
                else
                {
                    tiles[i + (int)(mapLength / 2), j + (int)(mapLength / 2)] = 1;
                    toInstantiate = whiteTile;
                }
                GameObject instance = Instantiate(toInstantiate, new Vector3(i, j, 0.0f), Quaternion.identity);
                instance.transform.SetParent(boardHolder);

            }
        }
         */



    }

    public void clicked(int i, int j)
    {
        if(tiles[i, j] == 0)
        {
            tiles[i, j] = 1;
            GameObject instance = Instantiate(whiteTile, new Vector3(i - (int)(mapLength / 2), j - (int)(mapLength / 2), 0.0f), Quaternion.identity);
            instance.transform.SetParent(boardHolder);
        }
        else
        {
            tiles[i, j] = 0;
            GameObject instance = Instantiate(blackTile, new Vector3(i - (int)(mapLength / 2), j - (int)(mapLength / 2), 0.0f), Quaternion.identity);
            instance.transform.SetParent(boardHolder);
        }
    }
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
