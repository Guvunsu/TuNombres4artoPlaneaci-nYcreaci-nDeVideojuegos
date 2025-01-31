using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

namespace Gavryk.PlaneationVideoGames
{
    // hacerlo nostalgico con Aplicaction.targetFrameRate= 24fps
    // estudiar los apuntadores de C++ 
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
        // es cuando es la primera vexz que arranque, 1 vez 
        // el awake es cuado se prende o se apaga el objecto con el setactive o el check box del object , n veces

        // ambos son de activaciones de objetos 
        void Start()
        {
            rbPlayer2D = gameObject.GetComponent<Rigidbody2D>();
            animatorPlayer = gameObject.GetComponent<Animator>();
            _currentAgentState = States.IDLE;
        }


        void FixedUpdate()
        {
            switch (_currentAgentState)
            {
                case States.IDLE:
                    rbPlayer2D.linearVelocity = Vector2.zero;
                    break;
                case States.MOVING:
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
            StateMechanic(StateMechanics.STOP);
        }
        public void RunPlayer(InputAction.CallbackContext value)
        {
            IsRunning = true;
            walkSpeedPlayer = runningSpeedPlayer * 2;
            _currentAgentState = States.MOVING;
            StateMechanic(StateMechanics.MOVE);
        }
        public void StopRunning(InputAction.CallbackContext value)
        {
            moveInput = Vector2.zero;
            IsRunning = false;
            runningSpeedPlayer = 0;
            _currentAgentState = States.IDLE;
            StateMechanic(StateMechanics.STOP);
        }
        #endregion MovePlayer

        #region AttackPlayer
        public void AttackPlayer(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                moveInput = value.ReadValue<Vector2>();
                _currentAgentState = States.ATTACKING;
                StateMechanic(StateMechanics.ATTACK);
                animatorPlayer.SetBool("Attack", true);
                Invoke(nameof(AttackPlayer), 0.7f); // no se si quitar esta linea de codigo 
            }
            else if (value.canceled)
            {
                _currentAgentState = States.IDLE;  //TODO: Corregir
                StateMechanic(StateMechanics.STOP);
            }
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