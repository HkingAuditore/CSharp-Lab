using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSharp
{
    public partial class RankingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Avatar.ImageUrl = Avatar.ImageUrl + GridView1.Rows[1].Cells[1].Text.ToString() + ".jpg";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsView1.SetPageIndex(GridView1.SelectedIndex);
        }
    }
}