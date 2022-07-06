<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Calendario.aspx.cs" Inherits="Calendar5.Vista.Calendario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
         <div class="wrapper">
             <div class="content-page">
               <%-- <form id="form1" runat="server">--%>
                    <asp:PlaceHolder ID="holder1" runat="server">
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-12">
                                            <h4 class="mb-3">Choose A Schedule Below</h4>
                                            <div class="d-flex flex-wrap align-items-center justify-content-between my-schedule mb-4">
                                               <div class="d-flex align-items-center justify-content-between"> 
                                                    <div class="form-group mb-0">
                                                        <select name="type" class="selectpicker form-control" data-style="py-0">
                                                            <option>Working Hours</option>
                                                            <option>Default Hours</option>
                                                            <option>Working Hours</option>
                                                            <option>Learning Hours</option>
                                                        </select>
                                                    </div>
                                                    <div class="select-dropdown input-prepend input-append">
                                                        <div class="btn-group">
                                                            <label data-toggle="dropdown">
                                                            <span class="dropdown-toggle search-query rounded btn bg-white btn-edit"><i class="las la-edit mr-0 text-center"></i></span><span class="search-replace"></span>
                                                            <span class="caret"><!--icon--></span>
                                                            </label>
                                                            <ul class="dropdown-menu w-100 border-none p-3">
                                                                <li><div class="item mb-2"><i class="ri-pencil-line mr-3"></i>Edit</div></li>
                                                                <li><div class="item"><i class="ri-delete-bin-6-line mr-3"></i>Delete</div></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>  
                                                <div class="create-workform">
                                                    <a href="#" data-toggle="modal" data-target="#date-event" class="btn btn-primary pr-5 position-relative">New Schedule<span class="add-btn"><i class="ri-add-line"></i></span></a>
                                                </div>                 
                                            </div>
                                            <h4 class="mb-3">Set Your weekly hours</h4>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="card card-block card-stretch">
                                                        <div class="card-body">
                                                            <asp:panel id="pnl" runat="server">
                                                              <%--<div id="calendar1" class="calendar-s"    ></div>--%>
                                                                <asp:Panel ID="calendar1" runat="server" ClientIDMode="Static" CssClass="calendar-s"></asp:Panel>
                                                           </asp:panel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                <%--</form>--%>
               
             </div>
         </div>
    <script type="text/javascript">
        //<![CDATA[
        function addEventCalendar(evento) {
            <%--evento: <%= Calend %>--%>
            //const title = $(this).find('#schedule-title').val()
            //const startDate = moment(new Date($(this).find('#schedule-start-date').val()), 'YYYY-MM-DD').format('YYYY-MM-DD') + 'T05:30:00.000Z'
            //const endDate = moment(new Date($(this).find('#schedule-end-date').val()), 'YYYY-MM-DD').format('YYYY-MM-DD') + 'T05:30:00.000Z'
            //const color = $(this).find('#schedule-color').val()
            //console.log(startDate, endDate, color)
            //const event = {
            //    title: title,
            //    start: startDate || '2020-12-22T02:30:00',
            //    end: endDate || '2020-12-12T14:30:00',
            //    color: color || '#7858d7'
            //}

            console.log(evento)
           /* $(this).closest('#date-event').modal('hide')*/
            //calendar1.addEvent(event)
            calendar1.addEvent(evento)
        }
        //]]>
    </script>
</asp:Content>
