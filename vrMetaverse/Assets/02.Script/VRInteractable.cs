using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class VRInteractable : XRGrabInteractable
{
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        GetComponent<PhotonView>().RequestOwnership(); //����信�� ������Ʈ�� ������(�Ҽ�)�� ���� 
        base.OnSelectEntering(args);
    }
}
