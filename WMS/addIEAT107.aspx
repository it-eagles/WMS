<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="addIEAT107.aspx.vb" Inherits="WMS.addIEAT107" EnableEventValidation="false" EnableViewState="true"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Eaglesthai.com | WMS</title>

    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="Scripts/bootstrap/dist/css/bootstrap.min.css" />
   <%-- <!-- Font Awesome -->
                   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">--%>
     <!-- Font Awesome -->
                  <link rel="stylesheet" href="Scripts/font-awesome/css/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="Scripts/Ionicons/css/ionicons.min.css" />
    <!-- daterange picker -->
    <link rel="stylesheet" href="Scripts/bootstrap-daterangepicker/daterangepicker.css" />
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="Scripts/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" />
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="Scripts/plugins/iCheck/all.css" />
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="Scripts/bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css" />
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="Scripts/plugins/timepicker/bootstrap-timepicker.min.css" />
    <!-- Select2 -->
    <link rel="stylesheet" href="Scripts/select2/dist/css/select2.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="Scripts/dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
                       folder instead of downloading all of them to reduce the load. -->

    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" />
    <!-- DataTables -->
    <link rel="stylesheet" href="Scripts/datatables.net-bs/css/dataTables.bootstrap.min.css" />



    <link rel="stylesheet" href="Scripts/dist/css/skins/_all-skins.min.css" />
    <%--<link rel="stylesheet" href="Scripts/util.css" />--%>
    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="360000"></asp:ScriptManager>
        <section class="content">
            <div class="row">
                <!-- left column -->
                <div class="col-lg-12 col-md-12">

                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <div class="form-horizontal">
                                <div class="box-body">
                      
                                        <div class="col-lg-12 col-md-12 " style="overflow: auto;">
                                            <asp:Repeater ID="dgvIeat107" runat="server">
                                                <HeaderTemplate>
                                                    <table id="example2" class="table table-bordered table-striped table-responsive" style="overflow: auto;">
                                                        <thead>
                                                            <tr>
                                                                <th>select</th>
                                                                <th>PartyCode</th>
                                                                <th>InvoiceNo</th>
                                                                <th>JobNo</th>
                                                                <th>Status</th>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:LinkButton ID="LinkButton1" CssClass="btn bg-navy" runat="server" CausesValidation="False" CommandName="selectInvoiceNo" CommandArgument='<%# Eval("InvoiceNo")%>'><i class="fa fa-hand-o-up"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPartyCode" runat="server" Text='<%# Bind("PartyCode")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblInvoiceNo_" runat="server" Text='<%# Bind("InvoiceNo")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("JobNo")%>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status")%>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tfoot>
                                                        <tr>
                                                            <th>select</th>
                                                            <th>PartyCode</th>
                                                            <th>InvoiceNo</th>
                                                            <th>JobNo</th>
                                                            <th>Status</th>
                                                        </tr>
                                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                  
                                    <div class="col-md-12 col-lg-12">
                                      <fieldset>
                                                <legend></legend>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="txtTotalAmornut" class="col-sm-4 control-label">ยอดทั้งหมด</label>
                                                        <div class="col-md-8">
                                                            <input runat="server" id="txtTotalAmonut" type="text" autocomplete="off" class="form-control" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtTotalUseAmonut" class="col-sm-4 control-label">ยอดที่ใช้ไปทั้งหมด</label>
                                                        <div class="col-sm-8">
                                                            <input runat="server" class="form-control" id="txtTotalUseAmonut" type="text" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtAmonut" class="col-sm-4 control-label">ยอดคงเหลือ</label>
                                                        <div class="col-sm-8">
                                                            <input runat="server" class="form-control" id="txtAmonut" type="text" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtUseAmonut" class="col-sm-4 control-label">ยอดที่ใช้ Inv นี้</label>
                                                        <div class="col-sm-8">
                                                            <input runat="server" id="txtUseAmonut" class="form-control" type="text" autocomplete="off" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="dtpForm" class="col-sm-4 control-label">วันที่ของออก</label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox CssClass="form-control" ID="dtpForm" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                            </asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" TargetControlID="dtpForm" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="dtpTo" class="col-sm-4 control-label">วันที่ของกลับ</label>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox CssClass="form-control" ID="dtpTo" runat="server" placeholder="MM/DD/YYYY" autocomplete="off">
                                                            </asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender9" runat="server" Enabled="True" TargetControlID="dtpTo" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="checkbox col-sm-4">
                                                            <label>
                                                                <input type="checkbox" runat="server" id="Checkbox1" onclick="chkExpEnable3();" />ต่ออายุ
                                                            </label>
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <asp:TextBox CssClass="form-control" ID="dtpEx" runat="server" placeholder="MM/DD/YYYY" autocomplete="off" disabled="disabled">
                                                            </asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" TargetControlID="dtpEx" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                                        </div>
                                                    </div>
                                                </div>
                                          <div class="form-group">
                                              <button type="button" runat="server" class="btn btn-primary" id="Button1" onserverclick="btnaddIEAT107__ServerClick">Add</button>
                                          </div>
                                            </fieldset>
                                      </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
       </section>
    </form>
      <script src="Scripts/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="Scripts/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- Select2 -->
    <script src="Scripts/select2/dist/js/select2.full.min.js"></script>
    <!-- InputMask -->
    <script src="Scripts/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="Scripts/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="Scripts/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <!-- date-range-picker -->
    <script src="Scripts/moment/min/moment.min.js"></script>
    <script src="Scripts/bootstrap-daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap datepicker -->
    <script src="Scripts/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <!-- bootstrap color picker -->
    <script src="Scripts/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"></script>
    <!-- bootstrap time picker -->
    <script src="Scripts/plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <!-- SlimScroll -->
    <script src="Scripts/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- iCheck 1.0.1 -->
    <script src="Scripts/plugins/iCheck/icheck.min.js"></script>
    <!-- FastClick -->
    <script src="Scripts/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="Scripts/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="Scripts/dist/js/demo.js"></script>
    <!-- DataTables -->
    <script src="Scripts/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="Scripts/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example1').DataTable()
            $('#example2').DataTable()
            $('#example3').DataTable()
            $('#example4').DataTable()
            $('#example5').DataTable()
            $('#example6').DataTable()
            $('#example7').DataTable()
            $('#example8').DataTable()
            $('#example9').DataTable()
            $('#example10').DataTable()
            $('#exa').DataTable()
            $('#example20').DataTable({
                'paging': true,
                'lengthChange': false,
                'searching': false,
                'ordering': true,
                'info': true,
                'autoWidth': false
            })
        })
    </script>

    <script>
        $(function () {
            //Initialize Select2 Elements
            $('.select2').select2()
            $('.select3').select2()
            //Datemask dd/mm/yyyy
            $('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
            //Datemask2 mm/dd/yyyy
            $('#datemask2').inputmask('mm/dd/yyyy', { 'placeholder': 'mm/dd/yyyy' })
            //Money Euro
            $('[data-mask]').inputmask()

            //Date range picker
            $('#reservation').daterangepicker()
            //Date range picker with time picker
            $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' })
            //Date range as a button
            $('#daterange-btn').daterangepicker(
              {
                  ranges: {
                      'Today': [moment(), moment()],
                      'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                      'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                      'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                      'This Month': [moment().startOf('month'), moment().endOf('month')],
                      'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                  },
                  startDate: moment().subtract(29, 'days'),
                  endDate: moment()
              },
              function (start, end) {
                  $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'))
              }
            )

            //Date picker
            $('#datepicker').datepicker({
                autoclose: true
            })

            $('#dtpInvoiceDate').datepicker({
                autoclose: true
            })


            //Date pickerJobdate       USE IN CreateRec.aspx
            $('#datepickerJobdate').datepicker({
                autoclose: true
            })

            //Date pickerActualDate1   USE IN CreateRec.aspx
            $('#datepickerActualDate1').datepicker({
                autoclose: true
            })

            //Date pickerActualDate2   USE IN CreateRec.aspx
            $('#datepickerActualDate2').datepicker({
                autoclose: true
            })

            //Date pickerActualDate3   USE IN CreateRec.aspx
            $('#datepickerActualDate3').datepicker({
                autoclose: true
            })

            //Date pickerActualDate4   USE IN CreateRec.aspx
            $('#datepickerActualDate4').datepicker({
                autoclose: true
            })

            //Date pickerActualPickUp  USE IN CreateRec.aspx
            $('#datepickerActualPickUp').datepicker({
                autoclose: true
            })

            //Date pickerArrivalToEAS  USE IN CreateRec.aspx
            $('#datepickerArrivalToEAS').datepicker({
                autoclose: true
            })

            //iCheck for checkbox and radio inputs
            $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_minimal-blue'
            })
            //Red color scheme for iCheck
            $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red'
            })
            //Flat red color scheme for iCheck
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            })

            //Colorpicker
            $('.my-colorpicker1').colorpicker()
            //color picker with addon
            $('.my-colorpicker2').colorpicker()

            //Timepicker
            $('.timepicker').timepicker({
                showInputs: false
            })
        })
    </script>
    <script type="text/javascript">
        function CallConfirmBox() {
            if (confirm('Confirm Proceed Further?')) {
                alert('You pressed OK!')
            } else {
                alert('You pressed Cancel!');
            }
        }
    </script>
   
    <script>
        //function openModal() {
        //    $('#exampleModal').modal('show');
        //}

        function openjobNoModal() {
            $('#myModal').modal('hise');
        }

    </script>
    <script type="text/javascript">
        function ShowPopup() {
            $(function () {
                $("#myModal").html();
                $("#myModal").dialog({
                    title: "jQuery Dialog Popup",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };
</script>
    <script type="text/javascript">
        function chkExpEnable3() {
            var status = document.getElementById('<%=Checkbox1.ClientID%>').checked;

                if (status == true) {
                    document.getElementById('<%=dtpEx.ClientID%>').disabled = false;

                } else if (status == false) {
                    document.getElementById('<%=dtpEx.ClientID%>').disabled = true;
                }
        }
    </script>
</body>
</html>
