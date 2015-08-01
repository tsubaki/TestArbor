using UnityEngine;
using System.Collections;
using AnimatorParameter;

[SelectionBase]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour {

	[SerializeField, DisappearAttachedField]
	CharacterController characterController;

	[SerializeField]
	CharacterTemplate controller;

	float speed = 1;
	
	private Vector3 direction;

	void Reset()
	{
		controller = new CharacterTemplate ();
		controller.animator = GetComponent<Animator> ();
		
		characterController = GetComponent<CharacterController> ();
		characterController.center = Vector3.up * 0.75f;
		characterController.height = 1.5f;
		characterController.radius = 0.3f;
	}
	
	void Update () 
	{
		var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
		direction = cameraForward * Input.GetAxis ("Vertical") + 
			Camera.main.transform.right * Input.GetAxis ("Horizontal");

		if (Input.GetButton ("Dash")) {
			speed = Mathf.Lerp (speed, 3, 0.3f);
		} else {
			speed = Mathf.Lerp (speed, 1, 0.3f);
		}
		controller.animator.speed = speed;
		controller.Speed = direction.sqrMagnitude;
	}
	
	void OnAnimatorMove()
	{
		characterController.SimpleMove (direction.normalized * speed);
		if (direction != Vector3.zero) {
			var velocity = characterController.velocity;
			velocity.y = 0;
			transform.rotation = Quaternion.LookRotation(direction);
		}
	}
}