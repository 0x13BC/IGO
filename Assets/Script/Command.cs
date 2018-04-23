using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Command : MonoBehaviour {

	delegate void CommandMethod();
	List<CommandMethod> commandList = new List<CommandMethod>();
	public GameObject player = null;
	public int posx,posz;
	float rot = 0.00f;
	float timer = 0.0f;
	int tour = 0;
	
	// Use this for initialization
	void Start () {
		player.transform.position = new Vector3(posx*12,5,posz*12);

	}
	
	// Update is called once per frame
	void Update () {
		var y=0f;
        var z=0f;
		
		var toto = player.transform.position.z; // C'est Good ca!!!!
		
		if(Input.GetKeyDown("up")||Input.GetKeyDown("down"))
		{
			Debug.Log("Toto");
			if(Input.GetKeyDown("up"))
			{
					
					//if(rot == 0 && player.transform.position.z/12 < 3 || (rot==90 || rot == -270) /*&&*/ /*player.transform.position.x/12 < 3*/) 
					z = 12.00f;
			}
			
			else
			{
				z = -12.0f;
			}
				
	
		}
		if(Input.GetKeyDown("right")||Input.GetKeyDown("left"))
		{
			Debug.Log("Tata");
			if(Input.GetKeyDown("right"))
				
				{
			y = 90.0f;
			rot = rot +y;
			if(rot> 270)
				rot = 0;
				}
			else
			{
				y = -90.0f;
			rot = rot + y;
			if(rot < -270)
				rot = 0;
			}
		}
			// timer += Time.deltaTime;
			// int seconds =(int) (timer % 60);
			
			// if(seconds == 1)
			// {
				// tour++;
				// if(tour == 3)
				// {
					// tour = 0;
					// y = 90.00f;
				// }
				// z = 12.00f;
			 // timer = 0.00f;
			 
			// }
				
		
        player.transform.Translate(0, 0, z);
		player.transform.Rotate(0, y, 0);
		//Debug.Log("Rotation: " + rot);
		//Debug.Log("z: "+toto);
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
