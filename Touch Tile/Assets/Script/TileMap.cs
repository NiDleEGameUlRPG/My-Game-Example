using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class TileMap : MonoBehaviour
{
    private Vector2 tileLocation;
    public int mapLength;
    public GameObject blackTile;
    public GameObject whiteTile;

    private Transform boardHolder;

    // Use this for initialization
    void Start ()
    {
        System.Random r = new System.Random();
        boardHolder = new GameObject("Board").transform;


        for (int i = 0; i < mapLength; i++)
        {
            for (int j = 0; j < mapLength; j++)
            {
                GameObject toInstantiate;
                if (r.Next(0, 100) % 2 == 0)
                {
                    toInstantiate = blackTile;
                }

                else
                {
                    toInstantiate = whiteTile;
                }
                GameObject instance = Instantiate(toInstantiate, new Vector3(i, j, 0.0f), Quaternion.identity);
                instance.transform.SetParent(boardHolder);

            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
