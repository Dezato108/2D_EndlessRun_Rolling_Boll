using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraOffset = 10f;
    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(0, transform.position.y, player.gameObject.transform.position.z - cameraOffset);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 500);
    }
}
