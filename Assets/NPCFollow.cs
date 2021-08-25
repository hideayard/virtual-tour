using System.Collections;
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
    public float AllowedDistance = 1.2f;
    public float FollowSpeed;
    public RaycastHit Shot;
    public bool startFollow = true;

    void Update()
    {
        Debug.Log( "TargetDistance: " + TargetDistance );
        // Debug.Log( "transform.TransformDirection(Vector3.forward): " + transform.TransformDirection(Vector3.forward) + " <> follower: " + transform.position);

        transform.LookAt(ThePlayer.transform);

        // transform.LookAt(new Vector3(ThePlayer.transform.position.x, (ThePlayer.transform.position.y -0.3f ), ThePlayer.transform.position.z) );
        TargetDistance = Vector3.Distance(transform.position, ThePlayer.transform.position);

        if(Physics.Raycast(new Vector3(transform.position.x, transform.TransformDirection(Vector3.forward).y, transform.position.z) ,transform.TransformDirection(Vector3.forward),out Shot))
        {
            // TargetDistance = Shot.distance;
            //lihat sekali lagi
            
          

            if(TargetDistance >= AllowedDistance && startFollow)
            {
                FollowSpeed = 1;//0.1f;

                foreach (Animator a in CharacterCustomization.GetAnimators())
                    a.SetBool("walk", true);
                
                // Debug.Log(" jalan player.position: " + ThePlayer.transform.position +" || follower: " + new Vector3(transform.position.x, ThePlayer.transform.position.y, transform.position.z) );

                    transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, check_position_y(transform.transform.position.y ), transform.position.z), new Vector3(ThePlayer.transform.position.x, check_position_y(ThePlayer.transform.position.y), ThePlayer.transform.position.z), FollowSpeed * Time.deltaTime );
               
            }
            else
            {
                FollowSpeed = 0;
                foreach (Animator a in CharacterCustomization.GetAnimators())
                    a.SetBool("walk", false);

            }
        }
        else
        {
             FollowSpeed = 0;
                foreach (Animator a in CharacterCustomization.GetAnimators())
                    a.SetBool("walk", false);

        }
        
    }

    float check_position_y(float y1)
    {   
        return y1;
    }

    
}
