using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private GameObject InventoryCanvas;
    private Vector2 input;
    private bool show_inventory;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        show_inventory = false;
        InventoryCanvas.SetActive(show_inventory);
    }

    void Update()
    {
        // movement input
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // toggle inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            show_inventory = !show_inventory;
            InventoryCanvas.SetActive(show_inventory);
        }
    }

    void FixedUpdate()
    {
        // update player velocity
        //   without normalization the player would move faster when moving diagonally
        body.velocity = input.normalized * speed;
    }
}
