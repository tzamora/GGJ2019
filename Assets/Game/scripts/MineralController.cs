using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralController : MonoBehaviour {
    [Header ("Settings")]
    public int amount;

    public AudioClip recolectSound;

    public TriggerController bodyCollider;

    public float glowSpeed = 1;

    public Color sourceColor = Color.white;

    public List<GameObject> Shapes = new List<GameObject> ();

    // Start is called before the first frame update

    bool emissionEnabled = false;
    Material materialGlow;

    void Start () { GetShape (); }

    void Update () {

        if (bodyCollider.isColliding) {

            foreach (var collider in bodyCollider.others) {

                var player = collider.gameObject.GetComponent<PlayerController> ();

                if (player && player.playerRewired.GetButtonDown("Collect")) {
                    player.Recolect (amount);
                    Destroy (gameObject);
                    SoundManager.Get.PlayClip (recolectSound, false);
                }

            }
        }

        if (emissionEnabled) EmissionGlow ();

    }

    void GetShape () {

        int r = Random.Range (0, Shapes.Count);

        GameObject theShape = Instantiate (Shapes[r],
            gameObject.transform.position, gameObject.transform.rotation);
        theShape.transform.localScale = Vector3.one * .07f;
        theShape.name = "Obj";
        theShape.transform.SetParent (gameObject.transform);

        // print ("random was " + r);

        if (r >= Shapes.Count - 3) {
            emissionEnabled = true;
            Destroy (GetComponent<Rotating> ());
            materialGlow = theShape.GetComponent<MeshRenderer> ().material;
            gameObject.transform.Translate (new Vector3 (0, -0.5f, 0));
        }

    }

    void EmissionGlow () {

        float emission = Mathf.PingPong (Time.time * glowSpeed, 1.3f);

        Color baseColor = sourceColor;
        // Replace this with whatever you want
        // for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);

        materialGlow.SetColor ("_EmissionColor", finalColor);

    }

}