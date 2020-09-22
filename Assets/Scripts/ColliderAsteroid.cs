using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAsteroid : MonoBehaviour
{
    public GameObject explosion; 
    public GameObject playerExplosion;

    public int valueScore;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.IncrementScore(valueScore);
        gameController.increaseKilledEnemies();

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
