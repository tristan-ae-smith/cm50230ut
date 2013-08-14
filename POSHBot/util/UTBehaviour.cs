﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSH_sharp.sys;

namespace Posh_sharp.POSHBot.util
{
    public class UTBehaviour : Behaviour
    {
        public UTBehaviour(AgentBase agent, string[] actions, string[] senses) :
            base(agent, actions, senses)
        {

        }

        protected POSHBot GetBot()
        {
			return ((POSHBot)agent.getBehaviour("POSHBot"));
        }

        protected Movement GetMovement()
        {
			return ((Movement)agent.getBehaviour("Movement"));
        }

        protected Combat GetCombat()
        {
			return ((Combat)agent.getBehaviour("Combat"));
        } 

		protected Navigator GetNavigator()
		{
			return ((Navigator)agent.getBehaviour("Navigator"));
		}

        internal virtual void ReceiveFlagDetails(Dictionary<string,string> values)
        {
            Console.Out.WriteLine("in receiveFlagDetails");
        }         

        internal virtual void ReceivePathDetails(Dictionary<string,string> valuesDict){} 

        internal virtual void ReceiveCheckReachDetails(Dictionary<string,string> valuesDict){} 

        internal virtual void ReceiveProjectileDetails(Dictionary<string,string> values){} 

        internal virtual void ReceiveDamageDetails(Dictionary<string,string> values){} 

        internal virtual void ReceiveKillDetails(Dictionary<string,string> values){} 

        internal virtual void ReceiveDeathDetails(Dictionary<string,string> value){}

    }
}