using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class MoveCube : MonoBehaviour
{

    public Controller controller;
    public Renderer cubeRenderer;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
        transform.Translate(new Vector3(axis.x, 0, axis.y) * speed * Time.deltaTime);
        float triggerColor = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, controller);
        //cubeRenderer.material.color = Color.Lerp(Color.green, Color.blue, triggerColor);

        if(OVRInput.Get(OVRInput.Button.One)) transform.Translate(Vector3.down*speed*Time.deltaTime);
        if(OVRInput.Get(OVRInput.Button.Two)) transform.Translate(Vector3.up*speed*Time.deltaTime);


    }
}
