using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Gavryk.PlaneationVideoGames;
using UnityEngine.Assertions.Must;

public class GameManager : MonoBehaviour {// timer y condicion de victoria al destruir todos 

    [SerializeField, HideInInspector] bool timerActive;
    [SerializeField] float timer;
    [SerializeField] TMP_Text timeTxt;

    [SerializeField] GameObject[] vessel;

    [SerializeField] GameObject vicotoryPanel;
    [SerializeField] GameObject losePanel;

    //private void Awake() {
    //    IncrementCronometer();
    //}
    void Start() {
        timerActive = true;
        timer = 0f;
    }
    void Update() {
        VictoryAndLosePanelActive();
        IncrementCronometer();
    }
    void IncrementCronometer() {
        if (timerActive == true) {
            timer += Time.deltaTime;
            timeTxt.text = timer.ToString("F2");
        }
    }
    void VictoryAndLosePanelActive() {
        // Elimina los objetos destruidos de la lista
        vessel = System.Array.FindAll(vessel, obj => obj != null); //lo busque en el internet
        if (vessel.Length == 0) {
            timerActive = false;
            vicotoryPanel.SetActive(true); 
            Debug.Log("¡Ganaste!");
        }
    }
    // implementar la derrota, pero como en este minijuego es imposible perder porque deberas de destruir todo sin importar el tiempo limite
    //pues no es neceario en este caso 
}


