using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole1
{
    public partial class CreateVM : System.Web.UI.Page
    {
        BusinessLogic Blogic;
        protected void Page_Load(object sender, EventArgs e)
        {
            Blogic = new BusinessLogic();
            string errormsg = null;
            List<String> imagesList=Blogic.GetAzureImages(out errormsg);

            foreach (String image in imagesList)
            {
                ddImageList.Items.Add(image);
            }
        }

        protected void BCreateVM_Click(object sender, EventArgs e)
        {
            VMDetails vmdetails = new VMDetails();
            Blogic = new BusinessLogic();
            vmdetails.ImageName = ddImageList.Text.ToString();
            vmdetails.InstanceSize = ddInstanceSize.Text.ToString();
            vmdetails.Location = "East Asia";
            vmdetails.UserName = "achiever";
            vmdetails.Passowrd = "achiever12!@";
            vmdetails.ServiceName = "mindtree";
            vmdetails.VMName = TextVMName.Text.ToString();
            vmdetails.Datadisk = TextDataDisk.Text.ToString();

            String msg=Blogic.createVM(vmdetails);
            TextError.Text = msg;
        }

    }
}