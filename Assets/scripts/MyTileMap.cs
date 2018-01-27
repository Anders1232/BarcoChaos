using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTileMap : MonoBehaviour {
	public GameObject emptyTilePrefab;
	public GameObject lineTilePrefab;
	public GameObject curveTilePrefab;
	public GameObject plusPrefab;
	private int [,] tileMap= new int[,]{{0,1, 2, 3},
										{1, 2, 3, 0},
										{2, 3, 0, 1},
										{3, 0, 1, 2}};
	private GameObject[] tiles;
	public Vector2 tileSize;
	// Use this for initialization
	void Start () {
		GameObject[] tempTiles= new GameObject[]{emptyTilePrefab, lineTilePrefab, curveTilePrefab, plusPrefab};
		tiles = new GameObject[tileMap.Length * tileMap.GetLength(0)];
		int tileCounter = 0;
		for(int i=0; i < tileMap.GetLength(0); i++){
//			Debug.Log ( tileMap.GetLength(1));
			for(int j=0; j < tileMap.GetLength(1); j++){
				Debug.Log ("(" + i + "," + j + ")" );
				int tileCode = tileMap [i,j];
				GameObject newGO= GameObject.Instantiate(tempTiles[tileCode], gameObject.transform, false) as GameObject;
				tiles[tileCounter++]= newGO;
				newGO.transform.localPosition= new Vector3(i*tileSize.x, -(j *tileSize.y), newGO.transform.localPosition.z);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
