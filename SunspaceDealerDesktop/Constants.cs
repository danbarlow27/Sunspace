using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        #region Countries, States, Provinces
        public static List<ListItem> COUNTRY_LIST = new List<ListItem>()
            {
                new ListItem("Canada", "CAN"), 
                new ListItem("United States", "USA")
            };

        public static List<ListItem> PROVINCE_LIST = new List<ListItem>()
            {
                new ListItem("Ontario", "ON"), 
                new ListItem("British Columbia", "BC"),
                new ListItem("Québec", "QC"), 
                new ListItem("Alberta", "AB"), 
                new ListItem("Nova Scotia", "NS"),
                new ListItem("Manitoba", "MB"), 
                new ListItem("Saskatchewan States", "SK"),
                new ListItem("New Brunswick", "NB"), 
                new ListItem("Prince Edward Island", "PEI"),
                new ListItem("Newfoundland and Labrador", "NFL")
            };
        public static List<ListItem> STATE_LIST = new List<ListItem>()
            {
                new ListItem("Alabama", "AL"),
                new ListItem("Alaska", "AK"),
                new ListItem("Arizona", "AZ"),
                new ListItem("Arkansas", "AR"),
                new ListItem("California", "CA"),
                new ListItem("Colorado", "CO"),
                new ListItem("Connecticut", "CT"),
                new ListItem("Delaware", "DE"),
                new ListItem("Florida", "FL"),
                new ListItem("Georgia", "GA"),
                new ListItem("Hawaii", "HI"),
                new ListItem("Idaho", "ID"),
                new ListItem("Illinois", "IL"),
                new ListItem("Indiana", "IN"),
                new ListItem("Iowa", "IA"),
                new ListItem("Kansas", "KS"),
                new ListItem("Kentucky", "KY"),
                new ListItem("Louisiana", "LA"),
                new ListItem("Maine", "ME"),
                new ListItem("Maryland", "MD"),
                new ListItem("Massachusetts", "MA"),
                new ListItem("Michigan", "MI"),
                new ListItem("Minnesota", "MN"),
                new ListItem("Mississippi", "MS"),
                new ListItem("Missouri", "MO"),
                new ListItem("Montana", "MT"),
                new ListItem("Nebraska", "NE"),
                new ListItem("Nevada", "NV"),
                new ListItem("New Hampshire", "NH"),
                new ListItem("New Jersey", "NJ"),
                new ListItem("New Mexico", "NM"),
                new ListItem("New York", "NY"),
                new ListItem("North Carolina", "NC"),
                new ListItem("North Dakota", "ND"),
                new ListItem("Ohio", "OH"),
                new ListItem("Oklahoma", "OK"),
                new ListItem("Oregon", "OR"),
                new ListItem("Pennsylvania", "PA"),
                new ListItem("Rhode Island", "RI"),
                new ListItem("South Carolina", "SC"),
                new ListItem("South Dakota", "SD"),
                new ListItem("Tennessee", "TN"),
                new ListItem("Texas", "TX"),
                new ListItem("Utah", "UT"),
                new ListItem("Vermont", "VT"),
                new ListItem("Virginia", "VA"),
                new ListItem("Washington", "WA"),
                new ListItem("West Virginia", "WV"),
                new ListItem("Wisconsin", "WI"),
                new ListItem("Wyoming", "WY")
            };
        #endregion

        #region Walls
        public enum WALL_TYPE
        {
            EXISTING = "E",
            PROPOSED = "P",
            //others...
        };

        public enum WALL_FACING
        {
            SOUTH = "S",
            NORTH = "N",
            SOUTH_WEST = "SW",
            SOUTH_EAST = "SE",
            NORTH_WEST = "NW",
            NORTH_EAST = "NE",
            WEST = "W",
            EAST = "E"
        };

        public const float MINIMUM_WALL_HEIGHT = 0F;
        public const float MINIMUM_WALL_LENGTH = 0F;

        #endregion

        #region Doors
        //Door types by model
            //Door styles by model
            //Door hardware by model
            //Door colour by model
            //Door glass tint by model
            //Door vinyl tint by model
            //Door screen tint by model
        #endregion Doors

        #region Windows
            //Window types by model
            //Window colours by model
            //Window glass tint by model
            //Window vinyl tint by model
            //Window screen type by model
        #endregion

        #region Sunshades
            //Sunshade valance colour by model
            //Sunshade fabrics by model
            //Sunshade openness by model
        #endregion

        #region Roofs
            //Roof Types by model (All studio gable, NYI)
            //Roof interior skins by model
            //roof exterior skins by model
            //roof thickness by model
        #endregion

        #region Floors
            //Floor interior skins by model
            //floor exterior skins by model
            //floor thickness by model            
        #endregion

        #region Kneewalls
            //Kneewall Types by model
            //Kneewall glass tints by model
        #endregion

        #region Transom
            //Transoms tyles by model
            //Transom glass tints by model
            //transom vinyl tints by model
            //frame colours by model, is it the same as above?
        #endregion
    }
}