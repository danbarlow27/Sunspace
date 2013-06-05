using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunspaceDealerDesktop
{
    public class Corner
    {
        ItemIndex 		As Integer 'LinearItems Array Index
        AngleIs90 		As Boolean 'True if 90, False if 45
        ??CutLength 	As Float	'Length to Cut Corner At
        Colour 		As String	'Colour of the corner
        OutsideCorner 	As Boolean 'True is Normal Corner, False if inside corner

    }
}