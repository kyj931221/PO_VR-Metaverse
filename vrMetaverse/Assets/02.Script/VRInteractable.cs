using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class VRInteractable : XRGrabInteractable
{
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        GetComponent<PhotonView>().RequestOwnership(); //포톤뷰에서 오브젝트의 소유권(소속)이 변경 
        base.OnSelectEntering(args);
    }
}
