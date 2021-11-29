using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerater : MonoBehaviour {

	public Texture2D map;
	public Color enemyColor = new Color(0, 1, 1, 1);
	public int enemyCount, count;
	public GameObject enemy;
	public ColorToPrefab[] colorMappings;
	public List<Vector2> spawnPoints;
	// Use this for initialization
	void Start () {
		GenerateLevel();
		Debug.Log("Game Started!");
	}

	void GenerateLevel()
	{	
		for(int x =0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x, y);

			}
		}
		GenerateEnemy();
	}

	//Method responsible to Generate Walls at x,y points, denoted as black, red & blue in the 2d map.
	void GenerateTile(int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);
		//Debug.Log("Position" + x + ", " + y + " Pixel color" + pixelColor);
		if (pixelColor.a == 0)
		{
			return;
		}
		if (pixelColor == enemyColor)
		{
			spawnPoints.Add(new Vector2(x, y));
		}
		else
		{
			foreach (ColorToPrefab colorMapping in colorMappings)
			{

				if (colorMapping.color.Equals(pixelColor))
				{
					Vector3 position = new Vector3(x - 16, .2f, y - 16);
					Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
				}
			}
		}
	}
	//Method responsible to Generate Enemy at random spawn points, denoted as teal in the 2d map.
	void GenerateEnemy()
	{
		int Listsize = spawnPoints.Count;
		int[] spawned = new int[Listsize];

		for (; count < enemyCount; count++)
		{
			int position = Random.Range(0, Listsize);
			Vector3 pos = new Vector3(spawnPoints[position].x-16, 2, spawnPoints[position].y-16);
			Instantiate(enemy, pos, Quaternion.identity, transform);
			spawned[position] = 1;
		}
	}

}
