//using UnityEngine;

//public class ObjectsManager : MonoBehaviour
//{
//    [SerializeField] GameObject _gameObjectVessel;
//    [SerializeField] Rigidbody2D _rb2DJamJar;
//    [SerializeField] float vesselSpawnMaxPos;
//    [SerializeField] float vesselSpawnMinPos;
//    bool vesselIsGround = true;
//    // 84 jams
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            Debug.Log("Estoy tocando el jugador");
//            Destroy(gameObject, 0.5f);
//            Debug.Log("Lo estoy tocando y lo desactivo o destruyo");
//        }
//        //Debug.Log("Trato el suelo "); // checar esto 
//        //if (collision.gameObject.CompareTag("Ground") && vesselIsGround)
//        //{
//        //    Debug.Log("Toco el suelo ");
//        //}
//    }

//    //void VesselSpawning()
//    //{
//    //    if (_gameObjectVessel == null)
//    //    {

//    //        //Debug.Log("Se activa el gameObject");
//    //        //_gameObjectVessel.SetActive(true);
//    //        Debug.Log("Se spawnea gameObject max y min ");
//    //        Vector2 vesselPos = new Vector2(vesselSpawnMinPos, vesselSpawnMaxPos);
//    //        Debug.Log("Se spawnea gameObject random");
//    //        var vesselPosition = UnityEngine.Random.Range(1f, 12f);

//    //        // hacer un spawneo de varias vessels

//    //    }
//    //}
//    void Start()
//    {
//        _rb2DJamJar.GetComponent<Rigidbody2D>();
//        _gameObjectVessel = GetComponent<GameObject>();
//        //VesselSpawning();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
