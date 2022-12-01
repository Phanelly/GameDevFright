using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed = 10f;

    private Transform t;
    private GameObject player;


    void Start()
    {
        t = GetComponent<Transform>();

        player = GameObject.Find("Player");
    }

    void Update()
    {
        t.Rotate(new Vector3(0, rotatingSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var script = player.GetComponent<NewCharacterController>();

        script.AddScore();

        Destroy(this.gameObject);
    }

}
