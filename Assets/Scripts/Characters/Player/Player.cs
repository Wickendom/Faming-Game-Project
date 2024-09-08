using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public static Player Instance;
    private PlayerMovement PMovement;

    public Rigidbody2D RigidBody = null;
    public TileSoBase TilledTile = null;

    public Vector2Int FacingDirection { get; private set; }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        PMovement = GetComponent<PlayerMovement>();
       
        RigidBody = GetComponent<Rigidbody2D>();        
    }

    private void Start()
    {
        PMovement.Initialise(this);
    }

    public void UpdateDirection(Vector2 moveVector)
    {
        var xDir = (moveVector.x == 0) ? 0 : (int)Mathf.Sign(moveVector.x);
        var yDir = (moveVector.y == 0) ? 0 : (int)Mathf.Sign(moveVector.y);

        if (moveVector != Vector2.zero)
        {
            if(moveVector.y != 0)
            {
                FacingDirection = new Vector2Int(0,yDir);
            }
            else
            {
                FacingDirection = new Vector2Int(xDir, 0);
            }
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetFacingTilePosition()
    {
        var pos = GetPosition();
        pos.x += FacingDirection.x;
        pos.y += FacingDirection.y;
        return pos;
    }
}
