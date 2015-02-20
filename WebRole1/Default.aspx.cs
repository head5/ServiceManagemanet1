using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebRole1
{
    public partial class _Default : Page
    {
        String str1 = null;
        BusinessLogic Blogic = null;
        List<String> imageList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                           
            }
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            imageList = new List<string>();
            Blogic = new BusinessLogic();
            String Errormsg = null;
            imageList = Blogic.GetAzureImages(out Errormsg);
            if (Errormsg != null)
            {
                TextBox1.Text = Errormsg;
            }
            else
            {
                foreach (String image in imageList)
                {
                    DropDownList1.Items.Add(image);
                }
                TextBox1.Text = "GetAzureImages Completed Successfully........";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Blogic = new BusinessLogic();
            string error = Blogic.SetupAzure();
            if(error==null)
            {
                TextBox1.Text = "WebPI Setup Completed Successfully............";
            }
            else { 
            TextBox1.Text = error;
            }
        }

          
        }
    }
