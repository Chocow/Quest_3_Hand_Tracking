using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Hands.Gestures;


namespace UnityEngine.XR.Hands.Samples.GestureSample
{

    public class CheckForPistolGest : MonoBehaviour
    {

        [SerializeField] XRHandTrackingEvents m_HandTrackingEvents;


        [SerializeField] ScriptableObject m_HandShapeOrPose;
        [SerializeField] UnityEvent m_GesturePerformed;
        [SerializeField] UnityEvent m_GestureEnded;

        XRHandShape m_HandShape;
        XRHandPose m_HandPose;
        bool m_WasDetected;
        bool m_PerformedTriggered;
        float m_TimeOfLastConditionCheck;
        float m_HoldStartTime;

        void OnEnable()
        {
            m_HandTrackingEvents.jointsUpdated.AddListener(OnJointsUpdated);

            m_HandShape = m_HandShapeOrPose as XRHandShape;
        }
        void OnDisable()
        {
            m_HandTrackingEvents.jointsUpdated.RemoveListener(OnJointsUpdated);
        }

        bool m_ExecutedOnce = false;

        void OnJointsUpdated(XRHandJointsUpdatedEventArgs eventArgs)
        {
            if (!isActiveAndEnabled)
                return;

            var detected =
                m_HandTrackingEvents.handIsTracked &&
                m_HandShape != null && m_HandShape.CheckConditions(eventArgs) ||
                m_HandPose != null && m_HandPose.CheckConditions(eventArgs);

            if (m_WasDetected && !detected)
            {
                m_GestureEnded?.Invoke();
                m_PerformedTriggered = false;
            }

            m_WasDetected = detected;

            if (!m_PerformedTriggered && detected)
            {
                m_GesturePerformed?.Invoke();
                m_PerformedTriggered = true;
                ExecuteOnce();
            }
        }

        void ExecuteOnce()
        {
            Debug.Log("Pistol gesture detected");
        }
    }
}
