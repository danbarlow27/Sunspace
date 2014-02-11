/*
 * This section contains information regarding pricing and is based
 * on the January 2014 MSRP provided by Sunspace
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class PricingConstants
    {

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
        public static float MODEL_200_F_FULL_VIEW_GLASS_UPGRADE = 809.01f; //Each
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

        #region ENTRY DOOR PRICING

        #region Single Entry Door

        //4-Track Vertical Vinyl Door ( c/w hardware, threshold & sweep ) 
        //Upgrade from patio door
        public static float MODEL_300_4_TRACK_VERTICAL_VINYL_DOOR_UPGRADE = 334.40f; //Each
        //Additional entry door
        public static float MODEL_300_4_TRACK_VERTICAL_VINYL_DOOR_ADDITIONAL = 619.78f; //Each

        //Full View Glass ( c/w hardware, threshold & sweep )
        //Upgrade from patio door
        public static float MODEL_300_FULL_VIEW_GLASS_UPGRADE = 334.40f; //Each
        //Additional entry door
        public static float MODEL_300_FULL_VIEW_GLASS_ADDITIONAL = 619.78f; //Each

        //Full View Colonial Glass (15 Lite)( c/w hardware, threshold & sweep )
        //Upgrade from patio door
        public static float MODEL_300_FULL_VIEW_COLONIAL_GLASS_UPGRADE = 758.29f; //Each
        //Additional entry door
        public static float MODEL_300_FULL_VIEW_COLONIAL_GLASS_ADDITIONAL = 1019.20f; //Each

        #endregion

        #region French Door System

        //4-Track Vertical Vinyl Door ( c/w hardware, threshold & sweep ) 
        //Upgrade from patio door
        public static float MODEL_300_F_4_TRACK_VERTICAL_VINYL_DOOR_UPGRADE = 809.01f; //Each
        //Additional entry door
        public static float MODEL_300_F_4_TRACK_VERTICAL_VINYL_DOOR_ADDITIONAL = 1379.78f; //Each

        //Full View Glass ( c/w hardware, threshold & sweep )
        //Upgrade from patio door
        public static float MODEL_300_F_FULL_VIEW_GLASS_UPGRADE = 809.01f; //Each
        //Additional entry door
        public static float MODEL_300_F_FULL_VIEW_GLASS_ADDITIONAL = 1019.20f; //Each

        //Full View Colonial Glass (15 Lite)( c/w hardware, threshold & sweep )
        //Upgrade from patio door
        public static float MODEL_300_F_FULL_VIEW_COLONIAL_GLASS_UPGRADE = 1656.80f; //Each
        //Additional entry door
        public static float MODEL_300_F_FULL_VIEW_COLONIAL_GLASS_ADDITIONAL = 2212.83f; //Each

        #endregion

        //Custom Width up to 3'0"
        public static float MODEL_300_CUSTOM_WIDTH_UP_TO_3 = 0.0f; //N/C
        //Custom Width over to 3'0"
        public static float MODEL_300_CUSTOM_WIDTH_OVER_TO_3 = 0.0f; //N/C
        //Custom Height up to 6'8"
        public static float MODEL_300_CUSTOM_HEIGHT_UP_TO_6_8 = 0.0f; //N/C
        //Custom Height over to 6'8"
        public static float MODEL_300_CUSTOM_HEIGHT_OVER_TO_6_8 = 0.0f; //N/C

        //Door Hardware / Passage Set - knob/leaver (no dead bolt)
        public static float MODEL_300_DOOR_HARDWARE_BRASS_SILVER = 55.20f; //Each
        //Check Chain...Black/White
        public static float MODEL_300_CHECK_CHAIN = 8.90f; //Each

        #endregion

        //Additional Patio Door
        public static float MODEL_300_ADDITIONAL_PATIO_DOOR = 0.0f; //N/C
        //Custom Width Patio Door
        public static float MODEL_300_CUSTOM_WIDTH_PATIO_DOOR = 407.70f; //Each
        //Custom Height Patio Door
        public static float MODEL_300_CUSTOM_HEIGHT_PATIO_DOOR = 407.70f; //Each
        //45 Degree Walls (use outside dimensions of room shape to calculate LF)
        public static float MODEL_300_45_DEGREE_WALLS = 178.60f; //Each
        //5' Walk-in Bay Window (includes required additional roof)
        public static float MODEL_300_5_WALK_IN_BAY_WINDOW = 978.50f; //Each
        //6' Walk-in Bay Window (includes required additional roof)
        public static float MODEL_300_6_WALK_IN_BAY_WINDOW = 1174.20f; //Each
        //(Roof to be mitered on site)

        #region Screen Options: All Windows Default to Better Vue Screen

        //BV - Better Vue Insect Screen
        public static float MODEL_300_BETTER_VUE_INSECT_SCREEN = 0.0f; //N/C
        //TT - No-See-Ums Fiberglass 20 x 20 Mesh
        public static float MODEL_300_NO_SEE_UMS = 5.50f; //Lin. Ft.
        //SS - Solar-Insect Screening
        public static float MODEL_300_SOLAR_INSECT_SCREENING = 8.30f; //Lin. Ft.
        //TS - Tuff Screen
        public static float MODEL_300_TUFF_SCREEN = 8.30f; //Lin. Ft.

        #endregion

        /*NOTE: Some of the above options will result in longer lead times.*/

        #endregion

        #endregion

        #region MODEL 400 - THERMAL BROKEN ROOM WALLS

        //Manufactured open walls ( No windows or doors)
        public static float MODEL_400_MANUFACTURED_OPEN_WALLS = 137.80f; //Lin. Ft.
        //Solid Wall Panel
        public static float MODEL_400_SOLID_WALL_PANEL = 194.10f; //Lin. Ft.
        //Fixed Windows ( Low E- Argon )
        public static float MODEL_400_FIXED_WINDOWS = 263.60f; //Lin. Ft.
        //Single Slider Lift Out ( Low E- Argon )
        public static float MODEL_400_SINGLE_SLIDER = 283.80f; //Lin. Ft.
        //Extra Sliding Glass Patio Door ( Low E- Argon )
        public static float MODEL_400_EXTRA_SLIDING_GLASS_PATIO_DOOR = 538.20f; //Lin. Ft.
        //Patio Door Wall (Standard Sizes 5', 6' and 8')
        public static float MODEL_400_PATIO_DOOR_WALL = 337.60f; //Lin. Ft.
        //Upgrade Wall Panels to Rigiwall - Both sides or one side...White, Driftwood. Available in Pebble or Stucco Texture (Specify at time of ordering)
        public static float MODEL_400_UPGRADE_WALL_PANELS_TO_RIGIWALL = 8.90f; //Add Lin. Ft.
        //Upgrade for Driftwood and Bronze Doors
        public static float MODEL_400_UPCHARGE_DRIFTWOOD_BRONZE_DOORS = 241.00f; //Add Lin. Ft.
        //Non standard heights - Including gable walls (96" to 120" wall ht.)
        public static float MODEL_400_NON_STANDARD_HEIGHTS = 28.60f; //Add Lin. Ft.
        //Non standard heights - Including gable walls (From 120" to 144" wall ht.)
        public static float MODEL_400_NON_STANDARD_HEIGHTS_HIGHER = 57.10f; //Add Lin. Ft.

        #region Foam Protection (FP)
        
        //FP - Manufactured open walls ( No windows or doors)
        public static float MODEL_400_FP_MANUFACTURED_OPEN_WALLS = 11.00f; //Add Lin. Ft.
        //FP - Solid Wall Panel
        public static float MODEL_400_FP_SOLID_WALL_PANEL = 32.70f; //Add Lin. Ft.
        //FP - Single Slider Lift Out ( Low E- Argon )
        public static float MODEL_400_FP_SINGLE_SLIDER_LIFT_OUT = 9.60f; //Add Lin. Ft.

        /*NOTE: Specify at Time of Ordering if Side Wall Pitch is to be Left At Full Height (Over 12' to Peak - Call for Quotation)
        Gable Room Dimensions Will Be Calculated to Allow For a Triple 2" X 4" Post in the Center of the Front Wall
        to Support Ridge Beam. Unless Otherwise Specified (2" X 4" Not Included)*/

        #endregion

        #region Options

        //Tempered Glass (both sides)
        public static float MODEL_400_TEMPERED_GLASS = 44.20f; //Lin. Ft.
        //Tempered Glass Kick Panels
        public static float MODEL_400_TEMPERED_KICK_PANELS = 65.30f; //Lin. Ft.
        //Bronze or Grey Glass
        public static float MODEL_400_BRONZE_GREY_GLASS = 22.00f; //Lin. Ft.
        //Colonial Grill Units (windows)
        public static float MODEL_400_COLONIAL_GRILL_UNITS = 82.20f; //Lin. Ft.

        //Glass Transoms - rectangular (walls up to 8' high)
        public static float MODEL_400_GLASS_TRANSOM_UP_TO_8 = 47.30f; //Lin. Ft.
        //Glass Transoms - rectangular (walls up to 10' high)
        public static float MODEL_400_GLASS_TRANSOM_UP_TO_10 = 81.20f; //Lin. Ft.
        //Glass Transoms - rectangular (walls up to 12' high)
        public static float MODEL_400_GLASS_TRANSOM_UP_TO_12 = 136.60f; //Lin. Ft.
        //Single Slider Lift Out Transoms - rectangular (walls up to 8' high)
        public static float MODEL_400_SINGLE_SLIDER_UP_TO_8 = 77.30f; //Lin. Ft.
        //Single Slider Lift Out Transoms - rectangular (walls up to 10' high)
        public static float MODEL_400_SINGLE_SLIDER_UP_TO_10 = 111.20f; //Lin. Ft.
        //Single Slider Lift Out Transoms - rectangular (walls up to 12' high)
        public static float MODEL_400_SINGLE_SLIDER_UP_TO_12 = 166.60f; //Lin. Ft.
        //Glass Transoms - trapezoids (walls up to 10' high)
        public static float MODEL_400_GLASS_TRANSOM_TRAPEZOID_UP_TO_10 = 135.20f; //Lin. Ft.
        //Glass Transoms - trapezoids (walls up to 12' high)
        public static float MODEL_400_GLASS_TRANSOM_TRAPEZOID_UP_TO_12 = 175.90f; //Lin. Ft.

        /*NOTE: Fixed Glass transoms / traps must have a minimum height of 8". Therefore when a patio door is used the
        minimum wall height must be 92" and when a 400 Series Steel Entry Door is used the wall height must
        be a minimum of 95".
        Sliding Slider Lift Out Transoms must have a minimum height of 12".*/

        //45 Degree Walls (use outside dimensions of room shape to calculate LF)
        public static float MODEL_400_45_DEGREE_WALLS = 178.60f; //Each
        //Vertical Electrical Chase (White)
        public static float MODEL_400_VERTICAL_ELECTRICAL_CHASE = 107.30f; //Each
        //Custom Size Patio door...(width x height)
        public static float MODEL_400_CUSTOM_SIZE_PATIO_DOOR = 769.90f; //Each
        //Colonial Grills in Glass Patio Door
        public static float MODEL_400_COLONIAL_GRILLS_IN_GLASS_PATIO_DOOR = 53.90f; //Lin. Ft.
        
        #endregion
        
        #region Screen Options
        
        //All Windows Default to Better Vue Screen
        //BV - Better Vue Insect Screen
        public static float MODEL_400_BETTER_VUE_INSECT_SCREEN = 0.0f; //N/C
        //TT - No-See-Ums Fiberglass 20 x 20 Mesh
        public static float MODEL_400_NO_SEE_UMS_FIBERGLASS_20_X_20_MESH = 5.50f; // Add Lin. Ft.
        //SS - Solar-Insect Screening
        public static float MODEL_400_SOLAR_INSECT_SCREENING = 8.30f; // Add Lin. Ft.
        //TS - Tuff Screen
        public static float MODEL_400_TUFF_SCREEN = 8.30f; // Add Lin. Ft.

        #endregion

        #region 400 Series Steel Entry Door

        //Half Lite - Upgrade From Patio Door
        public static float MODEL_400_HALF_LITE_UPGRADE_FROM_PATIO = 714.30f; //Each
        //Half Lite - Additional Entry Door
        public static float MODEL_400_HALF_LITE_ADDITIONAL = 815.36f; //Each
        //Half Lite - Upgrade to French Door
        public static float MODEL_400_HALF_LITE_UPGRADE_TO_FRENCH = 1321.43f; //Each
        //Half Lite Venting - Upgrade From Patio Door
        public static float MODEL_400_HALF_LITE_VENTING_UPGRADE_FROM_PATIO = 799.60f; //Each
        //Half Lite Venting - Additional Entry Door
        public static float MODEL_400_HALF_LITE_VENTING_ADDITIONAL = 900.06f; //Each
        //Half Lite Venting
        public static float MODEL_400_HALF_LITE_VENTING_UPGRADE_TO_FRENCH = 1479.26f; //Each
        //Full Lite - Upgrade From Patio Door
        public static float MODEL_400_FULL_LITE_UPGRADE_FROM_PATIO = 861.12f; //Each
        //Full Lite - Additional Entry Door
        public static float MODEL_400_FULL_LITE_ADDITIONAL = 962.13f; //Each
        //Full Lite - Upgrade to French Door
        public static float MODEL_400_FULL_LITE_UPGRADE_TO_FRENCH = 1593.07f; //Each
        //Half Lite with Mini Blinds - Upgrade From Patio Door
        public static float MODEL_400_HALF_LITE_W_MINI_BLINDS_UPGRADE_FROM_PATIO = 1100.69f; //Each
        //Half Lite with Mini Blinds - Additional Entry Door
        public static float MODEL_400_HALF_LITE_W_MINI_BLINDS_ADTTIONAL = 1201.55f; //Each
        //Half Lite with Mini Blinds - Upgrade to French Door
        public static float MODEL_400_HALF_LITE_W_MINI_BLINDS_UPGRADE_TO_FRENCH = 2036.27f; //Each
        //Full View with Mini Blinds - Upgrade From Patio Door
        public static float MODEL_400_FULL_LITE_W_MINI_BLINDS_UPGRADE_FROM_PATIO = 1219.92f; //Each
        //Full View with Mini Blinds - Additional Entry Door
        public static float MODEL_400_FULL_LITE_W_MINI_BLINDS_ADTTIONAL = 1320.95f; //Each
        //Full View with Mini Blinds - Upgrade to French Door
        public static float MODEL_400_FULL_LITE_W_MINI_BLINDS_UPGRADE_TO_FRENCH = 2256.84f; //Each

        #endregion

        #endregion

        #region SUNSPACE INSULATED ROOF SYSTEMS

            #region SUNSPACE "PRESSURE CAP" INSULATED ROOF SYSTEMS

            //3" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_3_INCH = 17.60f; //Sq. Ft.
            //4" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_4_INCH = 20.10f; //Sq. Ft.
            //6" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_6_INCH = 23.20f; //Sq. Ft.

            #endregion

            #region SUNSPACE "PRESSURE CAP FOAM PROTECTED" INSULATED ROOF SYSTEMS ( PRESSURE CAP F/P )

            //3" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_FOAM_PROTECTED_3_INCH = 21.90f; //Sq. Ft.
            //4" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_FOAM_PROTECTED_4_INCH = 24.00f; //Sq. Ft.
            //6" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_FOAM_PROTECTED_6_INCH = 27.10f; //Sq. Ft.

            #endregion

            #region SUNSPACE "I-BEAM" INSULATED ROOF SYSTEMS (White Only)

            //3" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_3_INCH = 17.60f; //Sq. Ft.
            //4" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_4_INCH = 20.10f; //Sq. Ft.
            //6" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_6_INCH = 23.20f; //Sq. Ft.

            #endregion

            #region SUNSPACE "I-BEAM FOAM PROTECTED" INSULATED ROOF SYSTEMS ( I-BEAM F/P ) (White Only)

            //3" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_FOAM_PROTECTED_3_INCH = 21.90f; //Sq. Ft.
            //4" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_FOAM_PROTECTED_4_INCH = 24.00f; //Sq. Ft.
            //6" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_FOAM_PROTECTED_6_INCH = 27.10f; //Sq. Ft.

            #endregion

            #region UPGRADE TO ABOVE ROOF SYSTEMS

            //4" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_UPGRADE_TO_INSULATED_ROOF_4_INCH = 17.60f; //Sq. Ft.
            //6" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_UPGRADE_TO_INSULATED_ROOF_6_INCH = 20.10f; //Sq. Ft.

            //4" - 2lb. I-BEAM Roof @ 2' - o/c
            public static float INSULATED_ROOF_UPGRADE_TO_INSULATED_ROOF_I_BEAM_4_INCH = 20.10f; //Sq. Ft.
            //6" - 2lb. I-BEAM Roof @ 2' - o/c
            public static float INSULATED_ROOF_UPGRADE_TO_INSULATED_ROOF_I_BEAM_6_INCH = 23.20f; //Sq. Ft.

            #endregion

            #region SUNSPACE "PRESSURE CAP OSB TOP" INSULATED ROOF SYSTEMS

            //3" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_OSB_3_INCH = 18.60f; //Sq. Ft.
            //4" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_OSB_4_INCH = 21.40f; //Sq. Ft.
            //6" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_PRESSURE_CAP_OSB_6_INCH = 24.90f; //Sq. Ft.

            #endregion

            #region SUNSPACE "I-BEAM OSB TOP" INSULATED ROOF SYSTEMS

            //3" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_OSB_3_INCH = 18.60f; //Sq. Ft.
            //4" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_OSB_4_INCH = 21.40f; //Sq. Ft.
            //6" - 1 lb. Density foam with .024" aluminum skin
            public static float INSULATED_ROOF_I_BEAM_OSB_6_INCH = 24.90f; //Sq. Ft.

            #endregion

            #region SUNSPACE "T-BAR" INSULATED ROOF SYSTEMS

            /*
            Note: For invoicing purposes roof dimensions will be rounded up to the nearest foot. All T-BAR roof
            systems will be shipped with tee-bars, receiver, gutter, fascia and 5/8" thick 2lb Aluminum Foam panels
             
            The T-Bar roof system has all the flexibility of the insulated roof system but also always you to add full length
            ACRYLITE® skylight panel to the roof system where additional light is required. An upcharge will applied to
            the square footage of acrylic rood panels used if the system. Please note that the Tee-bar roof system is not
            recommended for installation over Model 400 walls.             
            */

            #region Studio Roof

            //Up to 150 Sq. Ft.
            public static float INSULATED_ROOF_STUDIO_ROOF_UP_TO_150_SQ_FT = 21.00f; //Sq. Ft.
            //150 Sq. Ft. and up
            public static float INSULATED_ROOF_STUDIO_ROOF_150_SQ_FT_AND_UP = 19.00f; //Sq. Ft.
            //Panel Option Colors: White, Drift, Bronze

            #endregion

            #region Gable Roof

            //Up to 150 Sq. Ft.
            public static float INSULATED_ROOF_GABLE_ROOF_UP_TO_150_SQ_FT = 22.00f; //Sq. Ft.
            //150 Sq. Ft. and up
            public static float INSULATED_ROOF_GABLE_ROOF_150_SQ_FT_AND_UP = 20.00f; //Sq. Ft.
            //Panel Option Colors: White, Drift, Bronze

            #endregion

            //Upgrade to ACRYLITE® Double Skin Acylic Panels
            public static float INSULATED_ROOF_UPGRADE_TO_ACRYLITE_DOUBLE_SKIN_ACYLIC_PANELS = 10.00f; //Sq. Ft.

            #endregion

            #region COMPONENTS

            //Concealed fan beam ( positioned a minimum 9" from end of panel)
            public static float INSULATED_ROOF_CONCEALED_FAN_BEAM = 18.30f; //Ft.
            //Extra downspout kit
            public static float INSULATED_ROOF_EXTRA_DOWNSPOUT_KIT = 40.80f; //Each
            //Caulking
            public static float INSULATED_ROOF_CAULKING = 11.80f; //Each
            //Eternabond Sealing Tape - 4" wid...50 ft. Roll
            public static float INSULATED_ROOF_ETERNABOND_SEALING_TAPE_4_INCH = 101.50f; //Each
            //Eternabond Sealing Tape - 6" wid...50 ft. Roll
            public static float INSULATED_ROOF_ETERNABOND_SEALING_TAPE_6_INCH = 152.30f; //Each
            //Flat Stock Coil...2' X 100'...White/Driftwood
            public static float INSULATED_ROOF_FLAT_STOCK_COIL_WHITE_DRIFTWOOD = 340.40f; //Each
            //Flat Stock Coil...2' X 100'...White/Bronze
            public static float INSULATED_ROOF_FLAT_STOCK_COIL_WHITE_BRONZE = 340.40f; //Each

            #region SUPPORT COMPONENTS

            //3" x 3" Fluted Post 7' White, Bronze, Driftwood
            public static float INSULATED_ROOF_FLUTED_POST_7_FOOT = 78.30f; //Each
            //3" x 3" Fluted Post 8' White, Bronze, Driftwood
            public static float INSULATED_ROOF_FLUTED_POST_8_FOOT = 91.40f; //Each
            //3" x 3" Fluted Post 9' White, Bronze, Driftwood
            public static float INSULATED_ROOF_FLUTED_POST_9_FOOT = 104.40f; //Each
            //3" x 3" Fluted Post 10' White, Bronze, Driftwood
            public static float INSULATED_ROOF_FLUTED_POST_10_FOOT = 117.50f; //Each
            //3" x 3" Fluted Post 22' White, Bronze, Driftwood
            public static float INSULATED_ROOF_FLUTED_POST_22_FOOT = 234.90f; //Each
            //1 - 1/2" x 3" Structural U-Channel ...22' ...White, Bronze, Driftwood
            public static float INSULATED_ROOF_STRUCTURAL_U_CHANNEL_22_FOOT = 7.60f; //Ft.

            #endregion

            #region SKYLIGHTS (Opening prepared - site installed)

            //Flat Glass (Thermal Low E2) Fixed (includes snaps)
            public static float INSUALTED_FLAT_GLASS_FIXED = 698.90f; //Each
            //Flat Glass (Thermal Low E2) Operating (includes snaps)
            public static float INSUALTED_FLAT_GLASS_OPERATING = 1009.60f; //Each
            //Flat Glass (Thermal Low E2) Pole for Operating Skylight (includes snaps)
            public static float INSUALTED_FLAT_GLASS_POLE_OPERATING_SKYLIGHT = 130.30f; //Each

            //Skylight Snaps...3"
            public static float INSULATED_ROOF_SKYLIGHT_SNAPS_3_INCH = 60.70f; //Each
            //Skylight Snaps...4"
            public static float INSULATED_ROOF_SKYLIGHT_SNAPS_4_INCH = 66.30f; //Each
            //Skylight Snaps...6"
            public static float INSULATED_ROOF_SKYLIGHT_SNAPS_6_INCH = 77.30f; //Each

            //Solar Fusion Skylight
            public static float INSUALTED_SOLAR_FUSION_SKYLIGHT = 524.40f; //Each

            #endregion

            #endregion

        #endregion

        #region THERMADECK INSULATED FLOOR SYSTEM

        #region PRICING - Cut to Size

        //Standard Set Backs
        //4 1/2" thick x 4' x length (7/16" OSB skin w/ 3 1/2" - 1 Lb. EPS)
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_4_THICK = 12.00f; //Sq. Ft.
        //6 1/2" thick x 4' x length (7/16" OSB skin w/ 5 1/2" - 1 Lb. EPS)
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_BACKS_6_THICK = 13.10f; //Sq. Ft.
        //8 1/4" thick x 4' x length (7/16" OSB skin w/ 7 1/4" - 1 Lb. EPS)
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_BACKS_8_THICK = 14.20f; //Sq. Ft.
        //7/16" OSB skins with Aluminum or FRP
        public static float THERMADECK_FLOOR_OSB_SKINS_WITH_ALUMINUM_OR_FRP = 6.50f; //Sq. Ft.
            
        #endregion

        #region FULL PANEL PRICING

        //Standard Set Backs
        //4 1/2" thick x 4' x length (7/16" OSB skin w/ 3 1/2" - 1 Lb. EPS) 300-500
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_4_THICK_500 = 10.70f; //Sq. Ft.
        //4 1/2" thick x 4' x length (7/16" OSB skin w/ 3 1/2" - 1 Lb. EPS) 501-1000
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_4_THICK_1000 = 9.60f; //Sq. Ft.
        //4 1/2" thick x 4' x length (7/16" OSB skin w/ 3 1/2" - 1 Lb. EPS) 1001 & UP
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_4_THICK_UP = 8.70f; //Sq. Ft.

        //6 1/2" thick x 4' x length (7/16" OSB skin w/ 5 1/2" - 1 Lb. EPS) 300-500
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_BACKS_6_THICK_300 = 11.80f; //Sq. Ft.
        //6 1/2" thick x 4' x length (7/16" OSB skin w/ 5 1/2" - 1 Lb. EPS) 501-1000
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_BACKS_6_THICK_500 = 10.70f; //Sq. Ft.
        //6 1/2" thick x 4' x length (7/16" OSB skin w/ 5 1/2" - 1 Lb. EPS) 1001 & UP
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_BACKS_6_THICK_1000 = 9.60f; //Sq. Ft.

        //8 1/4" thick x 4' x length (7/16" OSB skin w/ 7 1/4" - 1 Lb. EPS) 300-500
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_BACKS_8_THICK_300 = 12.80f; //Sq. Ft.
        //8 1/4" thick x 4' x length (7/16" OSB skin w/ 7 1/4" - 1 Lb. EPS) 501-1000
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_BACKS_8_THICK_500 = 11.50f; //Sq. Ft.
        //8 1/4" thick x 4' x length (7/16" OSB skin w/ 7 1/4" - 1 Lb. EPS) 1001 & UP
        public static float THERMADECK_FLOOR_CUT_TO_SIZE_BACKS_8_THICK_1000 = 10.30f; //Sq. Ft.

        #endregion

        //Add Metal Vapor Barrier
        public static float THERMADECK_FLOOR_ADD_METAL_VAPOR_BARRIER = 3.20f; //Sq. Ft.
        //Hot Knife (complete set)
        public static float THERMADECK_FLOOR_HOT_KNIFE = 461.50f; //Net
        //Hot Knife Replacement Blade Kit (includes 6" straight blade and 12" adjustable blades)
        public static float THERMADECK_FLOOR_HOT_KNIFE_REPLACEMENT_BLADE_KIT = 30.40f; //Net
        //Hot Knife Sled
        public static float THERMADECK_FLOOR_HOT_KNIFE_SLED = 121.70f; //Net

        #endregion

        #region SUNSPACE ACRYLIC ROOF AND PATIO COVERS

            #region COMPLETE ROOF PACKAGE INCLUDING

            #region Studio Roof

            //Up to 150 Sq. Ft....Clear, Bronze, Solar Cool White
            public static float ACRYLIC_ROOF_STUDIO_ROOF_UP_TO_150_SQ_FT = 31.00f; //Sq. Ft.
            //150 Sq. Ft. and up...Clear, Bronze, Solar Cool White
            public static float ACRYLIC_ROOF_STUDIO_ROOF_150_SQ_FT_AND_UP = 29.00f; //Sq. Ft.

            #endregion

            #region Gable Roof

            //Up to 150 Sq. Ft....Clear, Bronze, Solar Cool White
            public static float ACRYLIC_ROOF_GABLE_ROOF_UP_TO_150_SQ_FT = 32.00f; //Sq. Ft.
            //150 Sq. Ft. and up...Clear, Bronze, Solar Cool White
            public static float ACRYLIC_ROOF_GABLE_ROOF_150_SQ_FT_AND_UP = 30.00f; //Sq. Ft.

            #endregion

            //For Heatstop Cool Blue add
            public static float ACRYLIC_FOR_HEATSTOP_COOL_BLUE_ADD = 1.10f; //Sq. Ft.

            #endregion

        #endregion

    }
}