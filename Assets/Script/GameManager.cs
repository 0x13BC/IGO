using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance = null;
	public Board grid;

	// Use this for initialization
	void Awake () {
		if(instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		grid =  GetComponent <Board>();
		InitGame();
		
	}
	
	void InitGame()
	{
		//Board.SetupSc
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
