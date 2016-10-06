<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="webFormExample.index" %>

<!DOCTYPE html>

<html lang="es-es">
<head runat="server">
<meta charset="utf-8"/>
    <title></title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
      
<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
<script   src="http://code.jquery.com/jquery-2.2.4.min.js"   integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="   crossorigin="anonymous"></script>
<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager" />
        
    <div>
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/index.aspx" Text="Pagina principal" Value="Pagina principal"></asp:MenuItem>
            </Items>
        </asp:Menu>

    
    
        <asp:UpdatePanel ID="upCrudGrid" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnCreateUser" runat="server" Text="Crear Usuario"  OnClick="btnCreateUser_Click"/>
        <asp:GridView DataKeyNames="idUser" OnRowCommand="grdv_Users_RowCommand" ID="grdUser" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False">
            <Columns>
                <asp:ButtonField CommandName="editUser" Text="Editar" ControlStyle-CssClass="btn btn-info">
                    <ControlStyle CssClass="btn btn-info" />
                 </asp:ButtonField>
                <asp:ButtonField CommandName="deleteUser" Text="Borrar" ControlStyle-CssClass="btn btn-danger">
                    <ControlStyle CssClass="btn btn-danger" />
                 </asp:ButtonField>
                <asp:BoundField DataField="idUser" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="Nombre Usuario" Visible="true" />
            </Columns>
        </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>

 <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id=""></h4>
      </div>
      <div class="modal-body">
       <asp:Label runat="server" ID="lblIdUser" Visible="false" Text=""></asp:Label>
        <asp:TextBox ID="txtNameUser" runat="server" Text=""></asp:TextBox>
      </div>
      <div class="modal-footer">

        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>      
        <asp:Button runat="server" OnClick="btnSaveUser_Click"  id="btnSaveUser" Text="Guardar" />
      </div>
  </div>
</div>
</div>
    
        <div class="modal fade" id="deleteConfirm" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id=""></h4>
      </div>
      <div class="modal-body">
          <asp:Label ID="lblMessage" runat="server" Text="¿Esta usted seguro que desea borrar?"></asp:Label>
         
          <asp:TextBox ID="txtIdUser" runat="server" Enabled="false" Visible="false"></asp:TextBox>
          
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
          <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Borrar" />
      </div>
    </div>
  </div>
</div>
    </div>
    </form>
</body>
</html>
