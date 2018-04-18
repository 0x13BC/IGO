using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Command : MonoBehaviour {

	delegate void CommandMethod();
	List<CommandMethod> commandList = new List<CommandMethod>();
	public GameObject player = null;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		var y=0f;
        var z=0f;
		
		if(Input.GetKeyDown("up")||Input.GetKeyDown("down"))
		{
			if(Input.GetKeyDown("up"))
			z = 12.0f;
			else
				z = -12.0f;
	
		}
		if(Input.GetKeyDown("right")||Input.GetKeyDown("left"))
		{
			if(Input.GetKeyDown("right"))
			y = 90.0f;
			else
				y = -90.0f;
		}
		
		
        player.transform.Translate(0, 0, z);
		player.transform.Rotate(0, y, 0);
	}
	
	
	void CreateListCmd()
	{
		
		commandList.Add(move);
		commandList.Add(rotate);
		
	}
	void execute()
	{
		commandList[0]();
	}
	
	void move()
	{
		//Instantiate something;
	}
	
	void rotate()
	{
		//Instantiate something;
	}
	
	void action()
	{
		
	}
	
	void jump()
	{
		
	}
	
}
