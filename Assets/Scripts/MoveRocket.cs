using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    [SerializeField] float thrustFactor = 500f;
    [SerializeField] float tiltFactor = 50f;
    Rigidbody rigidBody;
    bool applyThrust;

    private void Awake()
    {
        /*
         * Get the RigidBody-component of the body we want to move.
         */
        rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        /*
         * If 'space' is pressed, apply thrust.
         */
        applyThrust = Input.GetKey(KeyCode.Space);
        
        /*
         * Tilt is received as an axial input, e.g. right- and left-arrow.
         */
        float tilt = Input.GetAxis("Horizontal");

        /*
         * Since floating-points can be a PITA when it comes to comparing,
         * we simply make an approximation to see if it's near 0.
         * If so, ignore this since it probaly doesn't matter.
         */
        if (!Mathf.Approximately(tilt, 0f))
        {
            /*
             * Freeze rotation, or the rocket will be uncontrolable.
             */
            rigidBody.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, (tilt * tiltFactor * Time.deltaTime))));
        }
        
        rigidBody.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        /*
         * If trust has to be applied, apply it as a relative force, multiplied by a factor and time passed.
         */
        if (applyThrust)
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustFactor * Time.deltaTime);
        }
    }
}