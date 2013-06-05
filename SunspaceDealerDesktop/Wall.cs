using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Wall
    {
        float length; //Total Width Of Wall (in inches)
        int firstItemIndex; //Index of First Item in Wall
        int lastItemIndex; //Index of Last Item in Wall
        String orientation; //N, NE, E, S, SE, NW, SW, W
        String name; //Name of the wall – For user few
        bool isExisting; //True if Wall exists
        float secondSide; //???????????????
        float startHeight; //Start height of the wall
        float endHeight; //End height of the wall
        bool isGableWall; //????????????????
        bool customHeight; //???????????????
        float soffit; //Soffit length (only for fascia install)

        /*
         * ??NOT SURE IF THESE ARE REQUIRED
            ExistingKneewall As Single
            ExistingWidth As Single
            ExistingRight As Boolean
            ExistingDrawBrick As Boolean
 
         */
    }
}