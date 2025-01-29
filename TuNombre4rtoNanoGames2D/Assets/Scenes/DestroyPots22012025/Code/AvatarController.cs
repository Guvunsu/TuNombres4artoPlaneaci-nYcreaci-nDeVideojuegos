using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

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
        [SerializeField] Rigidbody2D rbPlayer2D;

        [SerializeField] Agent agent;
        Vector2 moveInput;
        [SerializeField] Animator animatorPlayer;
        [SerializeField] PlayerInput inputActions;

        [SerializeField] AnimatorController animatorController;
        [SerializeField] float walkSpeedPlayer;
        [SerializeField] float runningSpeedPlayer;
        [SerializeField, HideInInspector] int maxCurrentLife = 3;
        bool IsRunning;
        #endregion Variables

        #region UnityMethods
        void Start() {
            rbPlayer2D = GetComponent<Rigidbody2D>();
            animatorPlayer = GetComponent<Animator>();
            gameObject = GetComponent<GameObject>();

            agent = GetComponent<Agent>();
            agent = Agent.IDLE;
        }


        void Update() {
            switch (agent) {
                case Agent.IDLE:
                    //IDLEPlayer();
                    break;
                case Agent.MOVE:
                    //MovePlayer();
                    break;
                case Agent.ATTACK:

                    break;
            }
        }
        #endregion UnityMethods

        #region PublicMethods

        #region MovePlayer
        public void IDLEPlayer(InputAction.CallbackContext value) {
            animatorPlayer.SetBool("isMoving", false);
            rbPlayer2D.linearVelocity = Vector2.zero;
            //agent = Agent.IDLE;
        }
        public void MovePlayer(InputAction.CallbackContext value) {
            Debug.Log("Hola Mundoooooo :D");
            //Una posicion con el vector2d multiplicar 1 por 1 y 0 y con negativos para que se mueva en X y Y ejes 
            switch (agent = Agent.MOVE) {
                case Agent.MOVE:
                    moveInput = value.ReadValue<Vector2>();
                    walkSpeedPlayer = IsRunning ? runningSpeedPlayer : walkSpeedPlayer;
                    transform.position = Vector2.right * 1 * walkSpeedPlayer;
                    transform.position = Vector2.left * 1 * walkSpeedPlayer;
                    transform.position = Vector2.down * 1 * walkSpeedPlayer;
                    transform.position = Vector2.up * 1 * walkSpeedPlayer;
                    transform.position = moveInput;
                    rbPlayer2D.linearVelocity = moveInput * walkSpeedPlayer;
                    animatorPlayer.SetBool("isMoving", true);
                    // agent = Agent.MOVE;
                    break;
            }
        }
        public void StopMoving(InputAction.CallbackContext value) {
            moveInput = Vector2.zero;
            walkSpeedPlayer = 0;
            agent = Agent.IDLE;
        }
        public void RunPlayer(InputAction.CallbackContext value) {
            IsRunning = true;
            walkSpeedPlayer = runningSpeedPlayer * 2;
            agent = Agent.MOVE;
        }
        public void StopRunning(InputAction.CallbackContext value) {
            moveInput = Vector2.zero;
            IsRunning = false;
            runningSpeedPlayer = 0;
            agent = Agent.IDLE;
        }
        #endregion MovePlayer

        #region AttackPlayer
        public void AttackPlayer(InputAction.CallbackContext value) {
            rbPlayer2D.linearVelocity = Vector2.zero;
            switch (agent) {
                case Agent.ATTACK:
                    animatorPlayer.SetTrigger("Attack");
                    Invoke(nameof(EndAttack), 0.7f);
                    break;
                default:
                    break;
            }
        }
        public void EndAttack(InputAction.CallbackContext value) {
            agent = Agent.IDLE;
        }
        #endregion AttackPlayer

        public void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Jar")) {
                Destroy(collision.gameObject, 0.666f);
            }
        }
        public void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Water")) {
                maxCurrentLife -= 1;
                return;
            } else if (gameObject) {
                maxCurrentLife = 0;
                print("GameOver");
            }
        }


        #endregion PublciMethods

    }
}