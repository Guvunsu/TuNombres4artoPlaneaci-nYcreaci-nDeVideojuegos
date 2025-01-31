using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Gavryk.PlaneationVideoGames;

public class GameManager : MonoBehaviour
{// timer y condicion de victoria al destruir todos 

    //https://medium.com/@eveciana21/creating-a-stopwatch-timer-in-unity-f4dff748030d

    [SerializeField] float timer;
    [SerializeField] TMP_Text timeTxt;

    [SerializeField, HideInInspector] bool winner;
    [SerializeField] TMP_Text victoryTxt;

    [SerializeField] GameObject[] vessel;
    //[SerializeField] TextMeshProUGUI DerrotaTxt;
    AvatarController scriptAvatar;

    private void Awake()
    {
        IncrementCronometer();
    }
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        VictoryAndLose();
    }
    void IncrementCronometer()
    {
        timer += Time.deltaTime;
        timeTxt.text = "Tiempo:" + " " ;
    }
    void VictoryAndLose()
    {
        if (scriptAvatar)
        {
            victoryTxt.gameObject.SetActive(false);
            IncrementCronometer();
            int objects = 59;
            if (objects >= 0)
            {
                Destroy(vessel[0]);
                scriptAvatar.gameObject.SetActive(true);
                winner = true;
                victoryTxt.gameObject.SetActive(true);
                print("Ganaste");
            }
            // implementar la derrota, pero como en este minijuego es imposible perder porque deberas de destruir todo sin importar el tiempo limite
            //pues no es neceario en este caso 
        }
    }
}

