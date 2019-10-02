using BLL;
using Sugerencias.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sugerencias.Consulta
{
    public partial class cSugerencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Entidades.Sugerencias, bool>> filtros = x => true;
            RepositorioBase<Entidades.Sugerencias> repositorio = new RepositorioBase<Entidades.Sugerencias>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            int id;
            id = Utils.ToInt(CriterioTextBox.Text);
            if (CheckBoxFecha.Checked == true)
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0: //ID                  
                        filtros = c => c.Id == id && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 1: //Descripcion
                        filtros = c => c.Descripcion.Contains(CriterioTextBox.Text) && c.Fecha >= Desde && c.Fecha <= Hasta;
                        break;
                    case 2: //Todo
                        break;
                }
            }
            else
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0: //ID                  
                        filtros = c => c.Id == id;
                        break;
                    case 1: //Descripcion
                        filtros = c => c.Descripcion.Contains(CriterioTextBox.Text);
                        break;
                    case 2: //Todo
                        break;
                }
            }
            Grid.DataSource = repositorio.GetList(filtros);
            Grid.DataBind();
        }
    }
}
}