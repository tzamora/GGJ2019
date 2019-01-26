using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TriggerController : MonoBehaviour {

	public bool isColliding = false;

	public bool isEmpty = false;

	public Action<Collider> OnEnter;

	public Action<Collider> OnExit;

	public List<Collider> others = null;

	void OnTriggerEnter(Collider theOther) {

		isColliding = true;

		isEmpty = false;

		others.Add(theOther);

		if (OnEnter!=null) {
			OnEnter(theOther);
		}

	}

	void OnTriggerExit(Collider theOther) {

		others.Remove (theOther);

		if (others.Count <= 0) {
			
			isColliding = false;
			isEmpty = true;
			
		}

		if (OnExit!=null) {
			OnExit(theOther);		
		}
	}

}
