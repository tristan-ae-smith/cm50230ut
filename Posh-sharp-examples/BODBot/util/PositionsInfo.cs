﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSH_sharp.sys;
using POSH_sharp.sys.strict;

namespace Posh_sharp_examples.BODBot.util
{
    /// <summary>
    /// stores details about where things are
    /// </summary>
    public class PositionsInfo
    {
        protected internal NavPoint ownBasePos { private set; protected internal get; }
        protected internal NavPoint enemyBasePos { private set; protected internal get; }

        /// <summary>
        /// contains an ordered list of all visited NavPoint Ids
        /// </summary>
        protected internal  List<string> visitedNavPoints;
        protected internal NavPoint chosenNavPoint;
        protected internal Dictionary<string, string> ourFlagInfo;
        protected internal Dictionary<string,string> enemyFlagInfo;

        List<NavPoint> pathHome;
        List<NavPoint> pathToEnemyBase;

        /// <summary>
        /// set to current time if we're sent a blank path
        /// Blank paths indicate that we're right next to something but can't actually see it
        /// </summary>
        long tooCloseForPath;

        public PositionsInfo()
        {
            ownBasePos = null;
            enemyBasePos = null;
            visitedNavPoints = new List<string>();
            chosenNavPoint = null;
            ourFlagInfo = new Dictionary<string,string>();
            enemyFlagInfo = new Dictionary<string,string>();

            pathHome = new List<NavPoint>();
            pathToEnemyBase = new List<NavPoint>();

            tooCloseForPath = 0L;
        }

        public bool hasEnemyFlagInfoExpired(int lsecs = 10)
        {
            if (enemyFlagInfo.Count > 0 && enemyFlagInfo.ContainsKey("Reachable"))
                if (long.Parse(enemyFlagInfo["timestamp"]) < ( TimerBase.TimeStamp() - lsecs) )
                    return true;
            
            return false;
        }

        /// <summary>
        /// Have to call check_enemy_flag_info_expired before calling this FA 
        /// </summary>
        public void expireEnemyFlagInfo()
        {
            enemyFlagInfo["Reachable"] = false.ToString();
        }

        public bool hasOurFlagInfoExpired(int lsecs = 10)
        {
            if ( ourFlagInfo.Count > 0 && ourFlagInfo.ContainsKey("Reachable") )
                if (long.Parse(ourFlagInfo["timestamp"]) < ( TimerBase.TimeStamp() - lsecs) )
                    return true;
            
            return false;
        }

        /// <summary>
        /// Have to call check_our_flag_info_expired before calling this FA 
        /// </summary>
        public void expireOurFlagInfo()
        {
            ourFlagInfo["Reachable"] = false.ToString();
        }

        public bool hasTooCloseForPathExpired(int lsecs)
        {
            if ( tooCloseForPath < TimerBase.TimeStamp() - lsecs )
                return true;

            return false;
        }

        public void expireTooCloseForPath()
        {
            tooCloseForPath = 0L;
        }
    }
}
