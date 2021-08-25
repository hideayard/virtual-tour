using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggervideo : MonoBehaviour {
    

    public AudioSource playSound;
    public scriptTV sekrip;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {

        // if ((player.gameObject.tag == "hand") || (player.gameObject.tag == "Player"))
        if (player.gameObject.tag == "hand")
        {
            sekrip.tvOn = true;
            sekrip.OnArea = true;
            playSound.Play();

        }
	}
}
