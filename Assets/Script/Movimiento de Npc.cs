using System.Collections;
using UnityEngine;

using TMPro;

public class NPCMovement : MonoBehaviour
{
    public Transform[] movePoints;
    public float timeAtEachPoint = 2f;
    public int currentPointIndex = 0;
    public Canvas dialogCanvas;
    public TMP_Text dialogText;

    private void Start()
    {
        if (movePoints.Length > 0)
        {
            StartCoroutine(MoveBetweenPoints());
        }
    }

    private IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            Transform targetPoint = movePoints[currentPointIndex];
            yield return StartCoroutine(MoveTo(targetPoint.position));

            // Esperar un tiempo en el punto
            yield return new WaitForSeconds(timeAtEachPoint);

            // Ir al siguiente punto
            currentPointIndex = (currentPointIndex + 1) % movePoints.Length;
        }
    }

    private IEnumerator MoveTo(Vector3 targetPosition)
    {
        float journeyLength = Vector3.Distance(transform.position, targetPosition);
        float startTime = Time.time;

        while (transform.position != targetPosition)
        {
            float distCovered = (Time.time - startTime) * 1f; // Cambia la velocidad aquí
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, targetPosition, fracJourney);
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Mostrar diálogo en el Canvas
            dialogCanvas.gameObject.SetActive(true);
            dialogText.text = "Hola, ¿cómo estás?";

            // Detener el movimiento del NPC
            StopAllCoroutines();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ocultar diálogo en el Canvas
            dialogCanvas.gameObject.SetActive(false);

            // Continuar el movimiento del NPC
            StartCoroutine(MoveBetweenPoints());
        }
    }
}
