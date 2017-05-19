using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
	public int map_width, map_height, wall_percent;
	public int room_number, max_room_width, max_room_height;
	
	public GameObject wall, road, finish, start, person;

	private const int WALL = -1;
	private const int ROAD = -2;
	private const int PERSON = -3;
	private const int FINISH = -4;
	private const int START = -5;
	private const int EMPTY = 0;
	private int[,] map;
    private Transform boardHolder;
	private int start_x, start_y, finish_x, finish_y;

	MapGenerator()	{
		
	}

	// Use this for initialization
	void Start () {
		map = new int[map_width, map_height];
		mapGenerate();
		instantiateMap();
	}

	// Update is called once per frame
	void Update () {

	}

	void mapGenerate()	{
		int i, j;
		System.Random r = new System.Random();
		for(i = 0; i < map_width; i++)	{
			for(j = 0; j < map_height; j++)	{
				if((i == 0 || i == map_width - 1) || (j == 0 || j == map_height - 1))	{
					// if at bound of map.
					map[i,j] = WALL;
				}
				else {
					int temp = r.Next(0, 100);
					if(temp >= 0 && temp < wall_percent)	{
						map[i,j] = WALL;
					}
					else {
						map[i,j] = ROAD;
					}
				}
			}
		}
		
		start_x = r.Next(1, map_width - 2);
		start_y = r.Next(1, map_height - 2);

		while(isWall(start_x, start_y))	{
			start_x = r.Next(1, map_width - 2);
			start_y = r.Next(1, map_height - 2);
		}
		
		map[start_x,start_y] = START;

		finish_x = r.Next(1, map_width - 2);
		finish_y = r.Next(1, map_height - 2);

		while(isWall(finish_x, finish_y) || (start_x == finish_x && start_y == finish_y))	{
			finish_x = r.Next(1, map_width - 1);
			finish_y = r.Next(1, map_height - 1);
		}
		map[finish_x,finish_y] = FINISH;
	}

	Vector2[] makeRoom( )	{
		// Make Room with (width, height)'s squre.
		Vector2[] returnValue = new Vector2[room_number];
		
		mapInitialize(WALL);
		
		
		return returnValue;
	}

	bool isWall(int i, int j)	{
		bool returnValue = true;
		if(map[i,j] != EMPTY || map[i,j] != ROAD)	{
			returnValue = false;
		}
		return returnValue;
	}

	void mapInitialize(int type)	{
		int i, j;
		for(i = 0; i < map_width; i++)	{
			for(j = 0; j < map_height; j++)	{
				map[i,j] = type;
			}
		}
	}
	
	void instantiateMap()	{
        boardHolder = new GameObject("Board").transform;
        GameObject instance = null;
		GameObject toInstantiate = null;
		int i, j;
		
		for(i = 0; i < map_width; i++)	{
			for(j = 0; j < map_height; j++)	{
                if(map[i,j] == WALL) {	
					toInstantiate = wall;
				}
				else if(map[i,j] == ROAD)	{
					toInstantiate = road;
				}
				else if(map[i,j] == PERSON) {
					toInstantiate = person;
				}
				else if(map[i,j] == FINISH) {
					toInstantiate = finsih;
				}
				else if(map[i,j] == START)	{
					toInstantiate = start;
				}
				else {
					
				}
                instance = Instantiate(toInstantiate, new Vector3(i, j, 0.0f), Quaternion.identity);
			}
		}
		instance.transform.SetParent(boardHolder);
	}
	
	bool mapCanFinsish()	{
		bool returnValue = false;
		
		
		return returnValue;
	}
}
