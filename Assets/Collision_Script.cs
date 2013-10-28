using UnityEngine;
using System.Collections;

public class Collision_Script : MonoBehaviour {
	
	private void OnCollisionEnter(Collision collision)
	{
		
		judge s = (judge)GameObject.Find("label").GetComponent("judge");
		if(collision.gameObject.name == "CubeCom") s.win = 1;
		else if(collision.gameObject.name == "Cube" ) s.win = 2;
	}
}
