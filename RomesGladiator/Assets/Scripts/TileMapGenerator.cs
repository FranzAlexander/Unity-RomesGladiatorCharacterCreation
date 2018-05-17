using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TileMapGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Image testSprite;
    public Vector3 mapSize;
    public GameObject tileLook;
    public Image playerIcon;
    Vector3 tilePosition;
    List<Vector3> tilePositions = new List<Vector3>();
    Vector3 characterStart;


    void Start()
    {
        GenerateMap();
        characterStart.x = 4;
        playerIcon.transform.position = characterStart;
    }

    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            playerIcon.transform.Translate(Vector3.up);
        }

        if (Input.GetKeyDown("down"))
        {
            playerIcon.transform.Translate(Vector3.down);
        }
    }

    public void GenerateMap()
    {
        int index = 0;
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                tilePosition = new Vector3(x, 0, y);
                Transform tt = Instantiate(tilePrefab, tilePosition * 1.5f, Quaternion.Euler(Vector3.right * 90));
                tilePositions.Add(tilePosition);
                Debug.Log(tilePositions[index].x + ", " + tilePositions[index].y + ", " + tilePositions[index].z);
                index++;
            }
        }
    }

}
