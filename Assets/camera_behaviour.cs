using UnityEngine;
using System.Collections;

public class camera_behaviour : MonoBehaviour {
	public GameObject Cube;
	public GameObject CubeCom;
	public Transform Target;
	//[AddComponentMenu("uler_behaviour")]
	//public ruler_behaviour test = new ruler_behaviour();
	public int test2;
	
	// Use this for initialization
	void Start () {
		Cube = GameObject.Find("Cube");
		CubeCom = GameObject.Find("CubeCom");
		Target = GameObject.Find("Cube").transform;
		//test = ruler_behaviour.rev;
		//test2 = ruler_behaviour.rev;
		// = rev;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		transform.rotation=Quaternion.LookRotation(CubeCom.transform.position - Cube.transform.position);
		transform.eulerAngles = new Vector3(40,transform.eulerAngles.y,270);		//rotate only y angle.	
		transform.position=new Vector3(Cube.transform.position.x,Cube.transform.position.y+2,Cube.transform.position.z);
	}
}
