using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaiFSM
{

    public delegate void StateEvent();
    public class FSMState
    {

        protected string m_stateName;

        StateEvent m_beginEvent;
        StateEvent m_updateEvent;
        StateEvent m_endEvent;

        /************************************************/

        public FSMState()
        {

        }

        public FSMState(string name, StateEvent beginE, StateEvent updateE, StateEvent endE)
        {
            this.m_stateName = name;
            this.m_beginEvent = beginE;
            this.m_updateEvent = updateE;
            this.m_endEvent = endE;
        }

        /************************************************/

        public void Begin()
        {
            if (m_beginEvent != null)
            {
                m_beginEvent();
            }
        }

        public void Update()
        {
            if (m_updateEvent != null)
            {
                m_updateEvent();
            }
        }

        public void End()
        {
            if (m_endEvent != null)
            {
                m_endEvent();
            }
        }

        /************************************************/

        public void UnBindEvent()
        {
            m_beginEvent = null;
            m_updateEvent = null;
            m_endEvent = null;
        }

        #region Override

        public static bool operator ==(FSMState s1, FSMState s2)
        {
            return s1.m_stateName == s2.m_stateName;
        }

        public static bool operator !=(FSMState s1, FSMState s2)
        {
            return s1.m_stateName != s2.m_stateName;
        }

        public override bool Equals(object obj)
        {
            return obj is FSMState state &&
                   m_stateName == state.m_stateName &&
                   EqualityComparer<StateEvent>.Default.Equals(m_beginEvent, state.m_beginEvent) &&
                   EqualityComparer<StateEvent>.Default.Equals(m_updateEvent, state.m_updateEvent) &&
                   EqualityComparer<StateEvent>.Default.Equals(m_endEvent, state.m_endEvent);
        }

        public override int GetHashCode()
        {
            return m_stateName.GetHashCode();
        }

        public override string ToString()
        {
            return "State name is: " + m_stateName;
        }

        #endregion

    }
}
