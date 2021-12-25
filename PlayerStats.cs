using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [Space]
    [SerializeField] private float digDamage;
    [SerializeField] private float digRange;

    public float JumpForce
    {
        get { return jumpForce; }
        set { jumpForce = value; }
    }


    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }


    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float DigRange { get => digRange; set => digRange = value; }
    public float DigDamage { get => digDamage; set => digDamage = value; }
}
