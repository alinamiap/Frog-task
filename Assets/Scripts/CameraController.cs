//Camera follows player. allows camera rotation
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Rotation Info")]
    public Transform player;
    public Vector3 offset = new Vector3(5, 3, -4); //camera offset
    public float rotationSpeed = 45f;
    private float currentAngle = 0f;
    private float targetAngle = 0f;
    private float smoothSpeed = 5f;

    [Header("Zoom Info")]
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    void LateUpdate()
    {
        if(player == null) return;

        Vector3 targetPosition = player.position + Quaternion.Euler(0, currentAngle, 0) * offset;
        transform.position = targetPosition;

        transform.LookAt(player.position);
    }

    void Update()
    {
        //Zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        offset = offset.normalized * Mathf.Clamp(offset.magnitude - scroll * zoomSpeed, minZoom, maxZoom);

        //Rotation
        if(Input.GetKeyDown(KeyCode.Q))
        {
            targetAngle -= rotationSpeed;
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            targetAngle += rotationSpeed;
        }
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * smoothSpeed);
    }
}