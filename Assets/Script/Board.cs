using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	 Element [,] grid = null;
	 public Robot Character = null; 
	 public List <GameObject> cubeList;
	 
	 public int sizeX = 0;
	 public int sizeY = 0;

	// Use this for initialization
	void Start () {
		grid = new Element[sizeX,sizeY];
		grid[0,0] = Character;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
