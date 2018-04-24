using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	 Element [,] grid = null;
	 public GameObject Character = null; 
	 public GameObject cubeModel;
	 GameObject [,] cubeGrid = null;
	 
	 public int sizeX = 4;
	 public int sizeY = 4;
	 
	 public float space = 0.1f;
	 float sizeCube = 0.5f;

	// Use this for initialization
	void Awake () {
		grid = new Element[sizeX,sizeY];
		//grid[0,0] = Character;
		cubeGrid = new GameObject[sizeX,sizeY];
		for (int x =0; x<sizeX;x++)
		{
			for(int y = 0; y < sizeY;y++)
			{
				cubeGrid[x,y]=Instantiate( cubeModel , new Vector3((float)x*(sizeCube+ space),-sizeCube,(float)y*(sizeCube + space)),cubeModel.transform.rotation);
				cubeGrid[x,y].transform.parent = gameObject.transform;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
