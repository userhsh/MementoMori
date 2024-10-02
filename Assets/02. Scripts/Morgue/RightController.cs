using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour
{
    public GameObject RightHandRender;

    public void RightHandRenderIdle()
    {
        RightHandRender.SetActive(true);
    }

    public void RightHandRenderGripping()
    {
        RightHandRender.SetActive(false);
    }
}
