using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel; // Référence au panel du popup

    void Start()
    {
        popupPanel.SetActive(true); // Affiche le popup au lancement
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false); // Cache le popup quand on appuie sur le bouton
    }
}
