using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour
{
    public Camera cam;
    public float mouseHorizontal = 3f;
    public float mouseVertical = 3f;

    float h_mouse;
    float v_mouse;

    public float moveSpeed = 2;
    public float runSpeed = 8;

    float h;
    float v;

    void Update()
    {
        Move();
    }
    void Move()
    {
        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse = mouseVertical * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h_mouse, 0);
        cam.transform.Rotate(v_mouse, 0, 0);

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);

        if (Input.GetButton("Fire3"))
            transform.Translate(direction * runSpeed * Time.deltaTime);
        else
            transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
