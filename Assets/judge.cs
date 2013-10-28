using UnityEngine;
using System.Collections;

public class judge : MonoBehaviour {
	// Use this for initialization
	public Texture2D winner,looser;
	public int win=0;
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void OnGUI(){
		if(win == 1){
			GUI.Label(new Rect(Screen.width/2-200,Screen.height/2-150,400,300),winner);
		}else if(win == 2){
			GUI.Label(new Rect(Screen.width/2-200,Screen.height/2-150,400,300),looser);
		}
			
	
	}
}
