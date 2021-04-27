using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class GenerationT : MonoBehaviour
{

    public int height = 512;
    public int width = 512;
    public float smooth = 1;
    public float modifier = 1;
    public int seed = 2345;
    public Tilemap map;
    public Tile dirt;
    public Tile dirtR;
    public Tile grass;

    // Start is called before the first frame update
    void Start()
    {
        int perlinHeight;

        for (int x = 0; x < width; x++)
        {
            perlinHeight = Mathf.RoundToInt(Mathf.PerlinNoise(x / smooth, seed) * height / 2);
            perlinHeight += height / 2;

            for (int y = 0; y < perlinHeight; y++)
            {
                int perlinRot = Mathf.RoundToInt(Mathf.PerlinNoise(x*y / smooth, seed));

                if (perlinRot == 1)
                {
                    map.SetTile(new Vector3Int(x - width / 2, y - height, 0), dirtR);
                }
                else
                {
                    map.SetTile(new Vector3Int(x - width / 2, y - height, 0), dirt);
                }
            }

            map.SetTile(new Vector3Int(x - width / 2, perlinHeight - height, 0), grass);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
