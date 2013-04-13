Imports System.Drawing.Printing

Public Class FormVistaPrevia
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents TextBoxImpresion As System.Windows.Forms.TextBox
    Friend WithEvents ButtonImprimirArchivo As System.Windows.Forms.Button
    Friend WithEvents ButtonImprimirString As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBoxImpresion = New System.Windows.Forms.TextBox
        Me.ButtonImprimirArchivo = New System.Windows.Forms.Button
        Me.ButtonImprimirString = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBoxImpresion
        '
        Me.TextBoxImpresion.Location = New System.Drawing.Point(8, 8)
        Me.TextBoxImpresion.Name = "TextBoxImpresion"
        Me.TextBoxImpresion.Size = New System.Drawing.Size(264, 20)
        Me.TextBoxImpresion.TabIndex = 0
        Me.TextBoxImpresion.Text = ""
        '
        'ButtonImprimirArchivo
        '
        Me.ButtonImprimirArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonImprimirArchivo.Location = New System.Drawing.Point(8, 56)
        Me.ButtonImprimirArchivo.Name = "ButtonImprimirArchivo"
        Me.ButtonImprimirArchivo.TabIndex = 1
        Me.ButtonImprimirArchivo.Text = "Archivo"
        '
        'ButtonImprimirString
        '
        Me.ButtonImprimirString.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonImprimirString.Location = New System.Drawing.Point(96, 56)
        Me.ButtonImprimirString.Name = "ButtonImprimirString"
        Me.ButtonImprimirString.TabIndex = 2
        Me.ButtonImprimirString.Text = "Cadena"
        '
        'FormVistaPrevia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(280, 101)
        Me.Controls.Add(Me.ButtonImprimirString)
        Me.Controls.Add(Me.ButtonImprimirArchivo)
        Me.Controls.Add(Me.TextBoxImpresion)
        Me.MaximumSize = New System.Drawing.Size(288, 128)
        Me.Name = "FormVistaPrevia"
        Me.Text = "Vista Previa"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ButtonImprimirString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimirString.Click
        Dim a As ticket = New ticket
        'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 

        a.AnadirLineaCabeza("STARBUCKS COFFEE TAMAULIPAS")
        a.AnadirLineaCabeza("EXPEDIDO EN:")
        a.AnadirLineaCabeza("AV. TAMAULIPAS NO. 5 LOC. 101")
        a.AnadirLineaCabeza("MEXICO, DISTRITO FEDERAL")
        a.AnadirLineaCabeza("RFC: CSI-020226-MV4")

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        a.AnadirLineaSubcabeza("Caja # 1 - Ticket # 1")
        a.AnadirLineaSubcabeza("Le atendió: Prueba")
        a.AnadirLineaSubcabeza(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        a.AnadirElemento("1", "Articulo Prueba", "15.00")
        a.AnadirElemento("2", "Articulo Prueba", "25.00")

        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
        a.AnadirTotal("SUBTOTAL", "29.75")
        a.AnadirTotal("IVA", "5.25")
        a.AnadirTotal("TOTAL", "35.00")
        a.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio 
        a.AnadirTotal("RECIBIDO", "50.00")
        a.AnadirTotal("CAMBIO", "15.00")
        a.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio 
        a.AnadirTotal("USTED AHORRO", "0.00")


        '//El metodo AddFooterLine funciona igual que la cabecera 
        a.AnadeLineaAlPie("EL CAFE ES NUESTRA PASION...")
        a.AnadeLineaAlPie("VIVE LA EXPERIENCIA EN STARBUCKS")
        a.AnadeLineaAlPie("GRACIAS POR TU VISITA")

        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        '//parametro de tipo string que debe de ser el nombre de la impresora. 
        a.ImprimeTicket("PDF")


    End Sub

    Private Sub ButtonImprimirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimirArchivo.Click
        Dim a As ticket = New ticket
        a.MargenIzquierdo = 1
        a.MargenSuperior = 1

        'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        Dim dtEncabezado As New DataTable
        Utilidades.cFunciones.Llenar_Tabla_Generico("SELECT     Empresa FROM         configuraciones", dtEncabezado)
        If dtEncabezado.Rows.Count > 0 Then
            a.AnadirLineaCabeza(dtEncabezado.Rows(0).Item("Empresa"))

        End If

        Dim dtVouch As New DataTable

        Utilidades.cFunciones.Llenar_Tabla_Generico("SELECT Empresa FROM configuraciones", dtVouch)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        a.AnadirLineaSubcabeza("Caja # 1 - Ticket # 1")
        a.AnadirLineaSubcabeza("Le atendió: Prueba")
        a.AnadirLineaSubcabeza(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())

        a.EncabezadoElementos = "PAX   DESCRIPCION"
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        a.AnadirElemento("1", "Articulo Prueba", "15.00")
        a.AnadirElemento("2", "Articulo Prueba", "25.00")

        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
        a.AnadirTotal("SUBTOTAL", "29.75")
        a.AnadirTotal("IVA", "5.25")
        a.AnadirTotal("TOTAL", "35.00")
        a.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio 
        a.AnadirTotal("RECIBIDO", "50.00")
        a.AnadirTotal("CAMBIO", "15.00")
        a.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio 
        a.AnadirTotal("USTED AHORRO", "0.00")


        '//El metodo AddFooterLine funciona igual que la cabecera 
        a.AnadeLineaAlPie("EL CAFE ES NUESTRA PASION...")
        a.AnadeLineaAlPie("VIVE LA EXPERIENCIA EN STARBUCKS")
        a.AnadeLineaAlPie("GRACIAS POR TU VISITA")
        Dim impresora As String = "\\192.168.3.106\Tiquetes 2" '"PDF" '"\\192.168.3.106\Tiquetes 2"
        'Dim PrinterDialog As New PrintDialog
        'Dim DocPrint As New PrintDocument
        'PrinterDialog.Document = DocPrint
        'If PrinterDialog.ShowDialog() = DialogResult.OK Then
        '    impresora = PrinterDialog.PrinterSettings.PrinterName 'DEVUELVE LA IMPRESORA  SELECCIONADA
        'Else
        '    impresora = "" 'NO SE SELECCIONO IMPRESORA ALGUNA
        '    MessageBox.Show("Debe de seleccionar la impresora a cual se va a imprimir los tiquetes", "Seleccion Incorrecta...", MessageBoxButtons.OK)
        'End If

        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        '//parametro de tipo string que debe de ser el nombre de la impresora. 
        a.ImprimeTicket(impresora)

    End Sub

    Private Sub TextBoxImpresion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxImpresion.TextChanged

    End Sub
End Class
