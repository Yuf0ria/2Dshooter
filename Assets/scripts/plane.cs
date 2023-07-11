using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class plane : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rigidBody;
    private Vector2 movementInput;
    private Animator anim;
    public int cash;
    public int hp;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("vertical", movementInput.y);



    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject Arrow = Instantiate(Arrowprefab, Arrowspawnpoint.position, Quaternion.identity);
            Rigidbody2D rb = Arrow.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * ArrowSpeed;
        }
    }

    private void LateUpdate()
    {
        rigidBody.velocity = movementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    public GameObject Arrowprefab;
    public Transform Arrowspawnpoint;
    public float ArrowSpeed;
}
