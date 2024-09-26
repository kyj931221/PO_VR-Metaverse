using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    /*
     *  �÷��̾� ĳ������ Head / Left / Right ��ġ. 
     */
    public Transform playerHead;
    public Transform playerLeft;
    public Transform playerRight;

    /*
     *  XROrigin�� Head / Left / Right ��ġ.  
     */
    Transform xrHead;
    Transform xrLeft;
    Transform xrRight;

    PhotonView pv;

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
        }
    }
}
