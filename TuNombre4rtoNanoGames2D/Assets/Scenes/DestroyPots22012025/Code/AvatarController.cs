using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gavryk.PlaneationVideoGames {
    public class AvatarController : MonoBehaviour {
        #region ENUM
        enum Agent {
            IDLE,
            MOVE,
            ATTACK
        }
        #endregion ENUM

        #region Variables
        [SerializeField] GameObject gameObject;
        [SerializeField] GameObject targetJamJar;
        [SerializeField] Rigidbody2D rbPlayer;
        [SerializeField] Rigidbody2D rbJamJar;

        [SerializeField] Animation animationPlayer;
        [SerializeField] Animator animatorPlayer;
        [SerializeField] AnimatorController animatorController;
        [SerializeField] Agent agent;
        [SerializeField] float speedNormalPlayer;
        [SerializeField] float runningPlayer;
        bool IsTouchJamJar;
        #endregion Variables

        #region UnityMethods
        void Start() {
            rbPlayer = GetComponent<Rigidbody2D>();
            rbJamJar = GetComponent<Rigidbody2D>();
            agent = GetComponent<Agent>();
            agent = Agent.IDLE;
        }

        void Update() {
            switch (agent) {
                case Agent.IDLE:
                    IDLEPlayer();
                    break;
                case Agent.MOVE:
                    MovePlayer();
                    break;
                case Agent.ATTACK:

                    break;
            }
        }
        #endregion UnityMethods

        #region PrivateMethods

        #region MovePlayer
        void IDLEPlayer(InputAction.CallbackContext value) {
            //animationPlayer = ;
        }
        void MovePlayer(InputAction.CallbackContext value) {



        }
        void RunPlayer(InputAction.CallbackContext value) {

        }
        #endregion MovePlayer

        #region AttackPlayer
        void AttackPlayer(InputAction.CallbackContext value) {

        }
        #endregion AttackPlayer

        #endregion PrivateMethods

        #region PublicMethods
        public void OnCollisionEnter2D(Collision2D collision) {

        }
        public void OnTriggerEnter(Collider other) {

        }


        #endregion PublciMethods

    }
}