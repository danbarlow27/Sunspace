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
        public static string[] MODEL_NUMBERS = { "M100", "M200", "M300", "M400" };

        #region Database Restricted Constants
        //Patterns:
        //MAX_LENGTH_
        
        //Generic to many tables first:
        public const int MAX_LENGTH_FIRST_NAME = 35;
        public const int MAX_LENGTH_LAST_NAME = 50;
        public const int MAX_LENGTH_EMAIL = 50;
        //By table:
        #region dealers
        public const int MAX_LENGTH_DEALERSHIP_NAME = 35;
        public const int MAX_LENGTH_DEALER_MULTIPLIER = 5;
        #endregion

        #region sunspace
        public const int MAX_LENGTH_SUNSPACE_POSITION = 35;
        #endregion

        #region users
        public const int MAX_LENGTH_USER_LOGIN = 15;
        public const int MAX_LENGTH_USER_PASSWORD = 15;
        public const float MINIMUM_MULTIPLIER = 0;
        public const float MAXIMUM_MULTIPLIER = 2;
        #endregion
        #endregion

        #region Default Preferences
        public const float DEFAULT_FILLER = 2.0F; //the default amount of filler to be placed on each side of a wall after a starter or post
        public const float MODEL_100_KNEEWALL_HEIGHT = 20;
        public const float MODEL_200_KNEEWALL_HEIGHT = 7;
        public const float MODEL_300_KNEEWALL_HEIGHT = 20;
        public const float MODEL_400_KNEEWALL_HEIGHT = 20;
        #endregion

        #region Colours, Types and Tints
        public static string[] MODEL_100_FRAMING_COLOURS = { "White", "Driftwood", "Bronze" };

        public static string[] MODEL_200_FRAMING_COLOURS = { "White", "Driftwood", "Bronze" };

        public static string[] MODEL_300_FRAMING_COLOURS = { "White", "Driftwood", "Bronze" };

        public static string[] MODEL_400_FRAMING_COLOURS = { "White", "Driftwood" };

        public static string[] INTERIOR_WALL_COLOURS = { "White", "Driftwood", "Bronze" };
        public static string[] EXTERIOR_WALL_COLOURS = { "White", "Driftwood", "Bronze" };

        public static string[] EXTERIOR_WALL_SKIN_TYPES = { "White Aluminum Stucco", "Driftwood Aluminum Stucco", "Bronze Aluminum Stucco",
                                               "White Cedar Aluminum Woodgrain", "White Cedar Forestex", "White Rigiwall Pebble",
                                               "Driftwood Rigiwall Pebble", "White Rigiwall Stucco", "Driftwood Rigiwall Stucco"};

        public static string[] INTERIOR_WALL_SKIN_TYPES = { "White Aluminum Stucco", "Driftwood Aluminum Stucco", "Bronze Aluminum Stucco",
                                               "White Cedar Aluminum Woodgrain", "White Cedar Forestex", "White Rigiwall Pebble",
                                               "Driftwood Rigiwall Pebble", "White Rigiwall Stucco", "Driftwood Rigiwall Stucco",
                                               "White FRP (Interior Only)", "Driftwood FRP (Interior Only)", "Bronze FRP (Interior Only)"};


        public static string[] VINYL_TINTS = { "Clear", "Smoke Grey", "Dark Grey", "Bronze" };

        public static string[] INSTALLATION_TYPES = { "House", "Trailer", "Standalone" };
        //Glass, Vinyl, Screen, Panel, Open?
        public static string[] MODEL_100_TRANSOM_TYPES = { "Vinyl", "Screen", "Solid Wall" };
        public static string[] MODEL_200_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        public static string[] MODEL_300_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        public static string[] MODEL_400_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };

        public static string[] SCREEN_TYPES = { "No Screen", "Better Vue Insect Screen (Default)", "No See Ums 20 x 20 Mesh", "Solar Insect Screening", "Tuff Screen" };

        public static string[] ACRYLIC_COLOUR = { "Clear", "Bronze", "Solar Cool White", "Heat Stop Cool Blue" };

        public static string[] GUTTER_COLOUR = { "White", "Driftwood", "Bronze"};
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

        #region sunspace
        public static string[] SUNSPACE_POSITIONS = { "Owner", "IT Specialist", "CSR" };
        #endregion

        #region Walls
        //public enum WALL_TYPE
        //{
        //    EXISTING = "E",
        //    PROPOSED = "P",
        //    //others...
        //};

        //public enum WALL_FACING
        //{
        //    SOUTH = "S",
        //    NORTH = "N",
        //    SOUTH_WEST = "SW",
        //    SOUTH_EAST = "SE",
        //    NORTH_WEST = "NW",
        //    NORTH_EAST = "NE",
        //    WEST = "W",
        //    EAST = "E"
        //};

        public const float MINIMUM_WALL_HEIGHT = 0F;
        public const float MINIMUM_WALL_LENGTH = 0F;
        //more constants

        #endregion

        #region Doors
        public static string[] DOOR_TYPES = { "Cabana", "French", "Patio", "No Door" };
        public static string[] DOOR_STYLES = { "Full Screen", "Vertical Four Track", "Full View", "Full View Colonial", "Half Lite", "Half Lite Venting", "Half Lite with Mini Blinds", "Full View with Mini Blinds" };
        public static string[] DOOR_HARDWARE = { "Satin Silver", "Bright Brass", "Antique Brass" };
        public static string[] DOOR_COLOURS = { "White", "Driftwood", "Bronze", "Green", "Black", "Ivory", "Cherrywood", "Grey" };
        public static string[] GLASS_DOOR_TINTS = { "Grey", "Bronze", "Clear" };
        #endregion Doors

        #region Windows
        //public const static string[] MODEL_100_WINDOW_COLOURS = { "White", "Driftwood", "Bronze" };//CURRENTLY NO COLOURS, ONLY VINYL
        public static string[] MODEL_200_WINDOW_COLOURS = { "White", "Driftwood", "Bronze", "Green", "Black", "Ivory", "Cherrywood", "Grey" };
        public static string[] MODEL_300_WINDOW_COLOURS = { "White", "Driftwood", "Bronze" };
        public static string[] MODEL_400_WINDOW_COLOURS = { "White", "Driftwood" };

        public static string[] GLASS_WINDOW_TINTS = { "Grey", "Bronze", "Clear" };

        public static string[] MODEL_100_WINDOW_TYPES = { "Fixed Vinyl" };
        public static string[] MODEL_200_WINDOW_TYPES = { "Vertical 4 Track (ISM)", "Vertical 4 Track (OSM)", "Horizontal 4 Track" };
        public static string[] MODEL_300_WINDOW_TYPES = { "Horizontal Roller", "Single Slider", "Fixed Vinyl", "Fixed Glass" };
        public static string[] MODEL_400_WINDOW_TYPES = { "Horizontal Roller", "Single Slider", "Fixed Vinyl", "Fixed Glass" };
        #endregion

        #region Sunshades
        public static string[] SUNSHADE_VALANCE_COLOURS = { "White", "Driftwood", "Bronze" };
        public static string[] SUNSHADE_FABRIC_COLOURS = { "Chalk", "Alabaster", "Pebblestone", "Tobacco", "Ebony", "Greystone" };
        public static string[] SUNSHADE_OPENNESS = { "3%", "5%", "15%" };
        #endregion

        #region Roofs
        public static string[] ROOF_TYPES = { "Studio", "Gable" };
        public static string[] ROOF_EXTERIOR_SKIN_TYPES = { "White Aluminum Stucco", "Driftwood Aluminum Stucco", "Bronze Aluminum Stucco",
                                               "White Cedar Aluminum Woodgrain", "White Cedar Forestex", "White Rigiwall Pebble",
                                               "Driftwood Rigiwall Pebble", "White Rigiwall Stucco", "Driftwood Rigiwall Stucco", "OSB"};

        public static string[] ROOF_INTERIOR_SKIN_TYPES = { "White Aluminum Stucco", "Driftwood Aluminum Stucco", "Bronze Aluminum Stucco",
                                               "White Cedar Aluminum Woodgrain", "White Cedar Forestex", "White Rigiwall Pebble",
                                               "Driftwood Rigiwall Pebble", "White Rigiwall Stucco", "Driftwood Rigiwall Stucco", "OSB",
                                               "White FRP (Interior Only)", "Driftwood FRP (Interior Only)", "Bronze FRP (Interior Only)"};
        public static string[] ROOF_THICKNESSES = { "3", "4", "6" };
        public static string[] ROOF_EXTRUSION_TYPE = { "I-Beam", "I-Beam FP", "I-Beam OSB", "I-Beam OSB/OSB", "Pressure Cap", "Pressure Cap FP", "Pressure Cap OSB", "Pressure Cap OSB/OSB" };
        #endregion

        #region Floors
        public static string[] FLOOR_THICKNESSES = { "4.5", "6.5", "8.25" };            
        #endregion

        #region Kneewalls
        public static string[] KNEEWALL_TYPES = { "Panel", "Glass" };
        public static string[] KNEEWALL_GLASS_TINTS = { "Grey", "Bronze" };
        #endregion

        #region Transom
        public static string[] TRANSOM_TYPES = { "Panel", "Glass", "Vinyl" };
        public static string[] TRANSOM_GLASS_TINTS = { "Grey", "Bronze" };
            //Transom glass tints by model
            //transom vinyl tints by model
            //frame colours by model, is it the same as above?
        #endregion
    }
}