using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Declarar variables:
    private UIManager uiManager;
    private TMP_Text questionText;

    [Header("UI objects")]
    [SerializeField] public GameObject instructiosPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener elementos gráficos UI:
        uiManager = FindObjectOfType<UIManager>();

    }

    // Update is called once per frame:
    void Update()
    {
        
    }

    private void LogicaJuego(int orden)
    {

    }

   
}
