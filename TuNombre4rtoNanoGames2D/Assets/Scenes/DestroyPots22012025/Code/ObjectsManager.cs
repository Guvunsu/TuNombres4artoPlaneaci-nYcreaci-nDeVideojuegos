using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    [SerializeField] GameObject _gameObjectVessel;
    [SerializeField] float vesselSpawnMaxPos;
    [SerializeField] float vesselSpawnMinPos;
    bool vesselIsGround = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Estoy tocando el jugador");
            Destroy(gameObject, 1f);
            Debug.Log("Estoy tocando y lo desactivo");
        }
        Debug.Log("Trato el suelo "); // checar esto 
        if (collision.gameObject.CompareTag("Ground") && vesselIsGround)
        {
            Debug.Log("Toco el suelo ");
        }
    }

    void VesselSpawning()
    {
        if (_gameObjectVessel == null)
        {

            //Debug.Log("Se activa el gameObject");
            //_gameObjectVessel.SetActive(true);
            Debug.Log("Se spawnea gameObject max y min ");
            Vector2 vesselPos = new Vector2(vesselSpawnMinPos, vesselSpawnMaxPos);
            Debug.Log("Se spawnea gameObject random");
            var vesselPosition = UnityEngine.Random.Range(1f, 12f);

            // hacer un spawneo de varias vessels

        }
    }
    void Start()
    {
        _gameObjectVessel.GetComponent<Rigidbody2D>();
        _gameObjectVessel = GetComponent<GameObject>();
        VesselSpawning();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
