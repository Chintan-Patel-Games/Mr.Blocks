using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private float horizontalInput, verticalInput;
    public LevelManager levelManager;
    public UIManager uIManager;
    private SoundManager soundManager;

    private void Start()
    {
        // Get the SoundManager from the scene
        soundManager = FindObjectOfType<SoundManager>();

        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
        }
    }

    private void Update()
    {
        GetInput();
        MovePlayer();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        Vector3 moveDelta = moveDirection.normalized * speed * Time.deltaTime;
        transform.position += moveDelta;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        soundManager.PlayGameOverAudio();
        levelManager.OnPlayerDeath();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        soundManager.PlayLevelCompleteAudio();
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }
}