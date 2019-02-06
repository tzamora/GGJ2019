using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;
using UnityEngine;
using UnityEngine.UI;

public class NearCharacter : MonoBehaviour {

	PlayerController sourceInfo;
	public float speedA;
	public float speedB;
	public float speedC;
	public bool isActivated = false;
	public Sprite FaceA;
	public Sprite FaceB;
	public Sprite FaceC;

	int currentFace;
	bool face = false;
	bool animateEnabled = false;
	SpriteRenderer faceSprite;

	void Start () {

		sourceInfo = gameObject.transform.parent.GetComponent<PlayerController> ();
		faceSprite = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		faceSprite.enabled = false;

		this.tt ().Add (1, t => {

			if (isActivated) {

				if (sourceInfo.anxiousPoints < 30)
					sourceInfo.anxiousPoints += 5;

				if (sourceInfo.anxiousPoints > 30)
					sourceInfo.anxiousPoints = 30;

			} else if (sourceInfo.anxiousPoints > 0) sourceInfo.anxiousPoints--;

			if (sourceInfo.anxiousPoints > 0 &&
				sourceInfo.anxiousPoints < 10) {
				sourceInfo.walkSpeed = speedC;
				if (currentFace != 0) {
					currentFace = 0;
					face = true;
				}
			} else if (sourceInfo.anxiousPoints > 10 &&
				sourceInfo.anxiousPoints < 20) {
				sourceInfo.walkSpeed = speedB;
				if (currentFace != 1) {
					currentFace = 1;
					face = true;
				}
			} else if (sourceInfo.anxiousPoints > 20 &&
				sourceInfo.anxiousPoints < 30) {
				sourceInfo.walkSpeed = speedA;
				if (currentFace != 2) {
					currentFace = 2;
					face = true;
				}
			}

			if (sourceInfo.anxiousPoints == 30)
				face = true;

			if (face) switch (currentFace) {

				case 0:
					faceSprite.sprite = FaceC;
					ShowingFace ();
					face = false;
					break;
				case 1:
					faceSprite.sprite = FaceB;
					ShowingFace ();
					face = false;
					break;
				case 2:
					faceSprite.sprite = FaceA;
					ShowingFace ();
					face = false;
					break;

			}

		}).Repeat ();

	}

	void OnTriggerStay (Collider coll) {

		if (coll.gameObject.tag == "Companion")
			isActivated = true;

	}

	void OnTriggerExit (Collider coll) {

		if (coll.gameObject.tag == "Companion") {
			isActivated = false;

			print ("runs");
		}
	}

	void ShowingFace () {

		faceSprite.enabled = true;
		animateEnabled = false;

		this.tt ().Add (3, t => {

			animateEnabled = true;

			if (animateEnabled)
				faceSprite.enabled = false;

		});

	}

	void Update () {

		faceSprite.transform.LookAt (Camera.main.transform.position, -Vector3.down);

	}

}