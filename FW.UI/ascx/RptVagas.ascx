<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RptVagas.ascx.cs" Inherits="FW.UI.ascx.RptVagas" %>
 
<div  class=" container   mx-auto p-2" >
      
            
<asp:Panel runat="server" ID="PlTitle" Visible="false"  class=" mt-4 mb-4 col-12 mx-auto  container " >
                       
        <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#columns-gap"></use></svg>
          <label class="fs-6 font-monospace  fw-bold pt-1">Oportunidades</label>
            </asp:Panel>
             <asp:Repeater ID="rptVaga1" runat="server">
                  
            <itemtemplate>
                <div class="card my-3  ">
                    <div class="card-header d-flex justify-content-between fw-semibold text-capitalize  ">
                       <label class=" text-truncate  font-monospace  fw-bold    ">   
                           <%# DataBinder.Eval(Container.DataItem, "NomeVg") %>
                  </label>  <div  class="  d-flex float-end ms-3   " >
        <svg class="bi me-2 my-auto  " width="15" height="15"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#geo-alt"></use></svg>
          <label class="fs-6 font-monospace  fw-bold  "><%# DataBinder.Eval(Container.DataItem, "TipoVagaVg").ToString() %></label>
       </div>
                    </div>
                    <div class="card-body">
                      <p class="card-text cont-text-200 font-monospace "><%# ((string)DataBinder.Eval(Container.DataItem, "DescricaoVg")).Replace(Environment.NewLine, "<br />") %></p>
                        
                    </div>
                    <div class="card-footer text-muted  ">
                              <asp:Label runat="server"  class="small  Date_Alter_TempoPublicado float-start"   ><%# DataBinder.Eval(Container.DataItem, "DateTimeInsertVg").ToString() %></asp:Label>
                     <label class="  ms-2 float-end" >
                         <a class="customer-link font-monospace fw-bolder "  href="View_oportunidade.aspx?id_oportunidade=<%# DataBinder.Eval(Container.DataItem, "IdVaga ") %>" style="font-size:10pt;">Ver detalhes</a></label> 
                       
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
      </div>
<asp:Panel runat="server" ID="pnNotResult" Visible="false"  class=" container   mx-auto p-4" >
    <asp:TextBox  runat="server" CssClass="mx-auto text-center font-monospace" >Nenhum resultado ao buscar vagas</asp:TextBox>
    <asp:Image runat="server" ID="img_notResult"  ImageUrl="../Imagens/Undraw/undraw_world_re_768g.svg" />
            </asp:Panel>
          
