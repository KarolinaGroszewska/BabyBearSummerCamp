using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Txnyxo5M6D0
//https://www.youtube.com/watch?v=Qd3hkKM-UTI

public class CameraZoom : MonoBehaviour
{
    //zoom
    private Camera ZoomCamera;
    public float ScrollSpeed = 10;

    //move
    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;
    private bool drag = false;

    // Start is called before the first frame update
    void Start()
    {
        //zoom
        ZoomCamera = Camera.main;

        //move
        ResetCamera = Camera.main.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //zoom
        if (ZoomCamera.orthographic)
        {
            ZoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }

        //move
        if (Input.GetMouseButton(0))
        {
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        if (drag)
        {
            Camera.main.transform.position = Origin - Difference;
        }
    }
}
