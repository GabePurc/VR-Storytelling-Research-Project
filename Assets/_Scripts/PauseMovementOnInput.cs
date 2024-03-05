using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace SWS
{
    public class PauseMovementOnInput : MonoBehaviour
    {
        public InputActionProperty pauseAction;

        public splineMove mover;

        private void Update()
        {
            if (pauseAction.action.ReadValue<float>()> 0.1f && !mover.IsPaused())
            {
                mover.Stop();
            }
            else if (pauseAction.action.ReadValue<float>() > 0.1f && mover.IsPaused())
            {
                mover.Resume();
            }
        }
    }

}

