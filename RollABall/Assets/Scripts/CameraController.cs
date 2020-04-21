using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public GameObject player;
	private Vector3 pomak;

	
	void Start () 
	{
		pomak = transform.position - player.transform.position;
	}
	
	
	void LateUpdate () 
	{
		transform.position = player.transform.position + pomak;
	}
}
