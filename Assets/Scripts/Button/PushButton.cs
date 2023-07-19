using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private Vector3 originalButtonPosition;
    [SerializeField] private float pushDistance = 0.5f;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private MenuManager menuManager;

    private void Start()
    {
        originalButtonPosition = button.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Hands") && !menuManager.buttonIsMoving)
        {
            Debug.Log("Collision");
            menuManager.buttonIsMoving = true;
            Debug.Log( button.name);

            StartCoroutine(PushButtonRoutine(button, originalButtonPosition));
        }
        
    }

    IEnumerator  PushButtonRoutine(GameObject buttonToInteract, Vector3 originalPosition)
    {
        while (Vector3.Distance(buttonToInteract.transform.position, originalPosition + new Vector3(0, 0, pushDistance)) > 0.01f)
        {
            buttonToInteract.transform.position = Vector3.MoveTowards(buttonToInteract.transform.position, originalPosition + new Vector3(0, 0, pushDistance), speed * Time.deltaTime);
            yield return null;
        }

        while (Vector3.Distance(buttonToInteract.transform.position, originalPosition) > 0.01f)
        {
            buttonToInteract.transform.position = Vector3.MoveTowards(buttonToInteract.transform.position, originalPosition, speed * Time.deltaTime);
            yield return null;
        }

        if (menuManager.buttonIsMoving && Vector3.Distance(button.transform.position, originalPosition) < 0.01f)
        {
            menuManager.buttonIsMoving = false;
        }

        if (button.name == "StartButton")
        {
            SceneManager.LoadScene("Introduction");
        }

        if (button.name == "AboutButton")
        {
            // Charger le matériau "AboutScreen" à partir du dossier "Materials"
            Material aboutScreenMaterial = Resources.Load<Material>("Materials/AboutScreen");

            // Trouver l'objet avec le tag "BeginScreen"
            GameObject beginScreenObject = GameObject.FindGameObjectWithTag("BeginScreen");

            // Vérifier si l'objet et le matériau ont été trouvés
            if (beginScreenObject != null && aboutScreenMaterial != null)
            {
                // Obtenir le composant Renderer de l'objet
                Renderer renderer = beginScreenObject.GetComponent<Renderer>();

                // Vérifier si le composant Renderer a été trouvé
                if (renderer != null)
                {
                    // Changer le matériau de l'objet
                    renderer.material = aboutScreenMaterial;
                }
                else
                {
                    Debug.LogError("No Renderer component found on the object with tag 'BeginScreen'.");
                }
            }
            else
            {
                Debug.LogError("Either the object with tag 'BeginScreen' or the material 'AboutScreen' was not found.");
                if (beginScreenObject == null)
                {
                    Debug.LogError("beginScreen is empty");
                }
                
                if (aboutScreenMaterial == null)
                {
                    Debug.LogError("aboutScreenMaterial is empty");
                }
            }
            
        }
    }
    
}