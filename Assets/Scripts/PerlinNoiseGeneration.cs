using UnityEngine;

public class PerlinNoiseGeneration : MonoBehaviour {
	public int pixWidth = 25;
	public int pixHeight = 25;
	public float xOrg;
	public float yOrg;
	public float scale = 1.0F;
	private Texture2D noiseTex;
	private Color[] pix;
	private Renderer rend;
	void Start()
	{
		rend = GetComponent<Renderer>();
		noiseTex = new Texture2D(pixWidth, pixHeight);
		pix = new Color[noiseTex.width * noiseTex.height];
		rend.material.mainTexture = noiseTex;
	}
	void CalcNoise()
	{
		int y = 0;
		while (y < noiseTex.height)
		{
			int x = 0;
			while (x < noiseTex.width)
			{
				float xCoord = xOrg + x / noiseTex.width * scale;
				float yCoord = yOrg + y / noiseTex.height * scale;
				float sample = Mathf.PerlinNoise(xCoord, yCoord);
				pix[y * noiseTex.width + x] = new Color(sample, sample, sample);
				x++;
				Debug.Log(sample);
			}
			y++;
		}
		noiseTex.SetPixels(pix);
		noiseTex.Apply();
	}
	void Update()
	{
		CalcNoise();
	}
}
