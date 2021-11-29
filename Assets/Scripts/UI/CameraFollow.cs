using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Fields
    [SerializeField] private GameObject followObject;
    [SerializeField] private Vector2 followOffset;
    [SerializeField] private float speed = 10f;

    private Vector2 _threshold;
    private Rigidbody2D _rb;

    // Basic methods
    void Start()
    {
        _threshold = CalculateThreshold();
        _rb = followObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if (Mathf.Abs(xDifference) >= _threshold.x)
        {
            newPosition.x = follow.x;
        }
        if (Mathf.Abs(yDifference) >= _threshold.y)
        {
            newPosition.y = follow.y;
        }
        float moveSpeed = _rb.velocity.magnitude > speed ? _rb.velocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    // User methods
    private Vector3 CalculateThreshold()
    {
        Camera cam = Camera.main;

        if (cam)
        {
            Rect aspect = cam.pixelRect;
            Vector2 t = new Vector2(cam.orthographicSize * aspect.width / aspect.height, cam.orthographicSize);
            t.x -= followOffset.x;
            t.y -= followOffset.y;
            return t;
        }
        return new Vector3(0, 0, 0);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
    #endif
}
