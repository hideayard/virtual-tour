using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggervideo : MonoBehaviour {
    public scriptTV sekrip;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {

        if (player.gameObject.tag == "Player")
        {
            sekrip.tvOn = !sekrip.tvOn;
            // videoPlayer.SetActive(true);
            // Destroy(videoPlayer, timeToStop);
        }
	}
}
