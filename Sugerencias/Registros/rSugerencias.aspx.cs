using BLL;
using Entidades;
using Sugerencias.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sugerencias.Registros
{
    public partial class rSugerencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IDTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }        
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Entidades.Sugerencias> Repositorio = new RepositorioBase<Entidades.Sugerencias>();
            Entidades.Sugerencias Tipos = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            return (Tipos != null);
        }
        private Entidades.Sugerencias LlenaClase()
        {
            Entidades.Sugerencias Tipos = new Entidades.Sugerencias();

            Tipos.Id = Utils.ToInt(IDTextBox.Text);
            Tipos.Descripcion = DescripcionTextBox.Text;
            Tipos.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return Tipos;
        }
        private void LlenaCampo(Entidades.Sugerencias Tipos)
        {
            IDTextBox.Text = Tipos.Id.ToString();
            DescripcionTextBox.Text = Tipos.Descripcion;
            FechaTextBox.Text = Tipos.Fecha.ToString("yyyy-MM-dd");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Entidades.Sugerencias> Repositorio = new RepositorioBase<Entidades.Sugerencias>();

            Entidades.Sugerencias Tipos = new Entidades.Sugerencias();

            Tipos = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (Tipos != null)
                LlenaCampo(Tipos);
            else
            {
                Utils.ShowToastr(this.Page, "Problema al buscar", "Error", "error");
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sugerencias Tipos = new Entidades.Sugerencias();
            RepositorioBase<Entidades.Sugerencias> Repositorio = new RepositorioBase<Entidades.Sugerencias>();
            bool paso = false;

            Tipos = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(Tipos);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this.Page, "Problema al guardar", "Error", "error");
                    return;
                }
                paso = Repositorio.Modificar(Tipos);
                Response.Redirect(Request.RawUrl);
            }

            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
                return;
            }
            else
                Utils.ShowToastr(this.Page, "Problema al guardar", "Error", "error");

            Response.Redirect(Request.RawUrl);
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Entidades.Sugerencias> Repositorio = new RepositorioBase<Entidades.Sugerencias>();

            var T = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (T != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(IDTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Guardado", "success");
                }
                else
                    Utils.ShowToastr(this.Page, "Problema al eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "Problema al eliminar", "Error", "error");

            Response.Redirect(Request.RawUrl);
        }
    }
}