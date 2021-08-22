﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AdvancedCustomizableSystem;

public class NPCFollow : MonoBehaviour
{
    public CharacterCustomization CharacterCustomization;
    [Space(15)]
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedDistance = 1.5f;
    public float FollowSpeed;
    public RaycastHit Shot;

    void Update()
    {
        Debug.Log( "TargetDistance: " + TargetDistance );
        Debug.Log( "transform.TransformDirection(Vector3.forward): " + transform.TransformDirection(Vector3.forward) + " <> follower: " + transform.position);

        transform.LookAt(ThePlayer.transform);

        if(Physics.Raycast(new Vector3(transform.position.x, transform.TransformDirection(Vector3.forward).y, transform.position.z) ,transform.TransformDirection(Vector3.forward),out Shot))
        {
            TargetDistance = Shot.distance;
            //lihat sekali lagi
            if(ThePlayer.transform.position.y > transform.TransformDirection(Vector3.forward).y)
            {
                transform.LookAt(new Vector3(ThePlayer.transform.position.x, ThePlayer.transform.position.y -1f, ThePlayer.transform.position.z) );
            }
            else
            {
                transform.LookAt(new Vector3(ThePlayer.transform.position.x, ThePlayer.transform.position.y, ThePlayer.transform.position.z) );
            }

            if(TargetDistance >= AllowedDistance)
            {
                FollowSpeed = 1;//0.1f;

                foreach (Animator a in CharacterCustomization.GetAnimators())
                    a.SetBool("walk", true);
                
                Debug.Log(" jalan player.position: " + ThePlayer.transform.position +" || follower: " + new Vector3(transform.position.x, ThePlayer.transform.position.y, transform.position.z) );

                if(ThePlayer.transform.position.y > transform.TransformDirection(Vector3.forward).y)
                {
                    transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, ThePlayer.transform.position.y -1f, transform.position.z), new Vector3(ThePlayer.transform.position.x, ThePlayer.transform.position.y, ThePlayer.transform.position.z), FollowSpeed * Time.deltaTime );
                }
                else
                {
                    transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, ThePlayer.transform.position.y, transform.position.z), new Vector3(ThePlayer.transform.position.x, ThePlayer.transform.position.y, ThePlayer.transform.position.z), FollowSpeed * Time.deltaTime );
                }
            }
            else
            {
                FollowSpeed = 0;
                foreach (Animator a in CharacterCustomization.GetAnimators())
                    a.SetBool("walk", false);

            }
        }
    }
}