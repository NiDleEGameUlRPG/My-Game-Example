using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private MapGenerator script;

    // Use this for initialization
    void Awake ()
    {
        script = GetComponent<MapGenerator>();
        script.mapSetUp();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                //checkCollider(pos);
            }
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

        }
    }
    void checkCollider ( Vector2 pos )
    {
        if (pos.x < 0 && pos.y < 0) script.clicked((int)(pos.x - 0.4) + (int)(script.mapLength / 2), (int)(pos.y - 0.5) + (int)(script.mapLength / 2));
        else if (pos.x >= 0 && pos.y < 0) script.clicked((int)(pos.x + 0.4) + (int)(script.mapLength / 2), (int)(pos.y - 0.5) + (int)(script.mapLength / 2));
        else if (pos.x < 0 && pos.y >= 0) script.clicked((int)(pos.x - 0.4) + (int)(script.mapLength / 2), (int)(pos.y + 0.5) + (int)(script.mapLength / 2));
        else script.clicked((int)(pos.x + 0.4) + (int)(script.mapLength / 2), (int)(pos.y + 0.5) + (int)(script.mapLength / 2));
    }
}