using Cecam.Domain.Interfaces.Service;
using Cecam.Web.SiteForms.DTO;
using Cecam.Web.SiteForms.Helpers;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Cecam.Web.SiteForms
{
    public partial class Index : System.Web.UI.Page
    {
        private ICompanyService _companyService;

        public Index(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    var companies = CompanyHelper.ListCompanies(_companyService);

                    var dataTable = DataTableHelper.ConvertListToTable<CompanyDTO>(companies);

                    CompanyGridView.DataSource = dataTable;
                    CompanyGridView.DataBind();
                }
            }
            
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void CompanyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("DeleteCustomer"))
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    int id = Convert.ToInt32(CompanyGridView.DataKeys[rowIndex].Values[0]);

                    CompanyHelper.DeleteLineGridView(_companyService, id);
                }

                Response.Redirect(Request.RawUrl);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}