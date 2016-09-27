using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eRestaurant.BLL;

public partial class MenuItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            MenuController controller = new MenuController();
            var stuff = controller.GetRestaurantMenu();
            MenuGridView.DataSource = stuff;
            MenuGridView.DataBind();

            MenuRepeater.DataSource = stuff;
            MenuRepeater.DataBind();
        }
    }
}