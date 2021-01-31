using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace ARVideoTest
{
    using System;

    public class ARCheck : MonoBehaviour
    {
        [SerializeField] private ARSession session;

        private IEnumerator Start()
        {
            if (ARSession.state == ARSessionState.None || ARSession.state == ARSessionState.CheckingAvailability)
            { yield return ARSession.CheckAvailability(); }
            if (ARSession.state == ARSessionState.Unsupported)
            {
                // Start some fallback experience for unsupported devices
            }
            else { this.session.enabled = true; }
        }

        private void OnValidate()
        {
            if (this.session == null)
            { this.session = this.GetComponent<ARSession>(); }
        }
    }
}