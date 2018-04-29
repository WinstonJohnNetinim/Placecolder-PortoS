using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform player;
	public Vector3 offset;
	
	// Update is called once per frame
	void Update ()
	{

		transform.position = new Vector3 (player.transform.position.x, 0, 0) + offset;
	}
}

//	void Update ()
//{
//	transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z) + offset;
//}
//}