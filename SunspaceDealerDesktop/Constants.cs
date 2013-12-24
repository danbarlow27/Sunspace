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

        #region Punches
        public const float DOOR_PUNCH = 0.25F;
        public const float KNEEWALL_PUNCH = 0.25F;
        #endregion

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

        public static string[] MODEL_100_GLASS_TINTS = { };
        public static string[] MODEL_200_GLASS_TINTS = { };
        public static string[] MODEL_300_GLASS_TINTS = { };
        public static string[] MODEL_400_GLASS_TINTS = { };

        public static string[] VINYL_TINTS = { "Clear", "Smoke Grey", "Dark Grey", "Bronze"};

        public static string[] GLASS_TINTS = { "Clear", "Bronze", "Grey" };

        public static string[] INSTALLATION_TYPES = { "House", "Trailer", "Standalone" };

        public static string[] FASCIA_STRIPE_COLOUR = { "No Stripe", "Test1", "Test2"};

        public static string[] SCREEN_TYPES = { "No Screen", "Better Vue Insect Screen (Default)", "No See Ums 20 x 20 Mesh", "Solar Insect Screening", "Tuff Screen" };

        public static string[] ACRYLIC_COLOUR = { "Clear", "Bronze", "Solar Cool White", "Heat Stop Cool Blue" };

        public static string[] GUTTER_COLOUR = { "White", "Driftwood", "Bronze"};
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

        public const float MODEL_100_200_300_TRANSOM_MINIMUM_SIZE = 4.125f;
        public const float MODEL_400_TRANSOM_MINIMUM_SIZE = 5.125f;

        public const float SOFT_MIN_WINDOW_SIZE = 30.0F; //Minimum size of a window (soft)
        public const float SOFT_MAX_WINDOW_SIZE = 58.0F; //Maximum size of a window (soft)

        public const float SOFT_MIN_MOD_SIZE = 12.0F; //Minimum size of a mod (soft)
        public const float SOFT_MAX_MOD_SIZE = 84.0f; //Maximum size of a mod (soft)

        public const float SPREADER_BAR_SIZE = 1.0f; //width of a spreader bar (does not vary)

        public const float ACRYLIC_PANEL_PROJECTION = 276f;
        public const float ACRYLIC_PANEL_WIDTH = 24f;

        public const float FOAM_PANEL_PROJECTION = 264f;
        public const float FOAM_PANEL_WIDTH = 48f;

        public const float THERMADECK_PANEL_PROJECTION = 288f;
        public const float THERMADECK_PANEL_WIDTH = 48f;

        public const float SKYLIGHT_PROJECTION = 12f;
        public const float SKYLIGHT_WIDTH = 12f;
        #endregion

        #region Countries, States, Provinces
        public static List<ListItem> COUNTRY_LIST = new List<ListItem>()
            {
                new ListItem("Canada", "CAN"), 
                new ListItem("United States", "USA")
            };

        public static string[] PROVINCE_LIST = { "Alberta", 
                                                   "British Columbia", 
                                                   "Manitoba", 
                                                   "New Brunswick", 
                                                   "Newfoundland and Labrador", 
                                                   "Northwest Territories", 
                                                   "Nova Scotia", 
                                                   "Nunavut", 
                                                   "Ontario", 
                                                   "Prince Edward Island", 
                                                   "Quebec", 
                                                   "Saskatchewan", 
                                                   "Yukon" };

        public static string[] PROVINCE_CODES = { "AB",
                                                    "BC",
                                                    "MB",
                                                    "NB",
                                                    "NFL",
                                                    "NWT",
                                                    "NS",
                                                    "NU",
                                                    "ON",
                                                    "PEI",
                                                    "QC",
                                                    "SK",
                                                    "YT" };

        public static string[] STATE_LIST = { "Alabama",
                                                "Alaska", 
                                                "Arizona", 
                                                "Arkansas", 
                                                "California", 
                                                "Colorado", 
                                                "Connecticut", 
                                                "Delaware", 
                                                "Florida", 
                                                "Georgia", 
                                                "Hawaii", 
                                                "Idaho", 
                                                "Illinois", 
                                                "Indiana", 
                                                "Iowa", 
                                                "Kansas", 
                                                "Kentucky", 
                                                "Louisiana", 
                                                "Maine", 
                                                "Maryland", 
                                                "Massachusetts", 
                                                "Michigan", 
                                                "Minnesota",
                                                "Mississippi", 
                                                "Missouri", 
                                                "Montana", 
                                                "Nebraska", 
                                                "Nevada", 
                                                "New Hampshire", 
                                                "New Jersey",
                                                "New Mexico",
                                                "New York", 
                                                "North Carolina",
                                                "North Dakota",
                                                "Ohio",
                                                "Oklahoma",
                                                "Oregon",
                                                "Pennsylvania",
                                                "Rhode Island",
                                                "South Carolina",
                                                "South Dakota",
                                                "Tennessee",
                                                "Texas",
                                                "Utah",
                                                "Vermont",
                                                "Virginia",
                                                "Washington", 
                                                "West Virginia",
                                                "Wisconsin",
                                                "Wyoming" };

        public static string[] STATE_CODES = { "AL",
                                                "AK",
                                                "AZ",
                                                "AR",
                                                "CA",
                                                "CO",
                                                "CT",
                                                "DE",
                                                "FL",
                                                "GA",
                                                "HI",
                                                "ID",
                                                "IL",
                                                "IN",
                                                "IA",
                                                "KS",
                                                "KY",
                                                "LA",
                                                "ME",
                                                "MD",
                                                "MA",
                                                "MI",
                                                "MN",
                                                "MS",
                                                "MO",
                                                "MT",
                                                "NE",
                                                "NV",
                                                "NH",
                                                "NJ",
                                                "NM",
                                                "NY",
                                                "NC",
                                                "ND",
                                                "OH",
                                                "OK",
                                                "OR",
                                                "PA",
                                                "RI",
                                                "SC",
                                                "SD",
                                                "TN",
                                                "TX",
                                                "UT",
                                                "VT",
                                                "VA",
                                                "WA",
                                                "WV",
                                                "WI",
                                                "WY" };

        #endregion

        #region sunspace
        public static string[] SUNSPACE_POSITIONS = { "Owner", "IT Specialist", "CSR" };
        #endregion

        #region Boxheaders
        public const float BOXHEADER_LENGTH = 3.25f;
        public const float BOXHEADER_RECEIVER_LENGTH = 4.25f;
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
        public static string[] DOOR_MODEL_100_PATIO_STYLES = { "Aluminum Storm Screen", "Aluminum Storm Glass" };
        public static string[] DOOR_MODEL_200_300_PATIO_STYLES = { "Aluminum Storm Glass" };
        public static string[] DOOR_MODEL_400_PATIO_STYLES = { "Vinyl Guard" };
        public static string[] DOOR_ORDER_ENTRY = { "Full Screen", "Vertical 4 Track", "Full View", "Full View Colonial" };
        public static string[] DOOR_ORDER_PATIO = { "Vinyl Guard", "Aluminum Storm" };

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

        public const float MIN_SLAB_SIZE = 25f;
        public const float MAX_SLAB_SIZE = 42f;

        public const float PATIO_FRAMING = 2F;

        public const float DOOR_PADDING = 11.5f;
        public const float KICKPLATE_PADDING = 4f;
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

        public static string[] VINYL_WINDOW_TYPES_FOR_WINDOWS_ONLY_ORDER = { "Vertical 4 Track", "Horizontal 2 Track", "Horizontal 4 Track", "Vinyl Fixed Lite", "Vinyl Trapezoid" };
        public static string[] GLASS_WINDOW_TYPES_FOR_WINDOWS_ONLY_ORDER = { "Aluminum XX Horizontal Roller", "Alumimum Framed Picture", "Aluminum Framed Trapezoid", "PVC XO Single Glazed Horizontal Roller", "PVC Framed Single Glazed Picture", "PVC Framed Single Glazed Trapezoid" };


        #region MIN_WIDTH_BUILDABLE
        public static float V4T_2V_MIN_WIDTH_BUILDABLE = 12.0F;
        public static float V4T_3V_MIN_WIDTH_BUILDABLE = 12.0F;
        public static float V4T_4V_MIN_WIDTH_BUILDABLE = 12.0F;
        public static float V4T_6V_MIN_WIDTH_BUILDABLE = 26.5F;
        public static float V4T_8V_MIN_WIDTH_BUILDABLE = 26.5F;
        public static float V4T_9V_MIN_WIDTH_BUILDABLE = 41.0F;
        public static float V4T_12V_MIN_WIDTH_BUILDABLE = 41.0F;
        public static float HORIZONTAL_ROLLER_MIN_WIDTH_BUILDABLE = 18.0F;
        public static float VINYL_LITE_MIN_WIDTH_BUILDABLE = 4.125F;
        public static float VINYL_TRAP_MIN_WIDTH_BUILDABLE = 4.125F;

        public static float DOUBLE_SLIDER_MIN_WIDTH_BUILDABLE = 24.0F;
        public static float DOUBLE_SLIDER_LITE_MIN_WIDTH_BUILDABLE = 5.125F;
        public static float DOUBLE_SLIDER_TRAP_MIN_WIDTH_BUILDABLE = 5.125F;

        public static float SINGLE_SLIDER_MIN_WIDTH_BUILDABLE = 24.0F;
        public static float SINGLE_SLIDER_LITE_MIN_WIDTH_BUILDABLE = 8.0F;
        public static float SINGLE_SLIDER_TRAP_MIN_WIDTH_BUILDABLE = 8.0F;

        public static float SCREEN_MIN_WIDTH_BUILDABLE = 4.125F;
        #endregion
        #region MIN_WIDTH_WARRANTY
        public static float V4T_2V_MIN_WIDTH_WARRANTY = 24.0F;
        public static float V4T_3V_MIN_WIDTH_WARRANTY = 24.0F;
        public static float V4T_4V_MIN_WIDTH_WARRANTY = 24.0F;
        public static float V4T_6V_MIN_WIDTH_WARRANTY = 54.0F;
        public static float V4T_8V_MIN_WIDTH_WARRANTY = 54.0F;
        public static float V4T_9V_MIN_WIDTH_WARRANTY = 78.0F;
        public static float V4T_12V_MIN_WIDTH_WARRANTY = 78.0F;
        public static float HORIZONTAL_ROLLER_MIN_WIDTH_WARRANTY = 24.0F;
        public static float VINYL_LITE_MIN_WIDTH_WARRANTY = 4.125F;
        public static float VINYL_TRAP_MIN_WIDTH_WARRANTY = 4.125F;

        public static float DOUBLE_SLIDER_MIN_WIDTH_WARRANTY = 24.0F;
        public static float DOUBLE_SLIDER_LITE_MIN_WIDTH_WARRANTY = 5.125F;
        public static float DOUBLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY = 5.125F;

        public static float SINGLE_SLIDER_MIN_WIDTH_WARRANTY = 24.0F;
        public static float SINGLE_SLIDER_LITE_MIN_WIDTH_WARRANTY = 8.0F;
        public static float SINGLE_SLIDER_TRAP_MIN_WIDTH_WARRANTY = 8.0F;

        public static float SCREEN_MIN_WIDTH_WARRANTY = 4.125F;
        #endregion
        #region MAX_WIDTH_BUILDABLE
        public static float V4T_2V_MAX_WIDTH_BUILDABLE = 66.0F;
        public static float V4T_3V_MAX_WIDTH_BUILDABLE = 66.0F;
        public static float V4T_4V_MAX_WIDTH_BUILDABLE = 66.0F;
        public static float V4T_6V_MAX_WIDTH_BUILDABLE = 120.0F;
        public static float V4T_8V_MAX_WIDTH_BUILDABLE = 120.0F;
        public static float V4T_9V_MAX_WIDTH_BUILDABLE = 180.0F;
        public static float V4T_12V_MAX_WIDTH_BUILDABLE = 180.0F;
        public static float HORIZONTAL_ROLLER_MAX_WIDTH_BUILDABLE = 192.0F;
        public static float VINYL_LITE_MAX_WIDTH_BUILDABLE = 192.0F;
        public static float VINYL_TRAP_MAX_WIDTH_BUILDABLE = 192.0F;

        public static float DOUBLE_SLIDER_MAX_WIDTH_BUILDABLE = 72.0F;
        public static float DOUBLE_SLIDER_LITE_MAX_WIDTH_BUILDABLE = 96.0F;
        public static float DOUBLE_SLIDER_TRAP_MAX_WIDTH_BUILDABLE = 96.0F;

        public static float SINGLE_SLIDER_MAX_WIDTH_BUILDABLE = 66.0F;
        public static float SINGLE_SLIDER_LITE_MAX_WIDTH_BUILDABLE = 96.0F;
        public static float SINGLE_SLIDER_TRAP_MAX_WIDTH_BUILDABLE = 96.0F;

        public static float SCREEN_MAX_WIDTH_BUILDABLE = 96.0F;
        #endregion
        #region MAX_WIDTH_WARRANTY
        public static float V4T_2V_MAX_WIDTH_WARRANTY = 54.0F;
        public static float V4T_3V_MAX_WIDTH_WARRANTY = 54.0F;
        public static float V4T_4V_MAX_WIDTH_WARRANTY = 54.0F;
        public static float V4T_6V_MAX_WIDTH_WARRANTY = 108.0F;
        public static float V4T_8V_MAX_WIDTH_WARRANTY = 108.0F;
        public static float V4T_9V_MAX_WIDTH_WARRANTY = 144.0F;
        public static float V4T_12V_MAX_WIDTH_WARRANTY = 144.0F;
        public static float HORIZONTAL_ROLLER_MAX_WIDTH_WARRANTY = 114.0F;
        public static float VINYL_LITE_MAX_WIDTH_WARRANTY = 114.0F;
        public static float VINYL_TRAP_MAX_WIDTH_WARRANTY = 102.0F;

        public static float DOUBLE_SLIDER_MAX_WIDTH_WARRANTY = 78.0F;
        public static float DOUBLE_SLIDER_LITE_MAX_WIDTH_WARRANTY = 96.0F;
        public static float DOUBLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY = 96.0F;

        public static float SINGLE_SLIDER_MAX_WIDTH_WARRANTY = 66.0F;
        public static float SINGLE_SLIDER_LITE_MAX_WIDTH_WARRANTY = 96.0F;
        public static float SINGLE_SLIDER_TRAP_MAX_WIDTH_WARRANTY = 96.0F;

        public static float SCREEN_MAX_WIDTH_WARRANTY = 84.0F;
        #endregion

        #region MIN_HEIGHT_BUILDABLE
        public static float V4T_2V_MIN_HEIGHT_BUILDABLE = 18.0F;
        public static float V4T_3V_MIN_HEIGHT_BUILDABLE = 18.0F;
        public static float V4T_4V_MIN_HEIGHT_BUILDABLE = 44.0F;
        public static float V4T_6V_MIN_HEIGHT_BUILDABLE = 44.0F;
        public static float V4T_8V_MIN_HEIGHT_BUILDABLE = 44.0F;
        public static float V4T_9V_MIN_HEIGHT_BUILDABLE = 44.0F;
        public static float V4T_12V_MIN_HEIGHT_BUILDABLE = 44.0F;
        public static float HORIZONTAL_ROLLER_MIN_HEIGHT_BUILDABLE = 18.0F;
        public static float VINYL_LITE_MIN_HEIGHT_BUILDABLE = 4.125F;
        public static float VINYL_TRAP_MIN_HEIGHT_BUILDABLE = 4.125F;

        public static float DOUBLE_SLIDER_MIN_HEIGHT_BUILDABLE = 18.0F;
        public static float DOUBLE_SLIDER_LITE_MIN_HEIGHT_BUILDABLE = 6.5F;
        public static float DOUBLE_SLIDER_TRAP_MIN_HEIGHT_BUILDABLE = 4.125F;

        public static float SINGLE_SLIDER_MIN_HEIGHT_BUILDABLE = 12.0F;
        public static float SINGLE_SLIDER_LITE_MIN_HEIGHT_BUILDABLE = 8.0F;
        public static float SINGLE_SLIDER_TRAP_MIN_HEIGHT_BUILDABLE = 8.0F;

        public static float SCREEN_MIN_HEIGHT_BUILDABLE = 4.125F;
        #endregion
        #region MIN_HEIGHT_WARRANTY
        public static float V4T_2V_MIN_HEIGHT_WARRANTY = 36.0F;
        public static float V4T_3V_MIN_HEIGHT_WARRANTY = 44.0F;
        public static float V4T_4V_MIN_HEIGHT_WARRANTY = 56.0F;
        public static float V4T_6V_MIN_HEIGHT_WARRANTY = 44.0F;
        public static float V4T_8V_MIN_HEIGHT_WARRANTY = 56.0F;
        public static float V4T_9V_MIN_HEIGHT_WARRANTY = 44.0F;
        public static float V4T_12V_MIN_HEIGHT_WARRANTY = 56.0F;
        public static float HORIZONTAL_ROLLER_MIN_HEIGHT_WARRANTY = 24.0F; 
        public static float VINYL_LITE_MIN_HEIGHT_WARRANTY = 4.125F;
        public static float VINYL_TRAP_MIN_HEIGHT_WARRANTY = 4.125F;

        public static float DOUBLE_SLIDER_MIN_HEIGHT_WARRANTY = 24.0F;
        public static float DOUBLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY = 6.5F;
        public static float DOUBLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY = 4.125F;

        public static float SINGLE_SLIDER_MIN_HEIGHT_WARRANTY = 30.0F;
        public static float SINGLE_SLIDER_LITE_MIN_HEIGHT_WARRANTY = 8.0F;
        public static float SINGLE_SLIDER_TRAP_MIN_HEIGHT_WARRANTY = 8.0F;

        public static float SCREEN_MIN_HEIGHT_WARRANTY = 4.125F;
        #endregion
        #region MAX_HEIGHT_BUILDABLE
        public static float V4T_2V_MAX_HEIGHT_BUILDABLE = 114.0F;
        public static float V4T_3V_MAX_HEIGHT_BUILDABLE = 114.0F;
        public static float V4T_4V_MAX_HEIGHT_BUILDABLE = 114.0F;
        public static float V4T_6V_MAX_HEIGHT_BUILDABLE = 114.0F;
        public static float V4T_8V_MAX_HEIGHT_BUILDABLE = 114.0F;
        public static float V4T_9V_MAX_HEIGHT_BUILDABLE = 114.0F;
        public static float V4T_12V_MAX_HEIGHT_BUILDABLE = 114.0F;
        public static float HORIZONTAL_ROLLER_MAX_HEIGHT_BUILDABLE = 108.0F; 
        public static float VINYL_LITE_MAX_HEIGHT_BUILDABLE = 114.0F;
        public static float VINYL_TRAP_MAX_HEIGHT_BUILDABLE = 78.0F; 

        public static float DOUBLE_SLIDER_MAX_HEIGHT_BUILDABLE = 78.0F;
        public static float DOUBLE_SLIDER_LITE_MAX_HEIGHT_BUILDABLE = 84.0F;
        public static float DOUBLE_SLIDER_TRAP_MAX_HEIGHT_BUILDABLE = 72.0F; 

        public static float SINGLE_SLIDER_MAX_HEIGHT_BUILDABLE = 72.0F; 
        public static float SINGLE_SLIDER_LITE_MAX_HEIGHT_BUILDABLE = 72.0F; 
        public static float SINGLE_SLIDER_TRAP_MAX_HEIGHT_BUILDABLE = 72.0F; 

        public static float SCREEN_MAX_HEIGHT_BUILDABLE = 96.0F;
        #endregion
        #region MAX_HEIGHT_WARRANTY
        public static float V4T_2V_MAX_HEIGHT_WARRANTY = 102.0F;
        public static float V4T_3V_MAX_HEIGHT_WARRANTY = 102.0F;
        public static float V4T_4V_MAX_HEIGHT_WARRANTY = 102.0F;
        public static float V4T_6V_MAX_HEIGHT_WARRANTY = 102.0F;
        public static float V4T_8V_MAX_HEIGHT_WARRANTY = 102.0F;
        public static float V4T_9V_MAX_HEIGHT_WARRANTY = 102.0F;
        public static float V4T_12V_MAX_HEIGHT_WARRANTY = 102.0F;
        public static float HORIZONTAL_ROLLER_MAX_HEIGHT_WARRANTY = 114.0F;
        public static float VINYL_LITE_MAX_HEIGHT_WARRANTY = 114.0F;
        public static float VINYL_TRAP_MAX_HEIGHT_WARRANTY = 78.0F;

        public static float DOUBLE_SLIDER_MAX_HEIGHT_WARRANTY = 78.0F;
        public static float DOUBLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY = 72.0F;
        public static float DOUBLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY = 72.0F;

        public static float SINGLE_SLIDER_MAX_HEIGHT_WARRANTY = 66.0F;
        public static float SINGLE_SLIDER_LITE_MAX_HEIGHT_WARRANTY = 60.0F;
        public static float SINGLE_SLIDER_TRAP_MAX_HEIGHT_WARRANTY = 72.0F;

        public static float SCREEN_MAX_HEIGHT_WARRANTY = 84.0F;
        #endregion

        #region SPREADER_BAR_NEEDED
        public static float V4T_SPREADER_BAR_NEEDED = 36.0F;
        public static float HORIZONTAL_ROLLER_SPREADER_BAR_NEEDED = 54.0F;
        
        #endregion

        #endregion

        #region Sunshades
        public static string[] SUNSHADE_VALANCE_COLOURS = { "White", "Driftwood", "Bronze" };
        public static string[] SUNSHADE_FABRIC_COLOURS = { "Chalk", "Alabaster", "Pebblestone", "Tobacco", "Ebony", "Greystone" };
        public static string[] SUNSHADE_OPENNESS = { "3%", "5%", "15%" };
        #endregion

        #region Roofs
        public static string[] ROOF_TYPES = { "Studio", "Gable" };
        public static string[] ROOF_STYLE = { "Alum. Skin or O.S.B.", "Acrylic T-Bar System", "Thermadeck System" };
        public static string[] ROOF_EXTERIOR_SKIN_TYPES = { "White Aluminum Stucco", "Driftwood Aluminum Stucco", "Bronze Aluminum Stucco",
                                               "White Cedar Aluminum Woodgrain", "White Cedar Forestex", "White Rigiwall Pebble",
                                               "Driftwood Rigiwall Pebble", "White Rigiwall Stucco", "Driftwood Rigiwall Stucco", "OSB"};

        public static string[] ROOF_INTERIOR_SKIN_TYPES = { "White Aluminum Stucco", "Driftwood Aluminum Stucco", "Bronze Aluminum Stucco",
                                               "White Cedar Aluminum Woodgrain", "White Cedar Forestex", "White Rigiwall Pebble",
                                               "Driftwood Rigiwall Pebble", "White Rigiwall Stucco", "Driftwood Rigiwall Stucco", "OSB",
                                               "White FRP (Interior Only)", "Driftwood FRP (Interior Only)", "Bronze FRP (Interior Only)"};

        public static string[] ROOF_TRADITIONAL_THICKNESSES = { "3", "4", "6" };
        public static string[] ROOF_THERMADECK_THICKNESSES = { "4.5", "6.5", "8.25" };
        public static string[] ROOF_ACRYLIC_THICKNESSES = { "1.5" };

        public static string[] ROOF_STRIPE_COLOURS = { "No Stripe", "Country Blue", "Black", "Burgundy", "Hunter Green", "Purple", "Turquoise", "Slate Grey", "Beige", "Brown" };
        public static string[] ROOF_ACRYLIC_COLOURS = { "Clear", "Bronze", "Solar Cool White", "Heat Stop Cool Blue" };

        public static string[] ROOF_EXTRUSION_TYPE = { "I-Beam", "I-Beam FP", "I-Beam OSB", "I-Beam OSB/OSB", "Pressure Cap", "Pressure Cap FP", "Pressure Cap OSB", "Pressure Cap OSB/OSB" };        
        public const float ROOF_IBEAM_WIDTH = 0.5f;
        public const float ROOF_PRESSURECAP_WIDTH = 0.625f;

        public static string[] ROOF_SUPPORT_TYPES = { "Fluted", "Railing" };
        public static int ROOF_SUPPORT_FLUTED_SIZE = 3;
        public static int ROOF_SUPPORT_RAILING_SIZE = 5;
        public static string[] ROOF_SUPPORT_HEIGHTS = { "7", "8", "9", "10" };
        #endregion

        #region Floors
        public static string[] FLOOR_TYPES = { "Thermadeck"/*, "Alumadeck" */};

        public static string[] FLOOR_THICKNESSES = { "4.5", "6.5", "8.25" };            
        #endregion

        #region Kneewalls
        public static string[] KNEEWALL_TYPES = { "Solid Wall", "Glass" };
        public static string[] KNEEWALL_GLASS_TINTS = { "Grey", "Bronze" };
        #endregion

        #region Kickplate

        public static string[] KICKPLATE_SIZE_OPTIONS = { "4", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "Custom" };

        #endregion

        #region Transom
        public static string[] MODEL_100_TRANSOM_TYPES = { "Vinyl", "Screen", "Solid Wall" };
        public static string[] MODEL_200_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        public static string[] MODEL_300_TRANSOM_TYPES = { "Vinyl", "Glass", "Solid Wall" };
        public static string[] MODEL_400_TRANSOM_TYPES = { "Glass", "Solid Wall" };
        public static string[] TRANSOM_TYPES = { "Panel", "Glass", "Vinyl" };
        public static string[] TRANSOM_GLASS_TINTS = { "Grey", "Bronze" };
        public static float TRANSOM_SPREADER_BAR_REQUIRED = 36f;
            //Transom glass tints by model
            //transom vinyl tints by model
            //frame colours by model, is it the same as above?
        #endregion

        #region Mods
        public const string MOD_TYPE_DOOR = "Door";
        public const string MOD_TYPE_WINDOW = "Window";
        #endregion
    }
}