﻿using System;
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

        public static string[] DOOR_NUMBER_OF_VENTS = { "3", "4" };

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
        public static string[] SUNSHADE_OPENNESS = { "3", "5", "15" };
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

        #region Integrated Railing
        public static string[] RAILING_HEIGHTS = { "Height1", "Height2" };
        #endregion

        #region Pricing based on 2014 MSRP

        #region MODEL 100 - SCREEN ROOM WALLS

        /************MODEL 100 - SCREEN ROOM WALLS************/
        //Screen Openings - Include 1 Screen Door
        public static float MODEL_100_SCREEN_OPENING_1_SCREEN_DOOR = 114.20f; //Lin. Ft.
        //Screen Openings - Include 2 Screen Doors
        public static float MODEL_100_SCREEN_OPENING_2_SCREEN_DOORS = 132.30f; //Lin. Ft.
        //Screen Openings - Include 3 Screen Doors
        public static float MODEL_100_SCREEN_OPENING_3_SCREEN_DOORS = 142.50f; //Lin. Ft.
        //Solid Wall Panel
        public static float MODEL_100_SOLID_WALL_PANEL = 130.50f; //Lin. Ft.
        //Non standard panel heights - Including gable walls (Up to 120" wall ht.)
        public static float MODEL_100_NON_STANDARD_PANEL_HEIGHTS = 21.20f; //Lin. Ft.
        //Non standard panel heights - Including gable walls (Up to 120" to 144" wall ht.)
        public static float MODEL_100_NON_STANDARD_PANEL_HEIGHTS_HIGHER = 42.40f; //Lin. Ft.

        //Foam Protection (FP)
        //FP - Screen Openings - Includes 1 Screen Door
        public static float MODEL_100_FP_SCREEN_OPENINGS_INCLUDES_1_SCREEN_DOOR = 10.80f; //Lin. Ft.
        //FP - Solid Wall Panel
        public static float MODEL_100_FP_SOLID_WALL_PANEL = 32.70f; //Lin. Ft.

        //Options:
        //Custom Height Kneewall (over 20" high)
        public static float MODEL_100_CUSTOM_HEIGHT_KNEEWALL = 9.80f; //Lin. Ft.
        //Screen Transom Panels
        public static float MODEL_100_SCREEN_TRANSOM_PANELS = 0.0f; //N/C
        //Full Screen (no solid kick panels)
        public static float MODEL_100_FULL_SCREEN = 0.0f; //N/C

        //Screen Options
        //BV - Better Vue Insect Screen
        public static float MODEL_100_BETTER_VUE_INSECT_SCREEN = 0.0f; //N/C
        //TT - No-See-Ums Fiberglass 20 x 20 Mesh
        public static float MODEL_100_NO_SEE_UMS_FIBERGLASS_20_X_20_MESH = 5.50f; // Add Lin. Ft.
        //SS - Solar-Insect Screening
        public static float MODEL_100_SOLAR_INSECT_SCREENING = 8.30f; // Add Lin. Ft.
        //TS - Tuff Screen
        public static float MODEL_100_TUFF_SCREEN = 8.30f; // Add Lin. Ft.

        //Integrated Railing for Screen Mods
        //36" High Railing w/ 3/4" x 3/4" Picket
        public static float MODEL_100_HIGH_RAILING_36 = 36.40f; // Lin. Ft.
        //42" High Railing w/ 3/4" x 3/4" Picket
        public static float MODEL_100_HIGH_RAILING_42 = 38.40f; // Lin. Ft.

        /*NOTE: Specify at Time of Ordering if Side Wall Pitch is to be Left At Full Height (Over 12' to Peak - Call for Quotation)
        Gable Room Dimensions Will Be Calculated to Allow For a Triple 2" X 4" Post in the Center of the Front
        Wall to Support Ridge Beam. Unless Otherwise Specified (2" X 4" Not Included)*/

        #endregion

        #region MODEL 200 - VINYL GLAZED ROOM WALLS

        //Manufactured open walls ( No windows or doors)
        public static float MODEL_200_MANUFACTURED_OPEN_WALLS = 102.80f; //Lin. Ft.
        //Solid Wall Panel
        public static float MODEL_200_SOLID_WALL_PANEL = 130.50f; //Lin. Ft.
        //Fixed Vinyl Wall
        public static float MODEL_200_FIXED_VINYL_WALL = 142.60f; //Lin. Ft.
        //Vinyl Horizontal Roller or Vertical 4-track window
        public static float MODEL_200_VINYL_HORIZONTAL_ROLLER = 212.00f; //Lin. Ft.
        //Upgrade Wall Panels to Rigiwall - Both sides or one side...White, Driftwood. Available in Pebble or Stucco Texture (Specify at time of ordering)
        public static float MODEL_200_UPGRADE_WALL_PANELS_TO_RIGIWALL = 8.90f; //Lin. Ft.
        //Non standard panel heights - Including gable walls (96" to 120" wall ht.)
        public static float MODEL_200_NON_STANDARD_PANEL_HEIGHTS = 21.20f; //Lin. Ft.
        //Non standard panel heights - Including gable walls (From 120" to 144" wall ht.)
        public static float MODEL_200_NON_STANDARD_PANEL_HEIGHTS_HIGHER = 42.40f; //Lin. Ft.

        #region Foam Protection (FP)

        //FP - Manufactured open walls ( No windows or doors)
        public static float MODEL_200_FP_MANUFACTURED_OPEN_WALLS = 10.80f; //Lin. Ft.
        //FP - Solid Wall Panel
        public static float MODEL_200_FP_SOLID_WALL_PANEL = 32.70f; //Lin. Ft.
        //FP - Fixed Vinyl Wall
        public static float MODEL_200_FP_FIXED_VINYL_WALL = 10.80f; //Lin Ft.
        //FP - Vinyl Horizontal Roller or Vertical 4-track window
        public static float MODEL_200_FP_HORIZONTAL_ROLLER = 10.80f; //Lin. Ft.

        #endregion

        #region Options

        //Upgrade Designer colors (for colors selection see page 2-1)
        public static float MODEL_200_UPGRADE_DESIGNER_COLORS = 11.10f; //Lin. Ft.
        //Addtional Patio Door
        public static float MODEL_200_ADDITIONAL_PATIO_DOOR = 0.0f; //N/C
        //Tinted glass in Patio Door(Grey or Bronze)
        public static float MODEL_200_TINTED_GLASS_IN_PATIO_DOOR = 22.00f; //Lin. Ft.
        //Vinyl Transom/Rectangular
        public static float MODEL_200_VINYL_TRANSOM_RECTANGULAR = 20.30f; //Lin. Ft.
        //Vinyl Transom/Gable
        public static float MODEL_200_VINYL_TRANSOM_GABLE = 29.40f; //Lin. Ft.

        //"MAXIMUM WIDTH 48" /IF OVER 48" GLASS IS RECOMMENDED/ MINIMUM HEIGHT DLO 5-1/8"
        //Bronze or Grey Tinted Glass
        public static float MODEL_200_BRONZE_GREY_TINTED_GLASS = 22.00f; //Lin. Ft.
        //Tempered Glass
        public static float MODEL_200_TEMPERED_GLASS = 22.00f; //Lin. Ft.
        //Tempered Glass - Bronze or Grey Tinted Glass
        public static float MODEL_200_TEMPERED_GLASS_BRONZE_GREY_TINT = 33.00f; //Lin. Ft.

        /*NOTE: Glass Transoms must be a minimum of 5 1/8" high. Therefore when a patio door or entry door is used the
        minimum wall height must be 90".*/

        //Transom/Rectangular Glass
        public static float MODEL_200_TRANSOM_RECTANGULAR_GLASS = 31.70f; //Lin. Ft.
        //Transom/Rectangular Glass - Bronze or Grey Tinted Glass
        public static float MODEL_200_TRANSOM_RECTANGULAR_GLASS_TINTED = 35.10f; //Lin. Ft.
        //Transom/Gable Glass - Clear
        public static float MODEL_200_TRANSOM_GABLE = 46.20f; //Lin. Ft.
        //Transom/Gable Glass - Bronze or Grey Tinted Glass
        public static float MODEL_200_TRANSOM_GABLE_TINTED = 49.70f; //Lin. Ft.
        //Tempered Glass Kick Panels
        public static float MODEL_200_TEMPERED_GLASS_KICK_PANELS = 37.20f; //Lin. Ft.
        //Tempered Glass Kick Panels - Bronze or Grey Tinted Glass
        public static float MODEL_200_TEMPERED_GLASS_KICK_PANELS_TINTED = 40.70f; //Lin. Ft.
        //Vertical Electrical Chase (White, Bronze, Driftwood)
        public static float MODEL_200_VERTICAL_ELECTRICAL_CHASE = 71.60f; //Each
        //Full Vinyl (no solid kick panels)
        public static float MODEL_200_FULL_VINYL = 0.0f; //N/C
        //45 Degree Walls
        public static float MODEL_200_45_DEGREE_WALLS = 178.60f; //Each

        /*NOTE: Specify at Time of Ordering if Side Wall Pitch is to be Left At Full Height (Over 12' to Peak - Call for Quotation)
        Gable Room Dimensions Will Be Calculated to Allow For a Triple 2" X 4" Post in the Center of the Front Wall
        to Support Ridge Beam. Unless Otherwise Specified (2" X 4" Not Included)*/

        #endregion

        #region Screen Options

        //BV - Better Vue Insect Screen
        public static float MODEL_200_BETTER_VUE_INSECT_SCREEN = 0.0f; //N/C
        //TT - No-See-Ums Fiberglass 20 x 20 Mesh
        public static float MODEL_200_NO_SEE_UMS = 5.50f; //Lin. Ft.
        //SS - Solar-Insect Screening
        public static float MODEL_200_SOLAR_INSECT_SCREENING = 8.30f; //Lin. Ft.
        //TS - Tuff Screen
        public static float MODEL_200_TUFF_SCREEN = 8.30f; //Lin. Ft.

        #endregion

        #region Miscellaneous

        //Vinyl (25lb. Roll)...27" wide X approx. 100' long...Clear, Smoke Grey, Bronze, Dk Grey
        public static float MODEL_200_VINYL_25_LB = 177.70f; //Each
        //Vinyl (50lb. Roll)...60" wide X approx. 140' long...Clear, Smoke Grey, Bronze, Dk Grey
        public static float MODEL_200_VINYL_50_LB = 366.60f; //Each
        //Vinyl (100lb. Roll)...54" wide X approx. 300' long...Clear, Smoke Grey, Bronze, Dk Grey
        public static float MODEL_200_VINYL_100_LB = 733.10f; //Each
        //V-Spline (12' Length)
        public static float MODEL_200_V_SPLINE = 5.50f; //Each
        //Vinyl Roller
        public static float MODEL_200_VINYL_ROLLER = 46.00f; //Each
        //Screen Roller
        public static float MODEL_200_SCREEN_ROLLER = 34.20f; //Each
        //Spreader Bar (Vertical 4 Track) 16'...White, Bronze, Driftwood
        public static float MODEL_200_SPREADER_BAR_WBD = 46.00f; //Each
        //Spreader Bar (Vertical 4 Track) 16'...Ivory, Cranberry, Green, Black, Grey
        public static float MODEL_200_SPREADER_BAR_ICGBG = 51.60f; //Each
        //Spreader Bar Clips (Vertical 4 Track)
        public static float MODEL_200_SPREADER_BAR_CLIPS = 46.00f; //Each
        //Fixed Lite Extrusion ( 16' Length )...White, Bronze, Driftwood
        public static float MODEL_200_FIXED_LITE_EXTRUSION_WBD = 46.00f; //Each
        //Fixed Lite Extrusion ( 16' Length )...Ivory, Cranberry, Green, Black, Grey
        public static float MODEL_200_FIXED_LITE_EXTRUSION_ICGBG = 51.60f; //Each
        //Adjustable Corner Keys
        public static float MODEL_200_ADJUSTABLE_CORNER_KEYS = 1.50f; //Each
        //Fixed 90 Degree Corner Keys
        public static float MODEL_200_FIXED_90_DEGREE_CORNER_KEYS = 1.40f; //Each
        //Vinyl Cleaner Can
        public static float MODEL_200_VINYL_CLEANER_CAN = 12.10f; //Each
        //Vinyl Cleaner Case (12 cans per case)
        public static float MODEL_200_VINYL_CLEANER_CASE = 121.50f; //Each

        #endregion

        #region ENTRY DOOR PRICING

        #region Single Entry Door

        //4-Track Vertical Vinyl Door ( c/w hardware, threshold & sweep ) 
        //Upgrade from patio door
        public static float MODEL_200_4_TRACK_VERTICAL_VINYL_DOOR_UPGRADE = 334.40f; //Each
        //Additional entry door
        public static float MODEL_200_4_TRACK_VERTICAL_VINYL_DOOR_ADDITIONAL = 619.78f; //Each
        
        //Full View Glass ( c/w hardware, threshold & sweep )
        //Upgrade from patio door
        public static float MODEL_200_FULL_VIEW_GLASS_UPGRADE = 334.40f; //Each
        //Additional entry door
        public static float MODEL_200_FULL_VIEW_GLASS_ADDITIONAL = 619.78f; //Each

        //Full View Colonial Glass (15 Lite)( c/w hardware, threshold & sweep )
        //Upgrade from patio door
        public static float MODEL_200_FULL_VIEW_COLONIAL_GLASS_UPGRADE = 758.29f; //Each
        //Additional entry door
        public static float MODEL_200_FULL_VIEW_COLONIAL_GLASS_ADDITIONAL = 1019.20f; //Each

        #endregion

        #region French Door System

        //4-Track Vertical Vinyl Door ( c/w hardware, threshold & sweep ) 
        //Upgrade from patio door
        public static float MODEL_200_F_4_TRACK_VERTICAL_VINYL_DOOR_UPGRADE = 809.01f; //Each
        //Additional entry door
        public static float MODEL_200_F_4_TRACK_VERTICAL_VINYL_DOOR_ADDITIONAL = 1379.78f; //Each
        
        //Full View Glass ( c/w hardware, threshold & sweep )
        //Upgrade from patio door
        public static float MODEL_200_F_FULL_VIEW_GLASS_UPGRADE = 758.29f; //Each
        //Additional entry door
        public static float MODEL_200_F_FULL_VIEW_GLASS_ADDITIONAL = 1019.20f; //Each

        //Full View Colonial Glass (15 Lite)( c/w hardware, threshold & sweep )
        //Upgrade from patio door
        public static float MODEL_200_F_FULL_VIEW_COLONIAL_GLASS_UPGRADE = 1656.80f; //Each
        //Additional entry door
        public static float MODEL_200_F_FULL_VIEW_COLONIAL_GLASS_ADDITIONAL = 2212.83f; //Each
        
        #endregion

        //Door Hardware / Passage Set - knob/leaver (no dead bolt)
        public static float MODEL_200_DOOR_HARDWARE_BRASS_SILVER = 55.20f; //Each
        //Check Chain...Black/White
        public static float MODEL_200_CHECK_CHAIN = 8.90f; //Each

        #endregion

        #endregion

        #region MODEL 300 - 3-SEASON ROOM WALLS

        //Manufactured open walls ( No windows or doors )
        public static float MODEL_300_MANUFACTURED_OPEN_WALLS = 102.80f; //Lin. Ft.
        //Solid Wall Panel
        public static float MODEL_300_SOLID_WALL_PANEL = 130.50f; //Lin. Ft.
        //Fixed Windows - White, Bronze, Driftwood
        public static float MODEL_300_FIXED_WINDOWS = 188.60f; //Lin. Ft.
        //Horizontal Roller Window - Double Slider...White, Bronze, Driftwood
        public static float MODEL_300_VINYL_HORIZONTAL_ROLLER_WINDOW = 212.00f; //Lin. Ft.
        //Upgrade Wall Panels to Rigiwall - Both sides or one side...White, Driftwood. Available in Pebble or Stucco Texture (Specify at time of ordering)
        public static float MODEL_300_UPGRADE_WALL_PANELS_TO_RIGIWALL = 8.90f; //Add Lin. Ft.
        //Non standard panel heights - Including gable walls (96" to 120" wall ht.)
        public static float MODEL_300_NON_STANDARD_PANEL_HEIGHTS = 21.20f; //Add Lin. Ft.
        //Non standard panel heights - Including gable walls (From 120" to 144" wall ht.)
        public static float MODEL_300_NON_STANDARD_PANEL_HEIGHTS_HIGHER = 42.40f; //Add Lin. Ft.

        #region Foam Protection (FP)

        //FP - Manufactured open walls ( No windows or doors)
        public static float MODEL_300_FP_MANUFACTURED_OPEN_WALLS = 10.80f; //Lin. Ft.
        //FP - Solid Wall Panel
        public static float MODEL_300_FP_SOLID_WALL_PANEL = 32.70f; //Lin. Ft.
        //FP - Fixed Windows - White, Bronze, Driftwood
        public static float MODEL_300_FP_FIXED_WINDOWS = 10.80f; //Lin Ft.
        //FP - Horizontal Roller Window - Double Slider...White, Bronze, Driftwood
        public static float MODEL_300_FP_HORIZONTAL_ROLLER = 10.80f; //Lin. Ft.

        /*NOTE: Specify at Time of Ordering if Side Wall Pitch is to be cut. (Over 12' to Peak - Call for Quotation)
        Gable Room Dimensions Will Be Calculated to Allow For a Triple 2" X 4" Post in the Center of the Front Wall
        to Support Ridge Beam. Unless Otherwise Specified (Lumber Not Included)*/

        #endregion

        #region Options

        //Bronze or Grey Tinted Glass
        public static float MODEL_300_TINTED_GLASS = 22.00f; //Lin. Ft.
        //Tempered Glass
        public static float MODEL_300_TEMPERED_GLASS = 22.00f; //Lin. Ft.
        //Tempered Glass - Bronze or Grey Tinted Glass
        public static float MODEL_300_TEMPERED_GLASS_TINTED = 33.00f; //Lin. Ft.

        /*NOTE: Glass Transoms must be a minimum of 5 1/8" high. Therefore when a patio door or entry door is used the
        minimum wall height must be 90".*/

        //Transom/Rectangular Glass
        public static float MODEL_300_TRANSOM_GLASS = 31.70f; //Lin. Ft.
        //Transom/Rectangular Glass - Bronze or Grey Tinted Glass
        public static float MODEL_300_TRANSOM_GLASS_TINTED = 35.10f; //Lin. Ft.
        //Transom/Rectangular Glass - Tempered
        public static float MODEL_300_TRANSOM_GLASS_TEMPERED = 35.10f; //Lin. Ft.
        //Transom/Rectangular Glass - Tempered Bronze or Grey Tinted Glass
        public static float MODEL_300_TRANSOM_GLASS_TEMPERED_TINTED = 38.50f; //Lin. Ft.
        //Minimum DLO 5 1/8"

        //Transom/Gable Glass
        public static float MODEL_300_TRANSOM_GABLE = 46.20f; //Lin. Ft.
        //Transom/Gable Glass - Bronze or Grey Tinted Glass
        public static float MODEL_300_TRANSOM_GABLE_TINTED = 49.70f; //Lin. Ft.
        //Transom/Gable Glass - Tempered
        public static float MODEL_300_TRANSOM_GABLE_TEMPERED = 49.70f; //Lin. Ft.
        //Transom/Gable Glass - Tempered Bronze or Grey Tinted Glass
        public static float MODEL_300_TRANSOM_GABLE_TEMPERED_TINTED = 49.70f; //Lin. Ft.
        //Minimum DLO 5 1/8"

        //Tempered Glass Kick Panels
        public static float MODEL_300_TEMPERED_GLASS_KICK_PANELS = 37.20f; //Lin. Ft.
        //Tempered Glass Kick Panels - Bronze or Grey Tinted Glass
        public static float MODEL_300_TEMPERED_GLASS_KICK_PANELS_TINTED = 40.70f; //Lin. Ft.
        //Minimum DLO 5 1/8"

        //Vertical Electrical Chase ( White, Bronze, Driftwood )
        public static float MODEL_300_VERTICAL_ELECTRICAL_CHASE = 71.60f; //Each
        //Additional Patio Door
        public static float MODEL_300_ADDITIONAL_PATIO_DOOR = 0.0f; //N/C
        //Custom Width Patio Door
        public static float MODEL_300_CUSTOM_WIDTH_PATIO_DOOR = 407.70f; //Each
        //Custom Height Patio Door
        public static float MODEL_300_CUSTOM_HEIGHT_PATIO_DOOR = 407.70f; //Each
        //45 Degree Walls (use outside dimensions of room shape to calculate LF)
        public static float MODEL_300_45_DEGREE_WALLS = 178.60f; //Each

        #endregion

        #endregion

        #endregion
    }
}