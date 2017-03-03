using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassChanger : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private Rigidbody rb;
    private Transform tr;
    private Vector2 touchpad;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void IncreaseMass()
    {
        rb.mass += 1;
    }

    void DecreaseMass()
    {
        rb.mass -= 1;
    }

    void IncreaseVol()
    {
        tr.localScale += new Vector3(0.2f * tr.localScale.x, 0.2f * tr.localScale.y, 0.2f * tr.localScale.z);
    }

    void DecreaseVol()
    {
        tr.localScale -= new Vector3(0.2f * tr.localScale.x, 0.2f * tr.localScale.y, 0.2f * tr.localScale.z);
    }


    // Update is called once per frame
    void Update () {
   
        if (GetComponent<FixedJoint>())
        {
            rb = GetComponent<FixedJoint>().connectedBody;
            tr = GetComponent<FixedJoint>().connectedBody.gameObject.transform;

            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                touchpad = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

                if(touchpad.y > 0.66f)
                {
                    IncreaseMass();
                } else if(touchpad.y < -0.74f)
                {
                    DecreaseMass();
                } else if(touchpad.x > 0.7f)
                {
                    IncreaseVol();
                } else if(touchpad.x < -0.7f)
                {
                    DecreaseVol();
                }
                
            }
        }
	}
}