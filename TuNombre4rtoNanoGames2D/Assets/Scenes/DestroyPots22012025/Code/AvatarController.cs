using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

namespace Gavryk.PlaneationVideoGames
{

    #region ENUM
    public enum States
    {
        IDLE,
        MOVING,
        ATTACKING
    }

    public enum StateMechanics  //Actions
    {
        STOP,
        MOVE,
        ATTACK
    }

    #endregion ENUM

    public class AvatarController : MonoBehaviour
    {
        #region Variables
        [SerializeField] Rigidbody2D rbPlayer2D;

        [SerializeField] States _currentAgentState;
        Vector3 moveInput;
        [SerializeField] Animator animatorPlayer;
        [SerializeField] PlayerInput inputActions;

        [SerializeField] AnimatorController animatorController;
        [SerializeField] float walkSpeedPlayer;
        [SerializeField] float runningSpeedPlayer;
        [SerializeField, HideInInspector] int maxCurrentLife = 3;
        bool IsRunning;
        #endregion Variables

        #region UnityMethods
        void Start()
        {
            rbPlayer2D = gameObject.GetComponent<Rigidbody2D>();
            animatorPlayer = gameObject.GetComponent<Animator>();
            _currentAgentState = States.IDLE;
        }


        void Update()
        {
            switch (_currentAgentState)
            {
                case States.IDLE:
                    //IDLEPlayer();
                    rbPlayer2D.linearVelocity = Vector2.zero;
                    break;
                case States.MOVING:
                    //MovePlayer();
                    rbPlayer2D.linearVelocity = moveInput * walkSpeedPlayer; //*Time.deltaTime
                    break;
                case States.ATTACKING:

                    break;
            }
        }
        #endregion UnityMethods

        #region PublicMethods

        #region MovePlayer

        public void MovePlayer(InputAction.CallbackContext value)
        {
            Debug.Log("Hola Mundoooooo :D");
            if (value.performed)
            {
                //Una posicion con el vector2d multiplicar 1 por 1 y 0 y con negativos para que se mueva en X y Y ejes 
                moveInput = value.ReadValue<Vector2>();
                walkSpeedPlayer = IsRunning ? runningSpeedPlayer : walkSpeedPlayer;
                //TRANSLATION FORMULA
                //transform.position += walkSpeedPlayer * moveInput * Time.deltaTime;
                _currentAgentState = States.MOVING; //TODO: Corregir
                StateMechanic(StateMechanics.MOVE);
            }
            else if (value.canceled)
            {
                _currentAgentState = States.IDLE;  //TODO: Corregir
                StateMechanic(StateMechanics.STOP);
            }
        }
        public void StopMoving(InputAction.CallbackContext value)
        {
            moveInput = Vector2.zero;
            walkSpeedPlayer = 0;
            _currentAgentState = States.IDLE;
        }
        public void RunPlayer(InputAction.CallbackContext value)
        {
            IsRunning = true;
            walkSpeedPlayer = runningSpeedPlayer * 2;
            _currentAgentState = States.MOVING;
        }
        public void StopRunning(InputAction.CallbackContext value)
        {
            moveInput = Vector2.zero;
            IsRunning = false;
            runningSpeedPlayer = 0;
            _currentAgentState = States.IDLE;
        }
        #endregion MovePlayer

        #region AttackPlayer
        public void AttackPlayer(InputAction.CallbackContext value)
        {
            rbPlayer2D.linearVelocity = Vector2.zero;
            switch (_currentAgentState)
            {
                case States.ATTACKING:
                    animatorPlayer.SetTrigger("Attack");
                    Invoke(nameof(EndAttack), 0.7f);
                    break;
                default:
                    break;
            }
        }
        public void EndAttack(InputAction.CallbackContext value)
        {
            _currentAgentState = States.IDLE;
        }
        #endregion AttackPlayer

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Jar"))
            {
                Destroy(collision.gameObject, 0.666f);
            }
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Water"))
            {
                maxCurrentLife -= 1;
                return;
            }
            else if (gameObject)
            {
                maxCurrentLife = 0;
                print("GameOver");
            }
        }

        // siempre debe ser positivo , acertivo para que funcione las acciones d emi animator , convirtiendolo de stringo , porque es una palabra y en verdadero
        //  para que transiccione entre animaciones cuando le das el input 
        public void StateMechanic(StateMechanics value)
        {
            animatorPlayer.SetBool(value.ToString(), true);
        }


        #endregion PublciMethods

    }
}