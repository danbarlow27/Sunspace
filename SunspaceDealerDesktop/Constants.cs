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


        public static string[] VINYL_TINTS = { "Clear", "Smoke Grey", "Dark Grey", "Bronze"};

        public static string[] INSTALLATION_TYPES = { "House", "Trailer", "Standalone" };
        //Glass, Vinyl, Screen, Panel, Open?
        public static string[] MODEL_100_TRANSOM_TYPES = { "Vinyl", "Screen", "Solid Wall" };
        public static string[] MODEL_200_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        public static string[] MODEL_300_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        public static string[] MODEL_400_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };

        public static string[] SCREEN_TYPES = { "No Screen", "Better Vue Insect Screen (Default)", "No See Ums 20 x 20 Mesh", "Solar Insect Screening", "Tuff Screen" };
        #endregion

        #region Size Limits
        public const int CUSTOM_DOOR_MIN_WIDTH = 25;
        public const int CUSTOM_DOOR_MAX_WIDTH = 42;
        public const int CUSTOM_DOOR_MIN_HEIGHT = 48;
        public const int CUSTOM_DOOR_MAX_HEIGHT = 96;

        public const int PATIO_DOOR_MIN_WIDTH = 60;     //5'
        public const int PATIO_DOOR_MAX_WIDTH = 96;     //8'
        public const int PATIO_DOOR_MIN_HEIGHT = 72;    //6'
        public const int PATIO_DOOR_MAX_HEIGHT = 96;    //8'

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
        public static string[] WALL_TYPE =
        {
            "EXISTING",
            "PROPOSED"
            //others...
        };

        public static string[] WALL_FACING =
        {
            "SOUTH",
            "NORTH",
            "SOUTH_WEST",
            "SOUTH_EAST",
            "NORTH_WEST",
            "NORTH_EAST",
            "WEST",
            "EAST"
        };

        ////////NEED TO DOUBLE CHECK THESE VALUES...//////////
        public static float MIN_WALL_HEIGHT = 0F;
        public static float MAX_WALL_HEIGHT;
        public static float MIN_WALL_LENGTH = 0F;
        public static float MAX_WALL_LENGTH;
        public static float MIN_FILLER_SIZE = 0F;
        public static float MAX_FILLER_SIZE = 46.5F; 
        //////////////////////////////////////////////////////
        public static float SUGGESTED_DEFAULT_FILLER = 2.0F;
        public static float PREFERRED_DEFAULT_FILLER = 2.0F;
        //more constants

        #endregion

        #region Doors
        public static string[] DOOR_TYPES = { "Cabana", "French", "Patio", "NoDoor" };

        public static string[] DOOR_STYLES = { "Full Screen", "Vertical Four Track", "Full View", "Full View Colonial", "Half Lite", "Half Lite Venting", "Half Lite with Mini Blinds", "Full View with Mini Blinds" };
        public static string[] DOOR_MODEL_100_STYLES = { "Full Screen", "Vertical Four Track" };
        public static string[] DOOR_MODEL_200_STYLES = { "Vertical Four Track", "Full View", "Full View Colonial" };
        public static string[] DOOR_MODEL_300_STYLES = { "Full View", "Full View Colonial" };
        public static string[] DOOR_MODEL_400_STYLES = { "Half Lite", "Half Lite Venting", "Half Lite with Mini Blinds", "Full View with Mini Blinds" };
        public static string[] DOOR_MODEL_100_PATIO_STYLES = { "Screen", "Glass" };
        public static string[] DOOR_MODEL_200_300_400_PATIO_STYLES = { "Glass" };

        public static string[] DOOR_GLASS_TINTS = { "Grey", "Bronze", "Clear" };

        public static string[] DOOR_V4T_VINYL_OPTIONS = { "Clear", "Smoke Grey", "Dark Grey", "Bronze", "Mixed" };

        public static string[] DOOR_NUMBER_OF_VENTS = { "2", "3", "4" };

        public static string[] DOOR_COLOURS = { "White", "Driftwood", "Bronze", "Green", "Black", "Ivory", "Cherrywood", "Grey" };

        public static string[] DOOR_HEIGHTS = { "80", "Custom" };

        public static string[] DOOR_WIDTHS_PATIO = { "5", "6", "7", "8", "Custom" };

        public static string[] DOOR_WIDTHS_FRENCH = { "60", "72", "Custom" };

        public static string[] DOOR_WIDTHS_CABANA_NODOOR = { "30", "32", "34", "36", "Custom" };

        public static string[] DOOR_BOXHEADER_POSITION = { "Left", "Right", "Both", "None" };

        public static string[] DOOR_HARDWARE = { "Satin Silver", "Bright Brass", "Antique Brass" };

        public static string[] DOOR_POSITION = { "Left", "Center", "Right", "Custom" };
        
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


        public static float MIN_WINDOW_WIDTH = 30.0F; //NEED TO DOUBLE CHECK THIS VALUE
        public static float MAX_WINDOW_WIDTH = 58.0F; //NEED TO DOUBLE CHECK THIS VALUE
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
        #endregion

        #region Floors
        public static string[] FLOOR_THICKNESSES = { "4.5", "6.5", "8.25" };            
        #endregion

        #region Kneewalls
        public static string[] KNEEWALL_TYPES = { "Panel", "Glass" };
        public static string[] KNEEWALL_GLASS_TINTS = { "Grey", "Bronze" };
        #endregion

        #region Kickplate

        public static string[] KICKPLATE_SIZE_OPTIONS = { "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "Custom" };

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