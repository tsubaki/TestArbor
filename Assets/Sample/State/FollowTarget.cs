using UnityEngine;
using System.Collections;
using Arbor;

public class FollowTarget : StateBehaviour {

	[SerializeField]
	Transform target;

	[SerializeField]
	Vector3 offset = new Vector3(-5, 5, 5);

	[SerializeField]
	Transform camera;

	void Update () 
	{
		camera.position = Vector3.Lerp(camera.position, target.position + offset, 0.3f);
	}
}
