using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    private float leftBound = -15;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver && !playerController.isSprint)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        else if (!playerController.gameOver && playerController.isSprint)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * 2);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            //SpawnManagerPool.GetInstance().Return(gameObject);
        }
    }
}
