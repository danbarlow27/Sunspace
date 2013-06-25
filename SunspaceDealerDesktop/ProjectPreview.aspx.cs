using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunspaceDealerDesktop
{
    public partial class ProjectPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            float sentWallLength = 240f;
            Receiver leftReceiver = new Receiver();
            Filler leftFiller = new Filler();

            List<Object> listOfDoors = new List<Object>();
            listOfDoors.Add(new Door());
            listOfDoors.Add(new Door());
            listOfDoors.Add(new Door());
        }
    }
}