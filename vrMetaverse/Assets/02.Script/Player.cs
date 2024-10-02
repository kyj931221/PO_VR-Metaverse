using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    /*
     *  플레이어 캐릭터의 Head / Left / Right 위치. 
     */
    public Transform playerHead;
    public Transform playerLeft;
    public Transform playerRight;

    /*
     *  XROrigin의 Head / Left / Right 위치.  
     */
    Transform xrHead;
    Transform xrLeft;
    Transform xrRight;

    PhotonView pv;

    public Animator animatorL;
    public Animator animatorR;

    private void Start()
    {
        pv = GetComponent<PhotonView>();

        XROrigin o = FindObjectOfType<XROrigin>();

        xrHead = o.transform.Find("Camera Offset/Main Camera");
        xrLeft = o.transform.Find("Camera Offset/Left Controller");
        xrRight = o.transform.Find("Camera Offset/Right Controller");

        if (pv.IsMine)
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }
    }

    void SetAnimation(InputDevice input, Animator animator)
    {
        if(input.TryGetFeatureValue(CommonUsages.trigger,out float t))
        {
            animator.SetFloat("Trigger", t);
        }
        else
        {
            animator.SetFloat("Trigger", 0);
        }
        if (input.TryGetFeatureValue(CommonUsages.grip, out float g))
        {
            animator.SetFloat("Grip", g);
        }
        else
        {
            animator.SetFloat("Grip", 0);
        }
    }

    private void CopyTransform(Transform t, Transform s)
    {
        t.position = s.position;
        t.rotation = s.rotation;
    }

    private void Update()
    {
        if (pv.IsMine)
        {
            CopyTransform(playerHead, xrHead);
            CopyTransform(playerLeft, xrLeft);
            CopyTransform(playerRight, xrRight);

            SetAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand),animatorL);
            SetAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), animatorR);
        }
    }
}
