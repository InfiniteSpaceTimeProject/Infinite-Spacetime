using System.Collections;
using System.Net.Security;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 500f;
    [SerializeField] float turnSpeed = 100f;
    Transform myt;
    [SerializeField] float boost = 1.1f;

    void Awake()
    {
        myt = transform;
    }
    void Update()
    {
        Thrust();
        Turn();
 
   }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll")* 10;
        myt.Rotate(-pitch, yaw, -roll);
     
    }



    void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            if (Input.GetAxis("Boost") < 0)
            {
                transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical")*boost;
            }
            else
            {
                transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

            }
        }
    }
}
