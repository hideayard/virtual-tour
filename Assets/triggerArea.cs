using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArea : MonoBehaviour {

    public AudioSource playSound;
    public scriptTV sekrip;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {

        if (player.gameObject.tag == "Player")
        {
            // sekrip.OnArea = true;
            playSound.Play();
        }
	}
}
