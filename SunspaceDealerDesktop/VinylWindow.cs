
/// dummy class, will add proper attributes and methods during the back-end phase

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class VinylWindow : Window
    {
        #region Attributes
        //private string windowType;
        //private string screenType;
        //private float startHeight;
        //private float endHeight;
        //private float length;
        //private string frameColour;
        private string vinylTint;
        //private float spreaderBar;
        //private int numVents;
        #endregion

        #region Constructors

        public VinylWindow()
        {
            //WindowType = "";
            //ScreenType = "";
            //StartHeight = 0.0f;
            //EndHeight = 0.0f;
            //Length = 0.0f;
            VinylTint = "";
            //SpreaderBar = -1f;
            //NumVents = 0;
        }

        #endregion

        #region Accessors
        //public string WindowType
        //{
        //    get
        //    {
        //        return windowType;
        //    }
        //    set
        //    {
        //        windowType = value;
        //    }
        //}

        //public string ScreenType
        //{
        //    get
        //    {
        //        return screenType;
        //    }
        //    set
        //    {
        //        screenType = value;
        //    }
        //}

        //public float StartHeight
        //{
        //    get
        //    {
        //        return startHeight;
        //    }
        //    set
        //    {
        //        startHeight = value;
        //    }
        //}

        //public float EndHeight
        //{
        //    get
        //    {
        //        return endHeight;
        //    }
        //    set
        //    {
        //        endHeight = value;
        //    }
        //}

        //public float Length
        //{
        //    get
        //    {
        //        return length;
        //    }
        //    set
        //    {
        //        length = value;
        //    }
        //}

        public string VinylTint
        {
            get
            {
                return vinylTint;
            }
            set
            {
                vinylTint = value;
            }
        }

        //public float SpreaderBar
        //{
        //    get
        //    {
        //        return spreaderBar;
        //    }
        //    set
        //    {
        //        spreaderBar = value;
        //    }
        //}

        //public int NumVents
        //{
        //    get
        //    {
        //        return numVents;
        //    }
        //    set
        //    {
        //        numVents = value;
        //    }
        //}

        #endregion
    }
}