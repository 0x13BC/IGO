using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Command : MonoBehaviour {

	delegate void CommandMethod();
	List<CommandMethod> commandList = new List<CommandMethod>();
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
