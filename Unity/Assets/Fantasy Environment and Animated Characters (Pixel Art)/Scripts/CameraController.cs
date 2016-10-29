using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset = new Vector3 (0,0,-10);
		
	void Start ()
	{

	}
		
	void Update ()
	{
			transform.position = player.transform.position + offset;
	}
}
