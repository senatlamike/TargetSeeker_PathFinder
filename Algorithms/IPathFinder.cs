using System;
using System.Collections.Generic;
using System.Text;
using Algorithms;
using System.Drawing;

namespace Algorithms
{
    
    interface IPathFinder
    {
        // Events
        event PathFinderDebugHandler PathFinderDebug;
        

        // Properties added here
        bool Stopped
        {
            get;
        }

        HeuristicFormula Formula
        {
            get;
            set;
        }

        bool Diagonals
        {
            get;
            set;
        }

        bool HeavyDiagonals
        {
            get;
            set;
        }

        int HeuristicEstimate
        {
            get;
            set;
        }

        bool PunishChangeDirection
        {
            get;
            set;
        }

        bool ReopenCloseNodes
        {
            get;
            set;
        }

        bool TieBreaker
        {
            get;
            set;
        }

        int SearchLimit
        {
            get;
            set;
        }

        double CompletedTime
        {
            get;
            set;
        }

        bool DebugProgress
        {
            get;
            set;
        }

        bool DebugFoundPath
        {
            get;
            set;
        }
        

        // The FindPathStop method
        void FindPathStop();
        List<PathFinderNode> FindPath(Point start, Point end);
        

    }
}
