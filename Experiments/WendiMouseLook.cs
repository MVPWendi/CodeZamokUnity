using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendiMouseLook : MonoBehaviour
{
    public float MouseSens;
    private Transform ParentTrans;
    public Transform Head;
    // Start is called before the first frame update
    void Start()
    {
        //   ParentTrans = transform.parent.gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    float xRotation = 0f;
    private float desiredX;
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;
        Vector3 rot = gameObject.transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;

        //Rotate, and also make sure we dont over- or under-rotate.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        //  gameObject.transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
        transform.localRotation = Quaternion.Euler(0f, desiredX, 0f);
        Head.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
