<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rSugerencias.aspx.cs" Inherits="Sugerencias.Registros.rSugerencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row">
                    <label for="ID" class="col-sm-1 col-form-label">ID</label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:TextBox type="number" ID="IDTextBox" runat="server" min=0 class="form-control input-sm"></asp:TextBox>
                    </div>
                <br />
                    <div class="col-md-3 col-sm-2 col-xs-4">
                         <asp:LinkButton ID="BuscarButton" CssClass="btn btn-primary btn-block btn-md" CausesValidation="false" runat="server" Text="Buscar" OnClick="BuscarButton_Click"></asp:LinkButton>
                    </div>   
                <br />
                <br>

             </div>

             <%--Descripcion--%>
                <div class="form-group row">
                    <label for="Descripcion" class="col-sm-1 col-form-label">Descripcion</label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="DescripcionTextBox" CssClass="form-control input-sm"></asp:TextBox>  
                        <asp:RequiredFieldValidator ID="RFVDescripcion" runat="server" MaxLength="200" ControlToValidate="DescripcionTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="form-group row">
                 <label for="Fecha" class="col-xs-1 col-form-label">Fecha</label>
                    <div class="col-md-3">
                        <asp:TextBox ID="FechaTextBox" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFecha" runat="server" MaxLength="200" ControlToValidate="FechaTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                    </div>
            </div>
        </div>
        <br />
           <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" class="btn btn-primary btn-sm" CausesValidation="false" style="color:#fff" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuardarButton" OnClick="GuardarButton_Click"/>
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" CausesValidation="false" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>
</asp:Content>
