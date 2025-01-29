using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ajoute un tag "Player" à ton personnage
        {
            gameObject.SetActive(false); // Cache la balle
        }
    }
}