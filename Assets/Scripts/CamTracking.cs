using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTracking : MonoBehaviour
{

    public float lerpFactor;

    public Transform cam;
    public Transform target;

    private Vector3 offset;

    void Start()
    {
        offset = cam.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = (target.position + offset).x;
        float y = 0;
        float z = (target.position + offset).z;
        cam.position = new Vector3(x, y, z);
        //ssVector3 newCamPos = Vector3.Lerp(cam.position, target.position + offset, lerpFactor * Time.deltaTime);
        //cam.position = Vector3.Lerp(cam.position, target.position + offset, lerpFactor * Time.deltaTime);
    }
}
