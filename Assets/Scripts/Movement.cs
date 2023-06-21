using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    private Vector3 normalScale;
    private Vector3 lastPos;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite idleImg;

    void Start()
    {
        normalScale = transform.localScale;
    }

    void Update()
    {
        lastPos = transform.position;

        PointAtMouse();
        Vector3 dir = transform.eulerAngles;
        if (dir.z > 90 && dir.z+270 < 540)
        {
            transform.localScale = normalScale-new Vector3(0,normalScale.y*2,0);
        }
        else
        {
            transform.localScale = normalScale;
        }
        transform.eulerAngles = Vector3.zero;

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;

        if (Mathf.Abs(movement.x) > Vector2.zero.x && Mathf.Abs(movement.y) > Vector2.zero.y)
        {
            animator.enabled = true;
        }
        else
        {
            spriteRenderer.sprite = idleImg;
            animator.enabled = false;
        }

        rb.velocity = movement;

        transform.eulerAngles = dir;
    }

    void PointAtMouse()
    {
        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2) transform.position).normalized;

        // set vector of transform directly
        transform.right = direction;
    }
}
