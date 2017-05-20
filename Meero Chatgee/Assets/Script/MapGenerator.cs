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
	private Vector2[] room_location;
	private Vector2[] room_size;

	MapGenerator()	{
		
	}

	// Use this for initialization
	void Start () {
		map = new int[map_width, map_height];
		mapGenerate();
		instantiateMap();
	}
	static void Main(){}
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
		setRoom();
		
		start_x = r.Next(1, map_width - 2);
		start_y = r.Next(1, map_height - 2);

		while(isWall(start_x, start_y))	{
			start_x = r.Next(1, map_width - 2);
			start_y = r.Next(1, map_height - 2);
		}
		
		map[start_x,start_y] = START;

		finish_x = r.Next(1, map_width - 1);
		finish_y = r.Next(1, map_height - 1);

		while(isWall(finish_x, finish_y) || (start_x == finish_x && start_y == finish_y))	{
			finish_x = r.Next(1, map_width - 1);
			finish_y = r.Next(1, map_height - 1);
		}
		map[finish_x,finish_y] = FINISH;
	}

	void setRoom( )	{
		// Make Room with (width, height)'s squre.
		room_location = new Vector2[room_number];
		room_size = new Vector2[room_number];
		System.Random r = new System.Random();
		int i, x, y, w, h;
		
		for(i = 0; i < room_number; i++)	{
			x = r.Next(1, map_width - 1);
			y = r.Next(1, map_height - 1);
			w = r.Next(1, map_width - x - 1);
			while(w > max_room_width)	{
				w = r.Next(1, map_width - x - 1);
			}
			h = r.Next(1, map_height - y - 1);
			while(h > max_room_height)	{
				h = r.Next(1, map_height - y - 1);
			}
			createRoom(x, y, w, h);
			room_location[i] = new Vector2(x, y);
			room_size[i] = new Vector2(w, h);
		}
	}
	
	void createRoom(int x, int y, int w, int h)	{
		int i, j;
		for(i = x; i < x + w; i++)	{
			for(j = y; j < y + h; j++)	{
				map[i,j] = ROAD;
			}
		}
	}
	void setRoad()	{
		System.Random r = new System.Random();
		// Link all room with road line.
		r.Next(0,1);
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
					toInstantiate = finish;
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
	
	bool mapCanFinsish(int x, int y, int w, int h)	{
		bool returnValue = false;
		// If map[x,y] ~ map[x + w, x + h] can finish 
		
		
		return returnValue;
	}
}
