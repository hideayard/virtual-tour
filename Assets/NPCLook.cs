using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AdvancedCustomizableSystem;

public class NPCLook : MonoBehaviour
{
    public CharacterCustomization CharacterCustomization;
    [Space(15)]
    public GameObject ThePlayer;
    public RaycastHit Shot;
    public bool startFollow = false;

    void Update()
    {

        transform.LookAt(ThePlayer.transform);

       if(startFollow)
        {
            foreach (Animator a in CharacterCustomization.GetAnimators())
                a.SetBool("walk", true);
                startFollow = false;
        }
        else
        {
            foreach (Animator a in CharacterCustomization.GetAnimators())
                a.SetBool("walk", false);
            startFollow = false;
        }
    }
}
