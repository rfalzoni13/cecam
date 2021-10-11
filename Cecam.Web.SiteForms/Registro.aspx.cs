using Cecam.Domain.Interfaces.Service;
using Cecam.Web.SiteForms.DTO;
using Cecam.Web.SiteForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cecam.Web.SiteForms
{
    public partial class Registro : System.Web.UI.Page
    {
        private ICompanyService _companyService;

        public Registro(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);

                if (id > 0)
                {
                    var companyDTO = CompanyHelper.GetCompanyById(_companyService, id);
                    Id.Value = companyDTO.Id.ToString();
                    CompanyName.Text = companyDTO.CompanyName;
                    DocumentNumber.Text = companyDTO.DocumentNumber;
                    PhoneNumber.Text = companyDTO.PhoneNumber;
                    Active.Checked = companyDTO.Active;
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var companyDTO = new CompanyDTO
                {
                    Id = !string.IsNullOrEmpty(Id.Value) ? Convert.ToInt32(Id.Value) : 0,
                    DocumentNumber = DocumentNumber.Text,
                    CompanyName = CompanyName.Text,
                    PhoneNumber = PhoneNumber.Text,
                    Active = Active.Checked,
                    Created = DateTime.Now
                };

                //Devido a uma limitação da versão 7.3 do C# o objeto será verificado numa cláusula "if"
                //ao invés de um ternário devido ao valor booleano
                if(!string.IsNullOrEmpty(Id.Value))
                {
                    companyDTO.Modified = DateTime.Now;
                }

                if(companyDTO.Id > 0)
                {
                    CompanyHelper.UpdateLineGridView(_companyService, companyDTO);
                }
                else
                {
                    CompanyHelper.AddLineGridView(_companyService, companyDTO);
                }

                Response.Redirect("~/Index.aspx", false);
            }
            
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}