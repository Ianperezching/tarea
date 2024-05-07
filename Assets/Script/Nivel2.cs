using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Nivel 2");
    }
}
