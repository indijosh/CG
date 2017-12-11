using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInitialization : MonoBehaviour {
	public GameObject gridMesh;
    public GameObject forestNoTile;

	public int xSize;
	public int ySize;
    public float scale = 5;

    public float offsetX;
    public float offsetY;

	public Material[] mapMaterials;

	// Use this for initialization
	void Start () {
        offsetX = UnityEngine.Random.Range(0, 256);
        offsetY = UnityEngine.Random.Range(0, 256);

        for (int x = 0; x < xSize; x += 5)
		{
			for(int y = 0; y < ySize; y += 5)
			{
				float perlinCoord = GeneratePerlinNoise(x, y);

				GameObject gridObject = Instantiate(gridMesh, new Vector3(x, 0, y), Quaternion.Euler(new Vector3(90, 0, 0)));

                //Spawn water
				if(perlinCoord > .63f)
				{
					gridObject.GetComponent<Renderer>().material = mapMaterials[3];
				}

                //Spawn sand
				if (perlinCoord > .59f && perlinCoord < .63f)
				{
					gridObject.GetComponent<Renderer>().material = mapMaterials[2];
				}

                //Spawn grass
				if (perlinCoord > .19f && perlinCoord < .59f)
				{
                    if(perlinCoord > .30 && perlinCoord < .35)
                    {
                        GameObject forestObject = Instantiate(forestNoTile, new Vector3(x, 0, y), Quaternion.Euler(new Vector3(-90, 0, 0)));
                    }
                    gridObject.GetComponent<Renderer>().material = mapMaterials[1];
				}

                //spawn mountain
                if (perlinCoord < .19f)
                {
                    gridObject.GetComponent<Renderer>().material = mapMaterials[0];
                }

                Debug.Log("perlin " + perlinCoord + " : xcoord " + x + " : ycoord " + y);
			}
		}
	}

	private float GeneratePerlinNoise(int x, int y)
	{
		float xCoord = (float)x / xSize * scale + offsetX;
		float yCoord = (float)y / ySize * scale + offsetY;

		float sample = Mathf.PerlinNoise(xCoord, yCoord);
		return sample;
	}
}
