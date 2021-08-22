
using System;
using UnityEngine;
using OVRTouchSample;
using System.Collections;
using System.Collections.Generic;

namespace OculusSampleFramework
{

    public class ActionAble : OVRGrabbable
    {
        public string m_materialColorField;

        GrabbableCrosshair m_crosshair;
        GrabManager m_crosshairManager;
        Renderer m_renderer;
        MaterialPropertyBlock m_mpb;


        public bool InRange
        {
            get { return m_inRange; }
            set
            {
                m_inRange = value;
                RefreshCrosshair();
            }
        }
        bool m_inRange;

        public bool Targeted
        {
            get { return m_targeted; }
            set
            {
                m_targeted = value;
                RefreshCrosshair();
            }
        }
        bool m_targeted;

        protected override void Start()
        {
            base.Start();
            m_crosshair = gameObject.GetComponentInChildren<GrabbableCrosshair>();
            m_renderer = gameObject.GetComponent<Renderer>();
            m_crosshairManager = FindObjectOfType<GrabManager>();
            m_mpb = new MaterialPropertyBlock();
            RefreshCrosshair();
        }

        void Update()
        {
            RefreshCrosshair();
        }

        void RefreshCrosshair()
        {
            RaycastHit hit;

            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);

            if (m_crosshair)
            {
                if (isGrabbed)
                {
                    if (hit.transform.tag == "door")
                    {
                        hit.transform.gameObject.GetComponent<Door>().ActionDoor();
                    }

                }
               
            }
            
        }
    }
}
