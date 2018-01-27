using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTileMap : MonoBehaviour {
	public GameObject emptyTilePrefab; 			// 0
	public GameObject lineTilePrefab; 			// 1
	public GameObject curveTilePrefab; 			// 2
	public GameObject plusPrefab;				// 3
	public GameObject doubleCurvePrefab;		// 4
	public GameObject lineTileFixaPrefab;		// 5
	public GameObject curveTileFixaPrefab;		// 6
	public GameObject doubleCurveFixaPrefab;	// 7
	public GameObject lineTileFixaPrefabHorizontal;		// 8



	private int [,] tileMap= new int[,]{{1, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6, 7, 1},
										{1, 1, 3, 4, 7, 1, 2, 3, 4, 4, 5, 6, 7, 1},
										{1, 1, 0, 0, 0, 0, 3, 4, 0, 0, 0, 0, 7, 1},
										{3, 4, 0, 0, 0, 0, 4, 6, 0, 0, 0, 0, 7, 1},
										{4, 5, 0, 0, 0, 0, 6, 1, 0, 0, 0, 0, 7, 1},
										{5, 1, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 7, 1},
										{5, 1, 8, 8, 8, 8, 1, 2, 8, 8, 8, 8, 7, 1},
										{5, 1, 2, 3, 4, 6, 1, 2, 3, 4, 5, 6, 7, 1},
										{5, 1, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 7, 1},
										{5, 1, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 7, 1},
										{5, 1, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 7, 1},
										{1, 2, 0, 0, 0, 0, 2, 3, 0, 0, 0, 0, 7, 1},
										{2, 3, 8, 8, 8, 8, 3, 4, 8, 8, 8, 8, 7, 1},
										{4, 5, 1, 2, 3, 4, 5, 1, 2, 4, 5, 6, 7, 1}};
	private int[,] tileMap2;
	public GameObject[] tiles;
	public Vector2 tileSize;
	// Use this for initialization
	void Start () {
		tileMap2 = new int[tileMap.GetLength (1), tileMap.GetLength (0)];
		for(int i=0; i < tileMap.GetLength(0); i++){
			for(int j=0; j < tileMap.GetLength(1); j++){
				tileMap2 [j, tileMap.GetLength(0)-i-1] = tileMap [i, j];
			}
		}
		GameObject[] tempTiles= new GameObject[]{emptyTilePrefab, lineTilePrefab, curveTilePrefab, plusPrefab, doubleCurvePrefab, 
			lineTileFixaPrefab, curveTileFixaPrefab, doubleCurveFixaPrefab, lineTileFixaPrefabHorizontal};
		tiles = new GameObject[tileMap.Length * tileMap.GetLength(0)];
		int tileCounter = 0;
		for(int i=0; i < tileMap2.GetLength(0); i++){
//			Debug.Log ( tileMap2.GetLength(1));
			for(int j=0; j < tileMap2.GetLength(1); j++){
//				Debug.Log ("(" + i + "," + j + ")" );
				int tileCode = tileMap2 [i,j];
				GameObject newGO= GameObject.Instantiate(tempTiles[tileCode], gameObject.transform, false) as GameObject;
				tiles[tileCounter++]= newGO;
				newGO.transform.localPosition= new Vector3(i*tileSize.x, (j *tileSize.y), newGO.transform.localPosition.z);
				AjustScale (newGO);
			}
		}
	}

	GameObject GetPipeClicked(Vector2 position){
//		float deltaX = tiles[1].transform.position.x - tiles[0].transform.position.x;
//		float deltaY = tiles[tileMap.GetLength(1)].transform.position.y - tiles[0].transform.position.y;

		int indexX = Mathf.FloorToInt( (position.x+tileSize.x/2) / tileSize.x);
		int indexY = Mathf.FloorToInt( (position.y+tileSize.y/2) / tileSize.y);

//		Debug.Log (new Vector2 (indexX, indexY));
		return tiles [indexX * tileMap2.GetLength (1) + indexY];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 mousePos = Camera.main.ScreenPointToRay (Input.mousePosition).origin-transform.position;
			GetPipeClicked(new Vector2(mousePos.x, mousePos.y)).GetComponent<Pipe>().Rotate();
		}
	}

	void AjustScale (GameObject tile){
		Sprite aux= tile.GetComponent<SpriteRenderer>().sprite;
		if (null == aux)
			return;
		Vector4 temp= aux.border;
//		Vector2 spriteSize = new Vector2 (temp.z - aux.bounds.size, temp.w - temp.y);
		Vector2 spriteSize = new Vector2 (aux.bounds.size.x/8, aux.bounds.size.y/8);
//		Debug.Log("spriteSize = " + spriteSize);
		tile.transform.localScale= new Vector3(spriteSize.x/tileSize.x*0.32f, spriteSize.y/tileSize.y*0.32f);
//		tile.transform.localScale= new Vector3(spriteSize.x, spriteSize.y);
	}

}
