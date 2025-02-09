using UnityEngine;

namespace SotomaYorch.Physics
{
    #region Structs

    [System.Serializable] //Conversion of bytes for the HDD
    public struct TransformationParameters
    {
        [SerializeField] public Vector3 direction;
        public float speed;
        //public float time; -> Time.fixedDeltaTime;
    }

    #endregion

    public class RealTimeTransformations : MonoBehaviour
    {
        #region Parameters/Knobs

        [SerializeField] protected TransformationParameters translationParameters;
        [SerializeField] protected TransformationParameters rotationParameters;
        [SerializeField] protected TransformationParameters scaleParameters;

        #endregion

        #region RuntimeVariables

        #endregion

        #region UnityMethods

        private void FixedUpdate()
        {
            //Time.fixedDeltaTime;  NO Time.deltaTime;

            //A) Position acummulation with the DeLorean Vector
            //transform.position +=  //Space.World
            //    translationParameters.speed *
            //    translationParameters.direction *
            //    Time.fixedDeltaTime;

            //B) Translate method with the DeLorean Vector
            //transform.Translate(
            //    translationParameters.speed *
            //    translationParameters.direction *
            //    Time.fixedDeltaTime, Space.World
            //    );

            //A.1) Local translation
            //transform.localPosition +=
            //    translationParameters.speed *
            //    translationParameters.direction *
            //    Time.fixedDeltaTime;

            //B.1) Local translation -> Self
            transform.Translate(
                translationParameters.speed *
                translationParameters.direction *
                Time.fixedDeltaTime, Space.Self //default
                );

        }

        #endregion

    }
}