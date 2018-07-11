using UnityEngine;
using System.Collections;

public class DestoyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    
 
    private GameController gameController;
    public int scoreValue;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameControl");

        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        
        if (gameControllerObject == null)
            Debug.Log("Cannot find 'GameController' script");
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
            return;

        if (explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    
}
