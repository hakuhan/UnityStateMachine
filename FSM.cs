using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaiFSM
{

    public class FSM
    {
        protected FSMState m_currentState = new FSMState();
        /************************************************/

        // Update is called once per frame
        public void Update()
        {
            // Debug.Log("FSM update!");
            m_currentState.Update();
        }

        /************************************************/
        public void SwitchState(FSMState newState)
        {
            // go to end state
            m_currentState.End();

            m_currentState = newState;

            // Turn to next begin state
            m_currentState.Begin();
        }

        /************************************************/

        public bool IsCurrentState(FSMState state)
        {
            return state == m_currentState;
        }

        /************************************************/

        public FSMState GetCurrentState()
        {
            return m_currentState;
        }

        /************************************************/
    }

}