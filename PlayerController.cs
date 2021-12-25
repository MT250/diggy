using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private GameObject pickaxePoint;
    PlayerStats playerStats;
    AudioSource audioSource;

    [Header("Sounds")]
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip swingSound;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !GameManager.instance.isGameOver)
        {
            if (!GameManager.instance.isPaused) Dig();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pickaxePoint.SetActive(false);
            audioSource.clip = swingSound;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.PauseGame();
        }
    }

    private void OnBecameInvisible()
    {
        Invoke("GameOver", 1f);
    }

    private void GameOver()
    {
        GameManager.instance.GameOver();
    }


    private void Dig()
    {
        pickaxePoint.SetActive(true);
        pickaxePoint.transform.Rotate(Vector3.forward * 12.5f);

        if (!audioSource.isPlaying) audioSource.PlayOneShot(audioSource.clip);

        var distanceToBlock = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (distanceToBlock < playerStats.DigRange)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0);

            if (hit2D)
            {
                #if UNITY_EDITOR 
                Debug.Log(hit2D.collider.name);
                #endif

                var block = hit2D.collider.GetComponent<Block>();
                if (block != null)
                {
                    block.TakeDamage(playerStats.DigDamage * Time.deltaTime);
                    audioSource.clip = hitSound;
                }
                else
                {
                    audioSource.clip = swingSound;
                }
            }
        }
    }
}
