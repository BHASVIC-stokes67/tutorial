using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0)
        {
            body.linearVelocity = new Vector2(-speed, body.linearVelocity.y);
        }
        else
        {
            body.linearVelocity = new Vector2(speed, body.linearVelocity.y);
        }
    }


}
