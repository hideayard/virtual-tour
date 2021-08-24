
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerLt1 : MonoBehaviour {
    public NPCFollow sekrip;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider player) {

        if (player.gameObject.tag == "Player")
        {
            sekrip.startFollow = true;
            // videoPlayer.SetActive(true);
            // Destroy(videoPlayer, timeToStop);
        }
	}
}
