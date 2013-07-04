using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public static class Constants
    {
        #region Default Preferences
        public const float DEFAULT_FILLER = 2.0F; //the default amount of filler to be placed on each side of a wall after a starter or post
        public const float MODEL_100_KNEEWALL_HEIGHT = 20;
        public const float MODEL_200_KNEEWALL_HEIGHT = 7;
        public const float MODEL_300_KNEEWALL_HEIGHT = 20;
        public const float MODEL_400_KNEEWALL_HEIGHT = 20;
        #endregion

        #region Colours, Types and Tints
        public static string[] MODEL_100_FRAMING_COLOURS = { "White", "Driftwood", "Bronze" };
        //public const static string[] MODEL_100_WINDOW_COLOURS = { "White", "Driftwood", "Bronze" };//CURRENTLY NO COLOURS, ONLY VINYL

        public static string[] MODEL_200_FRAMING_COLOURS = { "White", "Driftwood", "Bronze" };
        public static string[] MODEL_200_WINDOW_COLOURS = { "White", "Driftwood", "Bronze", "Green", "Black", "Ivory", "Cherrywood", "Grey" };

        public static string[] MODEL_300_FRAMING_COLOURS = { "White", "Driftwood", "Bronze" };
        public static string[] MODEL_300_WINDOW_COLOURS = { "White", "Driftwood", "Bronze" };

        public static string[] MODEL_400_FRAMING_COLOURS = { "White", "Driftwood" };
        public static string[] MODEL_400_WINDOW_COLOURS = { "White", "Driftwood" };

        public static string[] INTERIOR_WALL_COLOURS = { "White", "Driftwood", "Bronze" };
        public static string[] EXTERIOR_WALL_COLOURS = { "White", "Driftwood", "Bronze" };

        public static string[] EXTERIOR_WALL_SKIN_TYPES = { "White Aluminum Stucco", "Driftwood Aluminum Stucco", "Bronze Aluminum Stucco",
                                               "White Cedar Aluminum Woodgrain", "White Cedar Forestex", "White Rigiwall Pebble",
                                               "Driftwood Rigiwall Pebble", "White Rigiwall Stucco", "Driftwood Rigiwall Stucco"};

        public static string[] INTERIOR_WALL_SKIN_TYPES = { "White Aluminum Stucco", "Driftwood Aluminum Stucco", "Bronze Aluminum Stucco",
                                               "White Cedar Aluminum Woodgrain", "White Cedar Forestex", "White Rigiwall Pebble",
                                               "Driftwood Rigiwall Pebble", "White Rigiwall Stucco", "Driftwood Rigiwall Stucco",
                                               "White FRP (Interior Only)", "Driftwood FRP (Interior Only)", "Bronze FRP (Interior Only)"};

        public static string[] GLASS_WINDOW_TINTS = { "Grey", "Bronze", "Clear" };
        public static string[] GLASS_KNEEWALL_TINTS = { "Grey", "Bronze" };
        public static string[] GLASS_TRANSOM_TINTS = { "Grey", "Bronze" };

        public static string[] VINYL_TINTS = { "Clear", "Smoke Grey", "Dark Grey", "Bronze" };

        public static string[] SUNSHADE_COLOURS = { "Chalk", "Alabaster", "Pebblestone", "Tobacco", "Ebony", "Greystone" };
        public static string[] SUNSHADE_VALANCE_COLOURS = { "White", "Driftwood", "Bronze" };

        //Glass, Vinyl, Screen, Panel, Open?
        public static string[] KNEEWALL_TYPES = { "Solid Wall", "Tempered Glass" };
        public static string[] MODEL_100_TRANSOM_TYPES = { "Vinyl", "Screen", "Solid Wall" };
        public static string[] MODEL_200_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        public static string[] MODEL_300_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        public static string[] MODEL_400_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        #endregion

        #region Size Limits
        public const float CUSTOM_DOOR_MIN_WIDTH = 25f;
        public const float CUSTOM_DOOR_MAX_WIDTH = 42f;

        public const float CUSTOM_FRENCH_DOOR_MIN_WIDTH = 48.75f;
        public const float CUSTOM_FRENCH_DOOR_MAX_WIDTH = 82.75f;

        public const float SOFT_MIN_WINDOW_SIZE = 30.0F; //Minimum size of a window (soft)
        public const float SOFT_MAX_WINDOW_SIZE = 58.0F; //Maximum size of a window (soft)

        public const float SOFT_MIN_MOD_SIZE = 12.0F; //Minimum size of a mod (soft)
        public const float SOFT_MAX_MOD_SIZE = 84.0f; //Maximum size of a mod (soft)

        public const float SPREADER_BAR_SIZE = 1.0f; //width of a spreader bar (does not vary)
        #endregion
    }
}