using UnityEngine;
using System.Collections;
using System;

public class ruler_behaviour : MonoBehaviour{
	
	public GameObject Cylinder;
	public GameObject CubeCom;
	public GameObject dir;
	public GameObject angler;
	public Boolean pre = false;
	public Quaternion target;
	public float allow_pos = (float)0.7;
	public int rev = 1;
	public Boolean stop = false;
	public bool moving = false;
	
	// Use this for initialization
	void Start () {
		Cylinder = GameObject.Find("Cylinder");
		CubeCom = GameObject.Find("CubeCom");
		dir = GameObject.Find("arrow");
		angler = GameObject.Find("angler");
		Cylinder.transform.position = transform.position;
		Cylinder.transform.Translate(0, 2, 0);
	}
	
    void Update() {
		
		if(moving == false && stop == false){
		dir.transform.position = new Vector3(transform.position.x,transform.position.y+(float)0.2,transform.position.z);
		dir.transform.eulerAngles = new Vector3(0,90*-Input.acceleration.x,0);		
		dir.transform.Translate(new Vector3(0,0,allow_pos),Space.Self);
			
		Cylinder.transform.position = transform.position;
		Cylinder.transform.eulerAngles = new Vector3(0,0,90*-Input.acceleration.x*rev);
		Cylinder.transform.Translate(new Vector3(0,2,0));
			
		if(rev == -1)dir.transform.Rotate(Vector3.up, 180);
		}

		if (Input.touchCount == 2 && pre == false){
            allow_pos *= -1;
			rev *= -1;
			pre = true;
    	}
		if(Input.touchCount == 1 && pre == false){
			stop = !stop;
			pre = true;
		}
			
		
		
		if(Input.touchCount == 0) pre = false;
		//have to be corrected by using the feature of acceleration. Use the application 
		//"acceleromet er Moniter
		if((Input.acceleration.y < -1.1) && moving == false ){
			moving = true;
			transform.rigidbody.AddForce(new Vector3(-Input.acceleration.y*dir.transform.forward.x*300, 0, -Input.acceleration.y*dir.transform.forward.z*300));
			StartCoroutine("Wait");
		}

	}
	
	private IEnumerator Wait()
	{
		yield return new WaitForSeconds(1.0f);
		Cylinder.transform.position = transform.position;
		Cylinder.transform.Translate(0, 2, 0);
		dir.transform.position = transform.position;
		dir.transform.Translate(new Vector3(0,0,allow_pos),Space.Self);
		StartCoroutine("Com");
		
		
	}
	
	private IEnumerator Com(){
		yield return new WaitForSeconds(1.0f);
		angler.transform.rotation =  Quaternion.LookRotation(transform.position - CubeCom.transform.position);
		CubeCom.transform.rigidbody.AddForce(new Vector3((UnityEngine.Random.value*400+300)*angler.transform.forward.x, 0, (UnityEngine.Random.value*400+300)*angler.transform.forward.z));
		yield return new WaitForSeconds(1.0f);
		Cylinder.transform.position = transform.position;
		Cylinder.transform.Translate(0, 2, 0);
		dir.transform.position = transform.position;
		moving = false;
		stop = false;
	}
}