using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;
using UnityEngine;

public class CameraShakeOrbit : MonoBehaviour {

	public GameObject objectHere;

	public float spherespaceSize = 1;
	public float movespeed = 1;
	public bool startDisabled = false;

	Vector3 startposition;
	Vector3 randomposition;

	public TeaTime shakeCamera;

	void Start () {
		startposition = objectHere.transform.localPosition;
		//transform.localPosition = cameraHere.transform.localPosition;

		shakeCamera = this.tt ().Add (t => {
			randomposition = Random.insideUnitSphere * spherespaceSize + startposition;
			randomposition = new Vector3 (randomposition.x, randomposition.y,
				transform.localPosition.z);

		}).Loop (t => {
			//
			objectHere.transform.localPosition =
				Vector3.MoveTowards (objectHere.transform.localPosition,
					randomposition, movespeed * Time.deltaTime);
			//
			if (objectHere.transform.localPosition == randomposition) {
				startposition = objectHere.transform.localPosition;
				t.EndLoop ();
			} //
		}).Repeat ();

		if (startDisabled)
			shakeCamera.Stop ();
	}

	public void StopShake () {
		shakeCamera.Stop ();
	}

	public void PlayShake () {
		shakeCamera.Play ();
	}

}