using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(0, transform.position.y, player.gameObject.transform.position.z - 10);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 100);
    }
}
