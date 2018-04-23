using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	bool rot = false;
	float saveRot = 0f;
	public float speedCam = 10f;
	
	//var target.transform;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.R) && !rot)
			{
				Debug.Log("Titi");
			//saveRot;
			rot = true;
			saveRot = 0f;
			}
		if(rot)
		{
			
			//transform.LookAt(target);
			//transform.Translate(Vector3.right * Time.deltaTime);
		
			if(saveRot<90)
			{
				saveRot = saveRot + (speedCam*Time.deltaTime);
				var r = Time.deltaTime*speedCam;
				if(saveRot > 90)
				{
					var tempDis = saveRot - 90.00f;
					saveRot = 90.00f;
					r = r - tempDis;
					
				}
				transform.Rotate(0, r, 0);
				
				Debug.Log(saveRot);
			}
			else
			{
				rot = false;
			}
		}
	}
}
