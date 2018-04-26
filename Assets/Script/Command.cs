using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Command : MonoBehaviour {

	delegate void CommandMethod();
	List<CommandMethod> commandList = new List<CommandMethod>();
	public GameObject player = null;
	public int posx,posz;
	public GameObject Dechet;
	public Inventory listOrder = null;
	
	int rot = 0; // 0 Nord, 1 Est, 2 Sud,3 Ouest 
	float lengthmouv= 0.6f;
	float timer = 0.0f;
	int tour = 0;
	
	
	//--------------- A DELETE ------------
	
	int [,] grid = new int[4,4]; // 0: Vide, 1: Robot, 2: Mur, 3: dechet, 4: Plante, 10: Exit
	
	//-------------------------------------
	
	// Use this for initialization
	void Start () {
		player.transform.position = new Vector3(posx*0.6f,0,posz*0.6f);
		for (int x =0; x<4;x++)
		{
			for(int y = 0; y < 4;y++)
			{
				grid[x,y]=0;
			}
		}
		grid[posx,posz]= 1;
		grid[1,1]= 3;
		grid[0,1]= 2;
		grid[2,1]= 2;
		grid[3,1]= 2;

		
	//CreateListCmd();
	}
	
	// Update is called once per frame
	void Update () {
		//var y=0f;
        //var z=0f;
		
		//var toto = player.transform.position.z; // C'est Good ca!!!!
		
			if(Input.GetKeyDown("up"))
			{
					Debug.Log("Avant enregistre");
					//if(rot == 0 && player.transform.position.z/12 < 3 || (rot==90 || rot == -270) /*&&*/ /*player.transform.position.x/12 < 3*/) 
					//z = 12.00f;
				commandList.Add(move);
			}
			
			if(Input.GetKeyDown("right"))
				
				{
					Debug.Log("rotation Droite enregistre");
					commandList.Add(rotateR);
				}
			if(Input.GetKeyDown("left"))
				
				{
					Debug.Log("rotation Gauche enregistre");
					commandList.Add(rotateL);
				}
				
			if(Input.GetKeyDown(KeyCode.A))
			{
				Debug.Log("Action enregistre");
				commandList.Add(action);
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
			if(Input.GetKeyDown(KeyCode.Space))
			{
				execute();
			}
			//execute();
			if(Input.GetKeyDown(KeyCode.Backspace))
			{
				
				RemoveOrder();
			}
				
		
        //player.transform.Translate(0, 0, z);
		//player.transform.Rotate(0, y, 0);
		//Debug.Log("Rotation: " + rot);
		//Debug.Log("z: "+toto);
		
		if(GameOver())
			Debug.Log("BRAVOOOO!!!");
	}
	
	public void execute()
	{
		Debug.Log("Exec");
		foreach (CommandMethod func in commandList)
			func();
		ClearListCmd();
       

    }
	public void takeList()
	{
		CreateListCmd(listOrder.order);
	}
	
	void CreateListCmd( List <string> tab)
	{
		foreach(string order in tab)
		Debug.Log(order);
		foreach(string order in tab)
		switch (order)
		{
			case "move":
			commandList.Add(move);
			break;
		
		case "rotateR":
			commandList.Add(rotateR);
			break;
			
		case "rotateL":
			commandList.Add(rotateL);
			break;
		
		case "action":
			commandList.Add(action);
			break;
		}
	}
	
	void ClearListCmd()
	{
		commandList.Clear();
		//commandList.Add(move);
		//commandList.Add(rotate);
		
	}
	
	void move()
	{
		//Debug.Log("Move");
		//Instantiate something;
		
		if(walkable())
		{
			//Debug.Log("Walkable");
			player.transform.Translate(0,0,0.6f);
			switch(rot)
			{
				case 0:
					posx++;
				break;
				case 1:
					posz++;
				break;
				case 2:
					posx--;
				break;
				case 3:
					posz--;
				break;
			}
			//Debug.Log("Posx: "+posx+" PosZ: "+posz);
		}
		
	}
	
	void rotateR()
	{
		//Debug.Log("RotateR");
		//Instantiate something;
		rot++;
			
			if(rot> 3)
				rot = 0;
		player.transform.Rotate(0,90,0);
		//Debug.Log("Rot: "+rot);
	}
	void rotateL()
	{
		//Debug.Log("RotateL");
		//Instantiate something;
		rot--;
			
			if(rot < 0)
				rot = 3;
		player.transform.Rotate(0,-90,0);
		//Debug.Log("Rot: "+rot);
	}
	
	void action()
	{
		//Debug.Log("Action");
		switch(rot)
			{
				case 0:
					if(posx < 3)
					{
						if(grid[posx+1,posz]== 3 && posx+1<3)
					{
						grid[posx+1,posz] = 0;
						grid[posx+2,posz] = 3;
						Dechet.transform.Translate(0.0f,-0.600f,0f );
						move();
					}
					}
					
				break;
				case 1:
					if(posz<3)
					{
						if(grid[posx,posz+1]== 3 && posz+1<3)
					{
						grid[posx,posz+1] = 0;
						grid[posx,posz+2] = 3;
						Dechet.transform.Translate(0.600f,0.000f,0.000f );
						move();
					}
					}
					
				break;
				case 2:
				
					if(posx>0)
					{
						if(grid[posx-1,posz]== 3 && posx-1>0)
						{
							grid[posx-1,posz]=0;
							grid[posx-2,posz]=3;
							Dechet.transform.Translate(0f,0.600f,0f);
							move();
						}
					}
					
				break;
				case 3:
					if(posz>0)
					{
						if(grid[posx,posz-1]== 3 && posz-1>0)
						{
							grid[posx,posz-1]=0;
							grid[posx,posz-2]=3;
							Dechet.transform.Translate(-0.600f,0f,0f);
							move();
						}
					}
				break;
			}
	}
	
	void jump()
	{
		
	}
	
	void RemoveOrder()
	{
		if(commandList.Count!=0)
		{
			Debug.Log("Derniere Action supprimee");
			commandList.RemoveAt(commandList.Count - 1);
		}
		
	}
	public void Reset()
	{
		SceneManager.LoadScene("grid", LoadSceneMode.Single);
	}


	
	bool walkable()
	{
		bool result = true;
		switch(rot)
			{
				// Bord de map + Collision
				case 0:
					if(posx == 3)
						result =false;
					if(posx < 3)
					{
						if(grid[posx+1,posz]== 2|| grid[posx+1,posz]== 3)
						{
							result = false;
						}
							
					}
					
				break;
				case 1:
					if(posz == 3)
						result =false;
					if(posz < 3)
					{
						if(grid[posx,posz+1]== 2|| grid[posx,posz+1]== 3)
						{
							result = false;
						}
					}
					
				break;
				case 2:
					if(posx == 0)
						result =false;
					if(posx > 0)
					{
						if(grid[posx-1,posz]== 2 || grid[posx-1,posz]== 3)
						{
							result = false;
						}
					}
					
				break;
				case 3:
					if(posz == 0)
						result =false;
					if(posz > 0)
					{
						if(grid[posx,posz-1]== 2 || grid[posx,posz-1]== 3)
						{
							result = false;
						}
					}
				break;
				
				
			}
		
		return result;
	}
	
	bool GameOver()
	{
		bool result = false;
		if(grid[3,3]==3)
		{
			result = true;
			Debug.Log("Partie Terminee");
		}
		return result;
	}
	
}
