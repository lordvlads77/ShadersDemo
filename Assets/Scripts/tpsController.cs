using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpsController : MonoBehaviour
{
    public float _speed;
    public float _speedRot;
    public float _jumpStrength;

    Vector3 _movement;
    
    [Header("Referencia")]
    public Rigidbody rigi;
    
    
    [Header("CheckGround")]
    public Vector3 checkgroundPosition;
    public bool isGround;
    public float checkGroundRatio;
    public LayerMask checkGroundMask;
    

    private void FixedUpdate()
    {
        _movement.x = Input.GetAxisRaw("Horizontal") * _speed;
        _movement.z = Input.GetAxisRaw("Vertical") * _speed;
        _movement = transform.TransformDirection(_movement); // Transforma una direccion local en direccion del mundo.

        isGround = Physics.CheckSphere(transform.position + checkgroundPosition, checkGroundRatio, checkGroundMask);
        
        _movement.y = rigi.velocity.y; // Permite que la gravedad siga funcionando
        rigi.velocity = _movement; // Aplicamos
    }

    private void Update()
    {
        /*if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * -_speedRot * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * _speedRot * Time.deltaTime);
        }*/
        if (Input.GetKey(KeyCode.Space) && isGround) // KeyDown y KeyUp no funcionan correctamente en el FixedUpdate
        {
            rigi.AddForce(Vector3.up * _jumpStrength);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + checkgroundPosition, checkGroundRatio);
    }
}
