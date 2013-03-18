using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	
	public GameObject Ball;
	public GameObject Basket;
	public float Force = 1;
	private float originalForce;
	
	void OnGUI() {
		if(	GUI.Button (new Rect(10, 10, 100, 30), "Reset"))
		{
			Force = originalForce;
			Ball.transform.position = new Vector3(8, 0, 0);
		}
		
		Force = GUI.VerticalSlider (new Rect(10, 50, 30, 150), Force, 80, 0);
		
		GUI.Label (new Rect(50, 60, 100, 30), "Force");
	}
	
	// Use this for initialization
	void Start () {
		originalForce = Force;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp (KeyCode.Space)) {
			var V = Vector3.Lerp (Ball.transform.position, Basket.transform.position, 1);
			V.Normalize ();
			
			Ball.rigidbody.AddForce (V*Force, ForceMode.Impulse);
		}
	}
}
