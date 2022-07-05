﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="Calendario.aspx.cs" Inherits="Calendar5.Vista.Calendario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBody" runat="server">
         <div class="wrapper">
             <div class="content-page">
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
                                                    <div id="calendar1" class="calendar-s"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    </div>
                </div>
                <div class="modal fade" id="date-event" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-body">
                                <div class="popup text-left">
                                    <h4 class="mb-3">Add Schedule</h4>
                                    <form action="/" id="submit-schedule">
                                        <div class="content create-workform row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="form-label" for="schedule-title">Schedule For</label>
                                                    <input class="form-control" placeholder="Enter Title" type="text" name="title" id="schedule-title" required />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-label" for="schedule-start-date">Start Date</label>
                                                    <input class="form-control basicFlatpickr date-input" placeholder="2020-06-20" type="text" name="title" id="schedule-start-date" required />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-label" for="schedule-end-date">End Date</label>
                                                    <input class="form-control basicFlatpickr date-input" placeholder="2020-06-20" type="text" name="title" id="schedule-end-date" required />
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <input class="form-control" type="color" name="title" id="schedule-color" required />
                                                </div>
                                            </div>
                                            <div class="col-md-12 mt-4">
                                                <div class="d-flex flex-wrap align-items-ceter justify-content-center">
                                                    <button class="btn btn-primary mr-4" data-dismiss="modal">Cancel</button>
                                                    <button class="btn btn-outline-primary" type="submit">Save</button>
                                                </div>
                                            </div>  
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div> 
             </div>
         </div>
</asp:Content>
