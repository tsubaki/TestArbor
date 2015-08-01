using UnityEngine;
using System.Collections;
using Arbor;

public class MoveTarget : StateBehaviour 
{
	[SerializeField]
	Transform target;

	
	[SerializeField]
	Transform camera;

	public void Update()
	{
		camera.position = Vector3.Lerp(camera.position, target.position, 0.3f);
	}
}
