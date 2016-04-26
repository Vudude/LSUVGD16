﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CameraOrbit : MonoBehaviour
{

    public Transform target;
    public float manualDistance = 5.0f;
    private float autoDistance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = 5f;
    public float distanceMax = 5f;

    private new Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * manualDistance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            manualDistance = Mathf.Clamp(manualDistance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            RaycastHit hit;
            if (Physics.Linecast(target.position, rotation * new Vector3(0.0f, 0.0f, -manualDistance) + new Vector3(target.position.x, target.position.y + 2, target.position.z), out hit))
            {
                autoDistance = hit.distance-.7f; //minus offset to help prevent clipping
				//autoDistance = Mathf.Lerp(autoDistance, hit.distance -1.0f, 3.0f * Time.deltaTime);
            }
            else
            {
                autoDistance = Mathf.Lerp(autoDistance, manualDistance, 5.0f * Time.deltaTime);
            }

            transform.position = rotation * new Vector3(0.0f, 0.0f, -autoDistance) + new Vector3(target.position.x, target.position.y + 2, target.position.z);
            //Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            //Vector3 position = rotation * negDistance + new Vector3(target.position.x, target.position.y + 2, target.position.z);

            transform.rotation = rotation;
            //transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}