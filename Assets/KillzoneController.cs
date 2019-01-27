using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillzoneController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var house = other.GetComponent<HouseController>();
        if (house != null) {

           SceneManager.LoadScene(2);

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
