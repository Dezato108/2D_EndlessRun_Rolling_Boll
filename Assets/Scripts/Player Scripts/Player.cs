using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRB;

    [SerializeField] float playerSpeed = 500f;
    [SerializeField] float directionalSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //The ball always rolling forward
        playerRB.velocity = Vector3.forward * playerSpeed * Time.deltaTime;

        MovePlayer();

        //Mobile Control 
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
    }

    private void MovePlayer()
    {
        //These codes only execute in unity editor
        #if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        float horizontalMoveDirection = Input.GetAxis("Horizontal");

        Vector3 newPosition = new Vector3(Mathf.Clamp(transform.position.x + horizontalMoveDirection, -2.5f, 2.5f), transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(gameObject.transform.position, newPosition, directionalSpeed * Time.deltaTime);
        #endif
    }
}
