using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Gavryk.PlaneationVideoGames;

public class GameManager : MonoBehaviour
{// timer y condicion de victoria al destruir todos 

    [SerializeField] float timer;
    [SerializeField, HideInInspector] bool winner;
    [SerializeField] GameObject[] vessel;
    [SerializeField] TextMeshProUGUI txtPROGUI;
    AvatarController scriptAvatar;

    private void Awake()
    {
        IncrementCronometer();
    }
    void Start()
    {
        txtPROGUI = GetComponent<TextMeshProUGUI>();
        vessel = GetComponent<GameObject[]>();
    }

    void Update()
    {
        Victory();
    }
    void IncrementCronometer()
    {
        timer = 0;
        timer += Time.deltaTime / 60;
        txtPROGUI.text = timer.ToString();
    }
    void Victory()
    {
        if (scriptAvatar)
        {
            IncrementCronometer();
            int objects = 30;
            if (objects >= 0)
            {
                Destroy(vessel[0]);
                scriptAvatar.gameObject.SetActive(true);
                winner = true;
                print("Ganaste");
            }
        }
    }
}

