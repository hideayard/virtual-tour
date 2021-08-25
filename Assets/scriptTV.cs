using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scriptTV : MonoBehaviour
{

    public UnityEngine.Video.VideoClip videoClip;
    public bool tvOn = false;
    public bool OnArea = false;
    // Start is called before the first frame update
    void Start()
    {
        var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        var audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.playOnAwake = false;
        videoPlayer.clip = videoClip;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";
        videoPlayer.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

    }

    // Update is called once per frame
    void Update()
    {
        var vp = GetComponent<UnityEngine.Video.VideoPlayer>();

        if(OnArea)
        {
            if(tvOn)
            {
                vp.Play();
            }
        }
        // else
        // {
        //     vp.Pause();
        // }
        
        tvOn = false;
        OnArea = false;
    }

}
