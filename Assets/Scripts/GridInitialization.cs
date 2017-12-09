using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInitialization : MonoBehaviour {
	public GameObject gridMesh;
	public int xSize;
	public int ySize;

	public Material[] mapMaterials;

	// Use this for initialization
	void Start () {
		for(int x = 0; x < xSize; x += 1)
		{
			for(int y = 0; y < ySize; y += 1)
			{
				float perlinCoord = GeneratePerlinNoise(x, y);

				GameObject gridObject = Instantiate(gridMesh, new Vector3(x, 0, y), Quaternion.Euler(new Vector3(90, 0, 0)));

				if(perlinCoord > .59f)
				{
					gridObject.GetComponent<Renderer>().material = mapMaterials[2];
				}

				if (perlinCoord > .49f && perlinCoord < .59f)
				{
					gridObject.GetComponent<Renderer>().material = mapMaterials[1];
				}

				if (perlinCoord > .25f && perlinCoord < .49f)
				{
					gridObject.GetComponent<Renderer>().material = mapMaterials[0];
				}

				Debug.Log("perlin " + perlinCoord + " : xcoord " + x + " : ycoord " + y);
			}
		}
	}

	private float GeneratePerlinNoise(int x, int y)
	{
		float xCoord = (float)x / xSize * 5f;
		float yCoord = (float)y / ySize * 5f;

		float sample = Mathf.PerlinNoise(xCoord, yCoord);
		return sample;
	}
}
